using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent.Batch;

namespace Swarms.Services.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Run a batch of agents with the specified tasks using a thread pool.
    /// </summary>
    Task<BatchRunResponse> Run(
        BatchRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
