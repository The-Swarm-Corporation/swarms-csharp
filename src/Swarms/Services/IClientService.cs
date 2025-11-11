using System;
using Swarms.Core;
using Swarms.Services.Client;

namespace Swarms.Services;

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
