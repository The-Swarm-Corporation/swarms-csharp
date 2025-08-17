using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Swarms.Models.Agent.AgentRunParamsProperties;

namespace Swarms.Models.Agent;

/// <summary>
/// Run an agent with the specified task.
/// </summary>
public sealed record class AgentRunParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The configuration of the agent to be completed.
    /// </summary>
    public AgentSpec? AgentConfig
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("agent_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AgentSpec?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["agent_config"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a
    /// dictionary or a list of message objects.
    /// </summary>
    public History? History
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("history", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<History?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["history"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the agent's task or representation.
    /// </summary>
    public string? Img
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("img", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["img"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of image URLs that may be associated with the agent's task or representation.
    /// </summary>
    public List<string>? Imgs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("imgs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["imgs"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["stream"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The task to be completed by the agent.
    /// </summary>
    public string? Task
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["task"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/agent/completions")
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
