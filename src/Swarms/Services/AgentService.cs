using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Services.Agent;

namespace Swarms.Services;

/// <inheritdoc/>
public sealed class AgentService : IAgentService
{
    readonly Lazy<IAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentService(this._client.WithOptions(modifier));
    }

    public AgentService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentServiceWithRawResponse(client.WithRawResponse));
        _batch = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentRunResponse> Run(
        AgentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AgentServiceWithRawResponse : IAgentServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;

        _batch = new(() => new BatchServiceWithRawResponse(client));
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batch;
    public IBatchServiceWithRawResponse Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentListParams> request = new()
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

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentRunResponse>> Run(
        AgentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentRunParams> request = new()
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
                    .Deserialize<AgentRunResponse>(token)
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
