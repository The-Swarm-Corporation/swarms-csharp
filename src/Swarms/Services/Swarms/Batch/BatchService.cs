using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms.Batch;

namespace Swarms.Services.Swarms.Batch;

public sealed class BatchService : IBatchService
{
    readonly ISwarmsClientClient _client;

    public BatchService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<List<Dictionary<string, JsonElement>>> Run(BatchRunParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
