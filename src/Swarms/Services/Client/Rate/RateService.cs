using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Client.Rate;
using Swarms = Swarms;

namespace Swarms.Services.Client.Rate;

public sealed class RateService : IRateService
{
    readonly Swarms::ISwarmsClientClient _client;

    public RateService(Swarms::ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, JsonElement>> GetLimits(RateGetLimitsParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
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

        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
