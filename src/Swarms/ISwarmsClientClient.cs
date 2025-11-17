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
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISwarmsClientClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string? APIKey { get; init; }

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

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
