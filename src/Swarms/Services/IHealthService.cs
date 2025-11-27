using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Health;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IHealthService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHealthService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Health
    /// </summary>
    Task<HealthCheckResponse> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
