using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRateService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the rate limits and current usage for the user associated with the provided
    /// API key.
    /// </summary>
    Task<RateGetLimitsResponse> GetLimits(
        RateGetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
