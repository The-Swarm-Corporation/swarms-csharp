using System.Threading.Tasks;
using Swarms.Models.Agent;
using Batch = Swarms.Services.Agent.Batch;

namespace Swarms.Services.Agent;

public interface IAgentService
{
    Batch::IBatchService Batch { get; }

    /// <summary>
    /// Run an agent with the specified task.
    /// </summary>
    Task<AgentRunResponse> Run(AgentRunParams parameters);
}
