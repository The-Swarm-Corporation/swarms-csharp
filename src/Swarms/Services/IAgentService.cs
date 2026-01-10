using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Services.Agent;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batch { get; }

    /// <summary>
    /// Get all unique agent configurations that the user has created or used, without
    /// task details. Allows users to reuse agent configs with new tasks.
    /// </summary>
    Task<Dictionary<string, JsonElement>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run an agent with the specified task. Supports streaming when stream=True.
    /// </summary>
    Task<AgentRunResponse> Run(
        AgentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchServiceWithRawResponse Batch { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/agents/list`, but is otherwise the
    /// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/agent/completions`, but is otherwise the
    /// same as <see cref="IAgentService.Run(AgentRunParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentRunResponse>> Run(
        AgentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
