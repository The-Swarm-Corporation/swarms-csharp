using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Swarms.Batch;

namespace Swarms.Services.Swarms;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Run a batch of swarms with the specified tasks using a thread pool.
    /// </summary>
    Task<List<Dictionary<string, JsonElement>>> Run(
        BatchRunParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/swarm/batch/completions`, but is otherwise the
    /// same as <see cref="IBatchService.Run(BatchRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Dictionary<string, JsonElement>>>> Run(
        BatchRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
