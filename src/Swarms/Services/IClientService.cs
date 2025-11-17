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
    IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateService Rate { get; }

    IAutoSwarmBuilderService AutoSwarmBuilder { get; }

    IAdvancedResearchService AdvancedResearch { get; }

    IToolService Tools { get; }

    IMarketplaceService Marketplace { get; }

    IBatchedGridWorkflowService BatchedGridWorkflow { get; }
}
