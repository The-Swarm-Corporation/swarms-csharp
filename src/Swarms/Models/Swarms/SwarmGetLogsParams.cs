using System;
using System.Net.Http;

namespace Swarms.Models.Swarms;

/// <summary>
/// Get all API request logs for all API keys associated with the user identified
/// by the provided API key, excluding any logs that contain a client_ip field in
/// their data.
/// </summary>
public sealed record class SwarmGetLogsParams : ParamsBase
{
    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/logs")
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
