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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutoSwarmBuilderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

/// <summary>
/// A view of <see cref="IAutoSwarmBuilderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutoSwarmBuilderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoSwarmBuilderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/auto-swarm-builder/completions`, but is otherwise the
    /// same as <see cref="IAutoSwarmBuilderService.CreateCompletion(AutoSwarmBuilderCreateCompletionParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutoSwarmBuilderCreateCompletionResponse>> CreateCompletion(
        AutoSwarmBuilderCreateCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/auto-swarm-builder/execution-types`, but is otherwise the
    /// same as <see cref="IAutoSwarmBuilderService.ListExecutionTypes(AutoSwarmBuilderListExecutionTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<string>>> ListExecutionTypes(
        AutoSwarmBuilderListExecutionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
