using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AutoSwarmBuilder;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAutoSwarmBuilderService
{
    IAutoSwarmBuilderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Generate and orchestrate agent swarms autonomously using AI-powered swarm
    /// composition and task decomposition.
    /// </summary>
    Task<AutoSwarmBuilderCreateCompletionResponse> CreateCompletion(
        AutoSwarmBuilderCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all available execution types and return formats for the Auto Swarm
    /// Builder endpoint.
    /// </summary>
    Task<List<string>> ListExecutionTypes(
        AutoSwarmBuilderListExecutionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
