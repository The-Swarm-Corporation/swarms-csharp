using System;
using System.Net.Http;

namespace Swarms.Models.ReasoningAgents;

/// <summary>
/// Get the types of reasoning agents available.
/// </summary>
public sealed record class ReasoningAgentListTypesParams : ParamsBase
{
    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/reasoning-agent/types")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, ISwarmsClientClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
