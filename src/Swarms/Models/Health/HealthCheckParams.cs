using System;
using System.Net.Http;
using Swarms = Swarms;

namespace Swarms.Models.Health;

/// <summary>
/// Health
/// </summary>
public sealed record class HealthCheckParams : Swarms::ParamsBase
{
    public override Uri Url(Swarms::ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/health")
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
