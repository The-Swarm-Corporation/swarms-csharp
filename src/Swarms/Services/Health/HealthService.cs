using System;
using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Health;

namespace Swarms.Services.Health;

public sealed class HealthService : IHealthService
{
    public IHealthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HealthService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public HealthService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResponse> Check(HealthCheckParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<HealthCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<HealthCheckResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
