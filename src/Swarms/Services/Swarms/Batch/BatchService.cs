using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Swarms.Batch;

namespace Swarms.Services.Swarms.Batch;

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

    public async Task<List<Dictionary<string, JsonElement>>> Run(BatchRunParams parameters)
    {
        HttpRequest<BatchRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<List<Dictionary<string, JsonElement>>>()
            .ConfigureAwait(false);
    }
}
