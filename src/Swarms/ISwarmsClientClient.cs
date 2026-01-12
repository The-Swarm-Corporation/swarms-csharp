using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models;
using Swarms.Services;

namespace Swarms;

/// <summary>
/// A client for interacting with the Swarms Client REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISwarmsClientClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISwarmsClientClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwarmsClientClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHealthService Health { get; }

    IAgentService Agent { get; }

    IModelService Models { get; }

    ISwarmService Swarms { get; }

    IReasoningAgentService ReasoningAgents { get; }

    IClientService Client { get; }

    /// <summary>
    /// Root
    /// </summary>
    Task<JsonElement> GetRoot(
        ClientGetRootParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISwarmsClientClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ISwarmsClientClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISwarmsClientClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IHealthServiceWithRawResponse Health { get; }

    IAgentServiceWithRawResponse Agent { get; }

    IModelServiceWithRawResponse Models { get; }

    ISwarmServiceWithRawResponse Swarms { get; }

    IReasoningAgentServiceWithRawResponse ReasoningAgents { get; }

    IClientServiceWithRawResponse Client { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /`, but is otherwise the
    /// same as <see cref="ISwarmsClientClient.GetRoot(ClientGetRootParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> GetRoot(
        ClientGetRootParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to the Swarms Client REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
