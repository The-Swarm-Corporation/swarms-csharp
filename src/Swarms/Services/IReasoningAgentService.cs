using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services;

public interface IReasoningAgentService
{
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
