using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch;
using Swarms.Services.Client.AdvancedResearch.Batch;

namespace Swarms.Services.Client.AdvancedResearch;

public interface IAdvancedResearchService
{
    IAdvancedResearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batch { get; }

    /// <summary>
    /// Execute comprehensive research sessions with multi-source data collection,
    /// analysis, and synthesis capabilities.
    /// </summary>
    Task<AdvancedResearchCreateCompletionResponse> CreateCompletion(
        AdvancedResearchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    );
}
