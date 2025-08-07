using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client.Rate;

public sealed class RateService : IRateService
{
    readonly ISwarmsClientClient _client;

    public RateService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, JsonElement>> GetLimits(RateGetLimitsParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
