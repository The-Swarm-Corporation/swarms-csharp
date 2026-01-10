using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services;

/// <inheritdoc/>
public sealed class ReasoningAgentService : IReasoningAgentService
{
    readonly Lazy<IReasoningAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReasoningAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IReasoningAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReasoningAgentService(this._client.WithOptions(modifier));
    }

    public ReasoningAgentService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ReasoningAgentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateCompletion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ReasoningAgentServiceWithRawResponse : IReasoningAgentServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReasoningAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReasoningAgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReasoningAgentServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> CreateCompletion(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, JsonElement>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> ListTypes(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, JsonElement>>(token)
                    .ConfigureAwait(false);
            }
        );
    }
}
