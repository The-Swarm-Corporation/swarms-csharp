using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Marketplace;

namespace Swarms.Services.Client.Marketplace;

public interface IMarketplaceService
{
    IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve free agents from the marketplace.
    /// </summary>
    Task<MarketplaceListAgentsResponse> ListAgents(
        MarketplaceListAgentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
