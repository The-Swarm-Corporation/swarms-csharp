using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent.Batch;

namespace Swarms.Services.Agent;

public interface IBatchService
{
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Run a batch of agents with the specified tasks using a thread pool.
    /// </summary>
    Task<BatchRunResponse> Run(
        BatchRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
