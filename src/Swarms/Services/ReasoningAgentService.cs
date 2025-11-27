using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services;

/// <inheritdoc />
public sealed class ReasoningAgentService : IReasoningAgentService
{
    /// <inheritdoc/>
    public IReasoningAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReasoningAgentService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public ReasoningAgentService(ISwarmsClientClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReasoningAgentCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response
            .Deserialize<Dictionary<string, JsonElement>>(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReasoningAgentListTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response
            .Deserialize<Dictionary<string, JsonElement>>(cancellationToken)
            .ConfigureAwait(false);
    }
}
