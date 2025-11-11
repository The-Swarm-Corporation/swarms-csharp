using System;
using Swarms.Core;
using Swarms.Services.Client.AdvancedResearch;
using Swarms.Services.Client.AutoSwarmBuilder;
using Swarms.Services.Client.BatchedGridWorkflow;
using Swarms.Services.Client.Marketplace;
using Swarms.Services.Client.Rate;
using Swarms.Services.Client.Tools;

namespace Swarms.Services.Client;

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
