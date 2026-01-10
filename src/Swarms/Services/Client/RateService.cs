using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class RateService : IRateService
{
    readonly Lazy<IRateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateService(this._client.WithOptions(modifier));
    }

    public RateService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RateGetLimitsResponse> GetLimits(
        RateGetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetLimits(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RateServiceWithRawResponse : IRateServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RateServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RateGetLimitsResponse>> GetLimits(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<RateGetLimitsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
