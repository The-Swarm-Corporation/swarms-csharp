using System.Threading.Tasks;
using Swarms.Models.Agent.Batch;

namespace Swarms.Services.Agent.Batch;

public interface IBatchService
{
    /// <summary>
    /// Run a batch of agents with the specified tasks using a thread pool.
    /// </summary>
    Task<BatchRunResponse> Run(BatchRunParams parameters);
}
