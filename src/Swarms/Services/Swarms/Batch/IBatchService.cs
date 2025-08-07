using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms.Batch;

namespace Swarms.Services.Swarms.Batch;

public interface IBatchService
{
    /// <summary>
    /// Run a batch of swarms with the specified tasks using a thread pool.
    /// </summary>
    Task<List<Dictionary<string, JsonElement>>> Run(BatchRunParams parameters);
}
