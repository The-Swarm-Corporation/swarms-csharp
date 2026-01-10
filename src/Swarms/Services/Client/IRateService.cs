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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRateServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IRateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/rate/limits`, but is otherwise the
    /// same as <see cref="IRateService.GetLimits(RateGetLimitsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RateGetLimitsResponse>> GetLimits(
        RateGetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
