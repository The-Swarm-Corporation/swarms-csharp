using System;
using Swarms.Core;
using Swarms.Services.Client.AdvancedResearch;
using Swarms.Services.Client.AutoSwarmBuilder;
using Swarms.Services.Client.BatchedGridWorkflow;
using Swarms.Services.Client.Marketplace;
using Swarms.Services.Client.Rate;
using Swarms.Services.Client.Tools;

namespace Swarms.Services.Client;

public sealed class ClientService : IClientService
{
    public IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClientService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public ClientService(ISwarmsClientClient client)
    {
        _client = client;
        _rate = new(() => new RateService(client));
        _autoSwarmBuilder = new(() => new AutoSwarmBuilderService(client));
        _advancedResearch = new(() => new AdvancedResearchService(client));
        _tools = new(() => new ToolService(client));
        _marketplace = new(() => new MarketplaceService(client));
        _batchedGridWorkflow = new(() => new BatchedGridWorkflowService(client));
    }

    readonly Lazy<IRateService> _rate;
    public IRateService Rate
    {
        get { return _rate.Value; }
    }

    readonly Lazy<IAutoSwarmBuilderService> _autoSwarmBuilder;
    public IAutoSwarmBuilderService AutoSwarmBuilder
    {
        get { return _autoSwarmBuilder.Value; }
    }

    readonly Lazy<IAdvancedResearchService> _advancedResearch;
    public IAdvancedResearchService AdvancedResearch
    {
        get { return _advancedResearch.Value; }
    }

    readonly Lazy<IToolService> _tools;
    public IToolService Tools
    {
        get { return _tools.Value; }
    }

    readonly Lazy<IMarketplaceService> _marketplace;
    public IMarketplaceService Marketplace
    {
        get { return _marketplace.Value; }
    }

    readonly Lazy<IBatchedGridWorkflowService> _batchedGridWorkflow;
    public IBatchedGridWorkflowService BatchedGridWorkflow
    {
        get { return _batchedGridWorkflow.Value; }
    }
}
