using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Agent;
using Batch = Swarms.Services.Agent.Batch;

namespace Swarms.Services.Agent;

public sealed class AgentService : IAgentService
{
    readonly ISwarmsClientClient _client;

    public AgentService(ISwarmsClientClient client)
    {
        _client = client;
        _batch = new(() => new Batch::BatchService(client));
    }

    readonly Lazy<Batch::IBatchService> _batch;
    public Batch::IBatchService Batch
    {
        get { return _batch.Value; }
    }

    public async Task<AgentRunResponse> Run(AgentRunParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<AgentRunResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
