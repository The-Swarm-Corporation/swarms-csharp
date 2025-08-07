using System;
using System.Net.Http;

namespace Swarms.Models.Client.Rate;

/// <summary>
/// Get the rate limits and current usage for the user associated with the provided
/// API key.
/// </summary>
public sealed record class RateGetLimitsParams : ParamsBase
{
    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/rate/limits")
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
