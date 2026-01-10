using System;
using Swarms.Core;
using Swarms.Services.Client;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClientService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClientServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateService Rate { get; }

    IAutoSwarmBuilderService AutoSwarmBuilder { get; }

    IAdvancedResearchService AdvancedResearch { get; }

    IToolService Tools { get; }

    IMarketplaceService Marketplace { get; }

    IBatchedGridWorkflowService BatchedGridWorkflow { get; }

    IGraphWorkflowService GraphWorkflow { get; }
}

/// <summary>
/// A view of <see cref="IClientService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClientServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClientServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateServiceWithRawResponse Rate { get; }

    IAutoSwarmBuilderServiceWithRawResponse AutoSwarmBuilder { get; }

    IAdvancedResearchServiceWithRawResponse AdvancedResearch { get; }

    IToolServiceWithRawResponse Tools { get; }

    IMarketplaceServiceWithRawResponse Marketplace { get; }

    IBatchedGridWorkflowServiceWithRawResponse BatchedGridWorkflow { get; }

    IGraphWorkflowServiceWithRawResponse GraphWorkflow { get; }
}
