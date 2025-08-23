using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Swarms.Models.Agent.Batch;

/// <summary>
/// Run a batch of agents with the specified tasks using a thread pool.
/// </summary>
public sealed record class BatchRunParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<AgentCompletion> Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out JsonElement element))
                throw new ArgumentOutOfRangeException("body", "Missing required argument");

            return JsonSerializer.Deserialize<List<AgentCompletion>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("body");
        }
        set
        {
            this.BodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/agent/batch/completions"
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
