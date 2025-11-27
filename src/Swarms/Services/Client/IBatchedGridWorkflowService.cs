using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchedGridWorkflowService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchedGridWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Complete a batched grid workflow with the specified input data. Enables you
    /// to run a grid workflow with multiple agents and tasks in a single request.
    /// </summary>
    Task<BatchedGridWorkflowCompleteWorkflowResponse> CompleteWorkflow(
        BatchedGridWorkflowCompleteWorkflowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
