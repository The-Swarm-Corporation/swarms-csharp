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
    /// <inheritdoc/>
    public IAutoSwarmBuilderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutoSwarmBuilderService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public AutoSwarmBuilderService(ISwarmsClientClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AutoSwarmBuilderCreateCompletionResponse> CreateCompletion(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AutoSwarmBuilderCreateCompletionResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<List<string>> ListExecutionTypes(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<List<string>>(cancellationToken).ConfigureAwait(false);
    }
}
