using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.GraphWorkflow;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class GraphWorkflowService : IGraphWorkflowService
{
    readonly Lazy<IGraphWorkflowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGraphWorkflowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IGraphWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GraphWorkflowService(this._client.WithOptions(modifier));
    }

    public GraphWorkflowService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new GraphWorkflowServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<GraphWorkflowExecuteWorkflowResponse> ExecuteWorkflow(
        GraphWorkflowExecuteWorkflowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ExecuteWorkflow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GraphWorkflowServiceWithRawResponse : IGraphWorkflowServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGraphWorkflowServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GraphWorkflowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GraphWorkflowServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GraphWorkflowExecuteWorkflowResponse>> ExecuteWorkflow(
        GraphWorkflowExecuteWorkflowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GraphWorkflowExecuteWorkflowParams> request = new()
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
                    .Deserialize<GraphWorkflowExecuteWorkflowResponse>(token)
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
