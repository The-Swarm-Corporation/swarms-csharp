using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Swarms.Models.Agent;
using Swarms.Models.Swarms.SwarmRunParamsProperties;

namespace Swarms.Models.Swarms;

/// <summary>
/// Run a swarm with the specified task.
/// </summary>
public sealed record class SwarmRunParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// A list of agents or specifications that define the agents participating in
    /// the swarm.
    /// </summary>
    public List<AgentSpec>? Agents
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("agents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AgentSpec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["agents"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A comprehensive description of the swarm's objectives, capabilities, and
    /// intended outcomes.
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
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "heavy_swarm_loops_per_agent",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["heavy_swarm_loops_per_agent"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The model name to use for the question agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmQuestionAgentModelName
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "heavy_swarm_question_agent_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["heavy_swarm_question_agent_model_name"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The model name to use for the worker agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmWorkerModelName
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "heavy_swarm_worker_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["heavy_swarm_worker_model_name"] =
                JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
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
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
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
    /// A list of messages that the swarm should complete.
    /// </summary>
    public Messages? Messages
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("messages", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Messages?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["messages"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the swarm, which serves as an identifier for the group of agents
    /// and their collective task.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("rearrange_flow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["rearrange_flow"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Guidelines or constraints that govern the behavior and interactions of the
    /// agents within the swarm.
    /// </summary>
    public string? Rules
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["rules"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or
    /// 'flex' for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["service_tier"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the swarm should stream its output.
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
    /// The classification of the swarm, indicating its operational style and methodology.
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
    /// The specific task or objective that the swarm is designed to accomplish.
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

    /// <summary>
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public List<string>? Tasks
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tasks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["tasks"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(ISwarmsClientClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/completions")
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
