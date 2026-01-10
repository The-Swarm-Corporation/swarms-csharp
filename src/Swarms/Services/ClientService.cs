using System;
using Swarms.Core;
using Swarms.Services.Client;

namespace Swarms.Services;

/// <inheritdoc/>
public sealed class ClientService : IClientService
{
    readonly Lazy<IClientServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClientServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClientService(this._client.WithOptions(modifier));
    }

    public ClientService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ClientServiceWithRawResponse(client.WithRawResponse));
        _rate = new(() => new RateService(client));
        _autoSwarmBuilder = new(() => new AutoSwarmBuilderService(client));
        _advancedResearch = new(() => new AdvancedResearchService(client));
        _tools = new(() => new ToolService(client));
        _marketplace = new(() => new MarketplaceService(client));
        _batchedGridWorkflow = new(() => new BatchedGridWorkflowService(client));
        _graphWorkflow = new(() => new GraphWorkflowService(client));
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

    readonly Lazy<IGraphWorkflowService> _graphWorkflow;
    public IGraphWorkflowService GraphWorkflow
    {
        get { return _graphWorkflow.Value; }
    }
}

/// <inheritdoc/>
public sealed class ClientServiceWithRawResponse : IClientServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClientServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClientServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClientServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;

        _rate = new(() => new RateServiceWithRawResponse(client));
        _autoSwarmBuilder = new(() => new AutoSwarmBuilderServiceWithRawResponse(client));
        _advancedResearch = new(() => new AdvancedResearchServiceWithRawResponse(client));
        _tools = new(() => new ToolServiceWithRawResponse(client));
        _marketplace = new(() => new MarketplaceServiceWithRawResponse(client));
        _batchedGridWorkflow = new(() => new BatchedGridWorkflowServiceWithRawResponse(client));
        _graphWorkflow = new(() => new GraphWorkflowServiceWithRawResponse(client));
    }

    readonly Lazy<IRateServiceWithRawResponse> _rate;
    public IRateServiceWithRawResponse Rate
    {
        get { return _rate.Value; }
    }

    readonly Lazy<IAutoSwarmBuilderServiceWithRawResponse> _autoSwarmBuilder;
    public IAutoSwarmBuilderServiceWithRawResponse AutoSwarmBuilder
    {
        get { return _autoSwarmBuilder.Value; }
    }

    readonly Lazy<IAdvancedResearchServiceWithRawResponse> _advancedResearch;
    public IAdvancedResearchServiceWithRawResponse AdvancedResearch
    {
        get { return _advancedResearch.Value; }
    }

    readonly Lazy<IToolServiceWithRawResponse> _tools;
    public IToolServiceWithRawResponse Tools
    {
        get { return _tools.Value; }
    }

    readonly Lazy<IMarketplaceServiceWithRawResponse> _marketplace;
    public IMarketplaceServiceWithRawResponse Marketplace
    {
        get { return _marketplace.Value; }
    }

    readonly Lazy<IBatchedGridWorkflowServiceWithRawResponse> _batchedGridWorkflow;
    public IBatchedGridWorkflowServiceWithRawResponse BatchedGridWorkflow
    {
        get { return _batchedGridWorkflow.Value; }
    }

    readonly Lazy<IGraphWorkflowServiceWithRawResponse> _graphWorkflow;
    public IGraphWorkflowServiceWithRawResponse GraphWorkflow
    {
        get { return _graphWorkflow.Value; }
    }
}
