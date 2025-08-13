using System;
using System.Net.Http;
using Swarms = Swarms;

namespace Swarms.Models.Swarms;

/// <summary>
/// Check the available swarm types.
/// </summary>
public sealed record class SwarmCheckAvailableParams : Swarms::ParamsBase
{
    public override Uri Url(Swarms::ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/swarms/available")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Swarms::ISwarmsClientClient client)
    {
        Swarms::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Swarms::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
