using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AutoSwarmBuilder;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class AutoSwarmBuilderService : IAutoSwarmBuilderService
{
    readonly Lazy<IAutoSwarmBuilderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutoSwarmBuilderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IAutoSwarmBuilderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutoSwarmBuilderService(this._client.WithOptions(modifier));
    }

    public AutoSwarmBuilderService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AutoSwarmBuilderServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AutoSwarmBuilderCreateCompletionResponse> CreateCompletion(
        AutoSwarmBuilderCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateCompletion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<string>> ListExecutionTypes(
        AutoSwarmBuilderListExecutionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListExecutionTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AutoSwarmBuilderServiceWithRawResponse : IAutoSwarmBuilderServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutoSwarmBuilderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutoSwarmBuilderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutoSwarmBuilderServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoSwarmBuilderCreateCompletionResponse>> CreateCompletion(
        AutoSwarmBuilderCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutoSwarmBuilderCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AutoSwarmBuilderCreateCompletionResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<string>>> ListExecutionTypes(
        AutoSwarmBuilderListExecutionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutoSwarmBuilderListExecutionTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<string>>(token).ConfigureAwait(false);
            }
        );
    }
}
