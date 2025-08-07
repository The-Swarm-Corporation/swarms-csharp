using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services.ReasoningAgents;

public sealed class ReasoningAgentService : IReasoningAgentService
{
    readonly ISwarmsClientClient _client;

    public ReasoningAgentService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams parameters
    )
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams parameters
    )
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
