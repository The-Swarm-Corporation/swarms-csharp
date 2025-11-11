using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Services.Client.BatchedGridWorkflow;

public interface IBatchedGridWorkflowService
{
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
