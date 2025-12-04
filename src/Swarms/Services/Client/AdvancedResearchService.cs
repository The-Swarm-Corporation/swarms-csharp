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
    /// <inheritdoc/>
    public IAdvancedResearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AdvancedResearchService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public AdvancedResearchService(ISwarmsClientClient client)
    {
        _client = client;
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
        HttpRequest<AdvancedResearchCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AdvancedResearchCreateCompletionResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
