using System;
using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Services.Agent.Batch;

namespace Swarms.Services.Agent;

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

    public async Task<AgentRunResponse> Run(AgentRunParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AgentRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AgentRunResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
