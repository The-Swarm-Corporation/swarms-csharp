using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Tools;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IToolService
{
    IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve comprehensive information about all available tools and capabilities
    /// supported by the Swarms API.
    /// </summary>
    Task<ToolListAvailableResponse> ListAvailable(
        ToolListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
