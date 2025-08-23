using System.Threading.Tasks;
using Swarms.Models.Agent;
using Swarms.Services.Agent.Batch;

namespace Swarms.Services.Agent;

public interface IAgentService
{
    IBatchService Batch { get; }

    /// <summary>
    /// Run an agent with the specified task.
    /// </summary>
    Task<AgentRunResponse> Run(AgentRunParams? parameters = null);
}
