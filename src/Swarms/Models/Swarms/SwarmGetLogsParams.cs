using System;
using System.Net.Http;
using Swarms = Swarms;

namespace Swarms.Models.Swarms;

/// <summary>
/// Get all API request logs for all API keys associated with the user identified
/// by the provided API key, excluding any logs that contain a client_ip field in
/// their data.
/// </summary>
public sealed record class SwarmGetLogsParams : Swarms::ParamsBase
{
    public override Uri Url(Swarms::ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/logs")
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
