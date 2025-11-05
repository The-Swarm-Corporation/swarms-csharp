using System;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Services.Agent.Batch;

namespace Swarms.Services.Agent;

public interface IAgentService
{
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batch { get; }

    /// <summary>
    /// Run an agent with the specified task. Supports streaming when stream=True.
    /// </summary>
    Task<AgentRunResponse> Run(AgentRunParams? parameters = null);
}
