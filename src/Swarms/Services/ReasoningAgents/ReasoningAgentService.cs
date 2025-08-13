using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.ReasoningAgents;
using Swarms = Swarms;

namespace Swarms.Services.ReasoningAgents;

public sealed class ReasoningAgentService : IReasoningAgentService
{
    readonly Swarms::ISwarmsClientClient _client;

    public ReasoningAgentService(Swarms::ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams parameters
    )
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
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams parameters
    )
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
