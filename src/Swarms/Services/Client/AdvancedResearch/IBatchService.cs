using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch.Batch;

namespace Swarms.Services.Client.AdvancedResearch;

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
    /// Execute multiple advanced research sessions concurrently with independent
    /// configurations for high-throughput research workflows.
    /// </summary>
    Task<List<BatchCreateCompletionResponse>> CreateCompletion(
        BatchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    );
}
