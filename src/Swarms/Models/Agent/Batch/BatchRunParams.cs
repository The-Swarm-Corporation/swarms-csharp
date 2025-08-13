using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Agent = Swarms.Models.Agent;
using Swarms = Swarms;

namespace Swarms.Models.Agent.Batch;

/// <summary>
/// Run a batch of agents with the specified tasks using a thread pool.
/// </summary>
public sealed record class BatchRunParams : Swarms::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<Agent::AgentCompletion> Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out JsonElement element))
                throw new ArgumentOutOfRangeException("body", "Missing required argument");

            return JsonSerializer.Deserialize<List<Agent::AgentCompletion>>(
                    element,
                    Swarms::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("body");
        }
        set { this.BodyProperties["body"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(Swarms::ISwarmsClientClient client)
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

    public void AddHeadersToRequest(HttpRequestMessage request, Swarms::ISwarmsClientClient client)
    {
        Swarms::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Swarms::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
