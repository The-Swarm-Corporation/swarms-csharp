using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class BatchedGridWorkflowService : IBatchedGridWorkflowService
{
    readonly Lazy<IBatchedGridWorkflowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchedGridWorkflowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IBatchedGridWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchedGridWorkflowService(this._client.WithOptions(modifier));
    }

    public BatchedGridWorkflowService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new BatchedGridWorkflowServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BatchedGridWorkflowCompleteWorkflowResponse> CompleteWorkflow(
        BatchedGridWorkflowCompleteWorkflowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CompleteWorkflow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BatchedGridWorkflowServiceWithRawResponse
    : IBatchedGridWorkflowServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchedGridWorkflowServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BatchedGridWorkflowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchedGridWorkflowServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchedGridWorkflowCompleteWorkflowResponse>> CompleteWorkflow(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BatchedGridWorkflowCompleteWorkflowResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
