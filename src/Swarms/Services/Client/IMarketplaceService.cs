using System;
using Swarms.Core;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMarketplaceService
{
    IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
