using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch.Batch;

namespace Swarms.Services.Client.AdvancedResearch.Batch;

public interface IBatchService
{
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
