using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Agent.Batch;
using Swarms = Swarms;

namespace Swarms.Services.Agent.Batch;

public sealed class BatchService : IBatchService
{
    readonly Swarms::ISwarmsClientClient _client;

    public BatchService(Swarms::ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<BatchRunResponse> Run(BatchRunParams parameters)
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
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<BatchRunResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
