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
