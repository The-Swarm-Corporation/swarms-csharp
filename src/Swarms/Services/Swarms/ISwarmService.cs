using System.Threading.Tasks;
using Swarms.Models.Swarms;
using Batch = Swarms.Services.Swarms.Batch;

namespace Swarms.Services.Swarms;

public interface ISwarmService
{
    Batch::IBatchService Batch { get; }

    /// <summary>
    /// Check the available swarm types.
    /// </summary>
    Task<SwarmCheckAvailableResponse> CheckAvailable(SwarmCheckAvailableParams parameters);

    /// <summary>
    /// Get all API request logs for all API keys associated with the user identified
    /// by the provided API key, excluding any logs that contain a client_ip field
    /// in their data.
    /// </summary>
    Task<SwarmGetLogsResponse> GetLogs(SwarmGetLogsParams parameters);

    /// <summary>
    /// Run a swarm with the specified task.
    /// </summary>
    Task<SwarmRunResponse> Run(SwarmRunParams parameters);
}
