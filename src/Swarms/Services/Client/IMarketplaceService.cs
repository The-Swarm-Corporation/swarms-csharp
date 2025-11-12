using System;
using Swarms.Core;

namespace Swarms.Services.Client;

public interface IMarketplaceService
{
    IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
