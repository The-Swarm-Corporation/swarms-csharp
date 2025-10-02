using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Agent.Batch;

namespace Swarms.Services.Agent.Batch;

public sealed class BatchService : IBatchService
{
    readonly ISwarmsClientClient _client;

    public BatchService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<BatchRunResponse> Run(BatchRunParams parameters)
    {
        HttpRequest<BatchRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BatchRunResponse>().ConfigureAwait(false);
    }
}
