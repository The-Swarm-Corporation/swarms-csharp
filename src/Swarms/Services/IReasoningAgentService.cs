using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReasoningAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReasoningAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReasoningAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Run a reasoning agent with the specified task.
    /// </summary>
    Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the types of reasoning agents available.
    /// </summary>
    Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReasoningAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReasoningAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReasoningAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/reasoning-agent/completions`, but is otherwise the
    /// same as <see cref="IReasoningAgentService.CreateCompletion(ReasoningAgentCreateCompletionParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> CreateCompletion(
        ReasoningAgentCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/reasoning-agent/types`, but is otherwise the
    /// same as <see cref="IReasoningAgentService.ListTypes(ReasoningAgentListTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
