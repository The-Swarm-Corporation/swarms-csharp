using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Services.Client;

public sealed class BatchedGridWorkflowService : IBatchedGridWorkflowService
{
    public IBatchedGridWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchedGridWorkflowService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public BatchedGridWorkflowService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<BatchedGridWorkflowCompleteWorkflowResponse> CompleteWorkflow(
        BatchedGridWorkflowCompleteWorkflowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BatchedGridWorkflowCompleteWorkflowParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BatchedGridWorkflowCompleteWorkflowResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
