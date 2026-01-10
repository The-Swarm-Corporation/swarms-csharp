using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch;
using Swarms.Services.Client.AdvancedResearch;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAdvancedResearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAdvancedResearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

/// <summary>
/// A view of <see cref="IAdvancedResearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAdvancedResearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdvancedResearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IBatchServiceWithRawResponse Batch { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/advanced-research/completions`, but is otherwise the
    /// same as <see cref="IAdvancedResearchService.CreateCompletion(AdvancedResearchCreateCompletionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AdvancedResearchCreateCompletionResponse>> CreateCompletion(
        AdvancedResearchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    );
}
