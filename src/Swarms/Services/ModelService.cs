using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Models;

namespace Swarms.Services;

/// <inheritdoc/>
public sealed class ModelService : IModelService
{
    readonly Lazy<IModelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IModelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelService(this._client.WithOptions(modifier));
    }

    public ModelService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ModelServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ModelListAvailableResponse> ListAvailable(
        ModelListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAvailable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ModelServiceWithRawResponse : IModelServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IModelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ModelServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelListAvailableResponse>> ListAvailable(
        ModelListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelListAvailableParams> request = new()
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
                    .Deserialize<ModelListAvailableResponse>(token)
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
