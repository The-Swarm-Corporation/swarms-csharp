using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

namespace Swarms.Models.ReasoningAgents;

/// <summary>
/// Run a reasoning agent with the specified task.
/// </summary>
public sealed record class ReasoningAgentCreateCompletionParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The unique name assigned to the reasoning agent.
    /// </summary>
    public string? AgentName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("agent_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["agent_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A detailed explanation of the reasoning agent's purpose and capabilities.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum number of times the reasoning agent is allowed to repeat its task.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["max_loops"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The memory capacity for the reasoning agent.
    /// </summary>
    public long? MemoryCapacity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("memory_capacity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["memory_capacity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the AI model that the reasoning agent will utilize.
    /// </summary>
    public string? ModelName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["model_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of knowledge items to use for the reasoning agent.
    /// </summary>
    public long? NumKnowledgeItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("num_knowledge_items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["num_knowledge_items"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The number of samples to generate for the reasoning agent.
    /// </summary>
    public long? NumSamples
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("num_samples", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["num_samples"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of output format for the reasoning agent.
    /// </summary>
    public OutputType? OutputType
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("output_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OutputType?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["output_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of reasoning swarm to use (e.g., reasoning duo, self-consistency, IRE).
    /// </summary>
    public SwarmType? SwarmType
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SwarmType?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["swarm_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The initial instruction or context provided to the reasoning agent.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("system_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["system_prompt"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The task to be completed by the reasoning agent.
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
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/reasoning-agent/completions"
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
