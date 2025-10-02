using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Core;
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
        ReasoningAgentCreateCompletionParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<ReasoningAgentCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Dictionary<string, JsonElement>>().ConfigureAwait(false);
    }

    public async Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<ReasoningAgentListTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Dictionary<string, JsonElement>>().ConfigureAwait(false);
    }
}
