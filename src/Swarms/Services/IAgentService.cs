using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Services.Agent;

namespace Swarms.Services;

public interface IAgentService
{
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
