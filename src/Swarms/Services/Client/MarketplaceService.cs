using System;
using Swarms.Core;

namespace Swarms.Services.Client;

public sealed class MarketplaceService : IMarketplaceService
{
    public IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketplaceService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public MarketplaceService(ISwarmsClientClient client)
    {
        _client = client;
    }
}
