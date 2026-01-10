using System;
using Swarms.Core;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class MarketplaceService : IMarketplaceService
{
    readonly Lazy<IMarketplaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMarketplaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketplaceService(this._client.WithOptions(modifier));
    }

    public MarketplaceService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MarketplaceServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class MarketplaceServiceWithRawResponse : IMarketplaceServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMarketplaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MarketplaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MarketplaceServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }
}
