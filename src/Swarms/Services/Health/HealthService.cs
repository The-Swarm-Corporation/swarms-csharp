using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Health;

namespace Swarms.Services.Health;

public sealed class HealthService : IHealthService
{
    readonly ISwarmsClientClient _client;

    public HealthService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResponse> Check(HealthCheckParams parameters)
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
        return JsonSerializer.Deserialize<HealthCheckResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
