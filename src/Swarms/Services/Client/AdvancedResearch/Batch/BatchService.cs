using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch.Batch;

namespace Swarms.Services.Client.AdvancedResearch.Batch;

public sealed class BatchService : IBatchService
{
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public BatchService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<List<BatchCreateCompletionResponse>> CreateCompletion(
        BatchCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<List<BatchCreateCompletionResponse>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in deserializedResponse)
            {
                item.Validate();
            }
        }
        return deserializedResponse;
    }
}
