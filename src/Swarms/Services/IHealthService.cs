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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IHealthServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IHealthService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IHealthServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IHealthServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /health`, but is otherwise the
    /// same as <see cref="IHealthService.Check(HealthCheckParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<HealthCheckResponse>> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
