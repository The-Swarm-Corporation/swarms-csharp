using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch;
using Swarms.Services.Client.AdvancedResearch;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class AdvancedResearchService : IAdvancedResearchService
{
    readonly Lazy<IAdvancedResearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAdvancedResearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public IAdvancedResearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AdvancedResearchService(this._client.WithOptions(modifier));
    }

    public AdvancedResearchService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AdvancedResearchServiceWithRawResponse(client.WithRawResponse)
        );
        _batch = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<AdvancedResearchCreateCompletionResponse> CreateCompletion(
        AdvancedResearchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateCompletion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AdvancedResearchServiceWithRawResponse : IAdvancedResearchServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAdvancedResearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AdvancedResearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AdvancedResearchServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;

        _batch = new(() => new BatchServiceWithRawResponse(client));
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batch;
    public IBatchServiceWithRawResponse Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdvancedResearchCreateCompletionResponse>> CreateCompletion(
        AdvancedResearchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AdvancedResearchCreateCompletionParams> request = new()
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
                    .Deserialize<AdvancedResearchCreateCompletionResponse>(token)
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
