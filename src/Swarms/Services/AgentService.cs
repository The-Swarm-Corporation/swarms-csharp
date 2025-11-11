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

public sealed class AgentService : IAgentService
{
    public IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public AgentService(ISwarmsClientClient client)
    {
        _client = client;
        _batch = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    public async Task<Dictionary<string, JsonElement>> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response
            .Deserialize<Dictionary<string, JsonElement>>(cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<AgentRunResponse> Run(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AgentRunResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
