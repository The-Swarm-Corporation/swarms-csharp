using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Swarms;
using Swarms.Services.Swarms;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISwarmService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISwarmServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwarmService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batch { get; }

    /// <summary>
    /// Check the available swarm types.
    /// </summary>
    Task<SwarmCheckAvailableResponse> CheckAvailable(
        SwarmCheckAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all API request logs for all API keys associated with the user identified
    /// by the provided API key, excluding any logs that contain a client_ip field
    /// in their data.
    /// </summary>
    Task<SwarmGetLogsResponse> GetLogs(
        SwarmGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run a swarm with the specified task. Supports streaming when stream=True.
    /// </summary>
    Task<SwarmRunResponse> Run(
        SwarmRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISwarmService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISwarmServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwarmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchServiceWithRawResponse Batch { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/swarms/available`, but is otherwise the
    /// same as <see cref="ISwarmService.CheckAvailable(SwarmCheckAvailableParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwarmCheckAvailableResponse>> CheckAvailable(
        SwarmCheckAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/swarm/logs`, but is otherwise the
    /// same as <see cref="ISwarmService.GetLogs(SwarmGetLogsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwarmGetLogsResponse>> GetLogs(
        SwarmGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/swarm/completions`, but is otherwise the
    /// same as <see cref="ISwarmService.Run(SwarmRunParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SwarmRunResponse>> Run(
        SwarmRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
