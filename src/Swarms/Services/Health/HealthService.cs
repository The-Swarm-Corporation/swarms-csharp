using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Health;
using Swarms = Swarms;

namespace Swarms.Services.Health;

public sealed class HealthService : IHealthService
{
    readonly Swarms::ISwarmsClientClient _client;

    public HealthService(Swarms::ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResponse> Check(HealthCheckParams parameters)
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

        return JsonSerializer.Deserialize<HealthCheckResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
