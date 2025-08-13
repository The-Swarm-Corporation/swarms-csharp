using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms = Swarms;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(Swarms::ModelConverter<AgentSpec>))]
public sealed record class AgentSpec : Swarms::ModelBase, Swarms::IFromRaw<AgentSpec>
{
    /// <summary>
    /// The unique name assigned to the agent, which identifies its role and functionality
    /// within the swarm.
    /// </summary>
    public required string? AgentName
    {
        get
        {
            if (!this.Properties.TryGetValue("agent_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("agent_name", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["agent_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should automatically create prompts based
    /// on the task requirements.
    /// </summary>
    public bool? AutoGeneratePrompt
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_generate_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["auto_generate_prompt"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A detailed explanation of the agent's purpose, capabilities, and any specific
    /// tasks it is designed to perform.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should dynamically adjust its temperature
    /// based on the task.
    /// </summary>
    public bool? DynamicTemperatureEnabled
    {
        get
        {
            if (
                !this.Properties.TryGetValue("dynamic_temperature_enabled", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["dynamic_temperature_enabled"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Additional arguments to pass to the LLM such as top_p, frequency_penalty,
    /// presence_penalty, etc.
    /// </summary>
    public Dictionary<string, JsonElement>? LlmArgs
    {
        get
        {
            if (!this.Properties.TryGetValue("llm_args", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["llm_args"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum number of times the agent is allowed to repeat its task, enabling
    /// iterative processing if necessary.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this.Properties.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["max_loops"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum number of tokens that the agent is allowed to generate in its
    /// responses, limiting output length.
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("max_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["max_tokens"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The URL of the MCP server that the agent can use to complete its task.
    /// </summary>
    public string? McpURL
    {
        get
        {
            if (!this.Properties.TryGetValue("mcp_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["mcp_url"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the AI model that the agent will utilize for processing tasks
    /// and generating outputs. For example: gpt-4o, gpt-4o-mini, openai/o3-mini
    /// </summary>
    public string? ModelName
    {
        get
        {
            if (!this.Properties.TryGetValue("model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["model_name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The designated role of the agent within the swarm, which influences its behavior
    /// and interaction with other agents.
    /// </summary>
    public string? Role
    {
        get
        {
            if (!this.Properties.TryGetValue("role", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["role"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? StreamingOn
    {
        get
        {
            if (!this.Properties.TryGetValue("streaming_on", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["streaming_on"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The initial instruction or context provided to the agent, guiding its behavior
    /// and responses during execution.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            if (!this.Properties.TryGetValue("system_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["system_prompt"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A parameter that controls the randomness of the agent's output; lower values
    /// result in more deterministic responses.
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this.Properties.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["temperature"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A dictionary of tools that the agent can use to complete its task.
    /// </summary>
    public List<Dictionary<string, JsonElement>>? ToolsListDictionary
    {
        get
        {
            if (!this.Properties.TryGetValue("tools_list_dictionary", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["tools_list_dictionary"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.AgentName;
        _ = this.AutoGeneratePrompt;
        _ = this.Description;
        _ = this.DynamicTemperatureEnabled;
        if (this.LlmArgs != null)
        {
            foreach (var item in this.LlmArgs.Values)
            {
                _ = item;
            }
        }
        _ = this.MaxLoops;
        _ = this.MaxTokens;
        _ = this.McpURL;
        _ = this.ModelName;
        _ = this.Role;
        _ = this.StreamingOn;
        _ = this.SystemPrompt;
        _ = this.Temperature;
        foreach (var item in this.ToolsListDictionary ?? [])
        {
            foreach (var item1 in item.Values)
            {
                _ = item1;
            }
        }
    }

    public AgentSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentSpec(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AgentSpec FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AgentSpec(string? agentName)
        : this()
    {
        this.AgentName = agentName;
    }
}
