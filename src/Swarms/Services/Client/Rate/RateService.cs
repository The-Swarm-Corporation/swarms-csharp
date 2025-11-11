using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client.Rate;

public sealed class RateService : IRateService
{
    public IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public RateService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<RateGetLimitsResponse> GetLimits(
        RateGetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RateGetLimitsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<RateGetLimitsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
