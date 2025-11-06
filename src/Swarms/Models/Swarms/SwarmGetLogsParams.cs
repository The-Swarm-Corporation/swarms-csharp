using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Swarms.Core;

namespace Swarms.Models.Swarms;

/// <summary>
/// Get all API request logs for all API keys associated with the user identified
/// by the provided API key, excluding any logs that contain a client_ip field in
/// their data.
/// </summary>
public sealed record class SwarmGetLogsParams : ParamsBase
{
    public SwarmGetLogsParams() { }

    public SwarmGetLogsParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmGetLogsParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static SwarmGetLogsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/logs")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        ISwarmsClientClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
