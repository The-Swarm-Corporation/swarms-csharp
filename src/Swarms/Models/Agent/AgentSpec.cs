using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(ModelConverter<AgentSpec>))]
public sealed record class AgentSpec : ModelBase, IFromRaw<AgentSpec>
{
    /// <summary>
    /// The unique name assigned to the agent, which identifies its role and functionality
    /// within the swarm.
    /// </summary>
    public required string? AgentName
    {
        get
        {
            if (!this._rawData.TryGetValue("agent_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["agent_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A flag indicating whether the agent should automatically create prompts based
    /// on the task requirements.
    /// </summary>
    public bool? AutoGeneratePrompt
    {
        get
        {
            if (!this._rawData.TryGetValue("auto_generate_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["auto_generate_prompt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A detailed explanation of the agent's purpose, capabilities, and any specific
    /// tasks it is designed to perform.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A flag indicating whether the agent should dynamically adjust its temperature
    /// based on the task.
    /// </summary>
    public bool? DynamicTemperatureEnabled
    {
        get
        {
            if (!this._rawData.TryGetValue("dynamic_temperature_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["dynamic_temperature_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("llm_args", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["llm_args"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of times the agent is allowed to repeat its task, enabling
    /// iterative processing if necessary.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this._rawData.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of tokens that the agent is allowed to generate in its
    /// responses, limiting output length.
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("max_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["max_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The MCP connection to use for the agent.
    /// </summary>
    public McpConfig? McpConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("mcp_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<McpConfig?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["mcp_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The MCP connections to use for the agent. This is a list of MCP connections.
    /// Includes multiple MCP connections.
    /// </summary>
    public McpConfigs? McpConfigs
    {
        get
        {
            if (!this._rawData.TryGetValue("mcp_configs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<McpConfigs?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["mcp_configs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The URL of the MCP server that the agent can use to complete its task.
    /// </summary>
    public string? McpURL
    {
        get
        {
            if (!this._rawData.TryGetValue("mcp_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["mcp_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the AI model that the agent will utilize for processing tasks
    /// and generating outputs. For example: gpt-4o, gpt-4o-mini, openai/o3-mini
    /// </summary>
    public string? ModelName
    {
        get
        {
            if (!this._rawData.TryGetValue("model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["model_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The effort to put into reasoning.
    /// </summary>
    public string? ReasoningEffort
    {
        get
        {
            if (!this._rawData.TryGetValue("reasoning_effort", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reasoning_effort"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A parameter enabling an agent to use reasoning.
    /// </summary>
    public bool? ReasoningEnabled
    {
        get
        {
            if (!this._rawData.TryGetValue("reasoning_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["reasoning_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The designated role of the agent within the swarm, which influences its behavior
    /// and interaction with other agents.
    /// </summary>
    public string? Role
    {
        get
        {
            if (!this._rawData.TryGetValue("role", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["role"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? StreamingOn
    {
        get
        {
            if (!this._rawData.TryGetValue("streaming_on", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["streaming_on"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The initial instruction or context provided to the agent, guiding its behavior
    /// and responses during execution.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            if (!this._rawData.TryGetValue("system_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["system_prompt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A parameter that controls the randomness of the agent's output; lower values
    /// result in more deterministic responses.
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this._rawData.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["temperature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of tokens to use for thinking.
    /// </summary>
    public long? ThinkingTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("thinking_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["thinking_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A parameter enabling an agent to summarize tool calls.
    /// </summary>
    public bool? ToolCallSummary
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_call_summary", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tool_call_summary"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A dictionary of tools that the agent can use to complete its task.
    /// </summary>
    public List<Dictionary<string, JsonElement>>? ToolsListDictionary
    {
        get
        {
            if (!this._rawData.TryGetValue("tools_list_dictionary", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["tools_list_dictionary"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AgentName;
        _ = this.AutoGeneratePrompt;
        _ = this.Description;
        _ = this.DynamicTemperatureEnabled;
        _ = this.LlmArgs;
        _ = this.MaxLoops;
        _ = this.MaxTokens;
        this.McpConfig?.Validate();
        this.McpConfigs?.Validate();
        _ = this.McpURL;
        _ = this.ModelName;
        _ = this.ReasoningEffort;
        _ = this.ReasoningEnabled;
        _ = this.Role;
        _ = this.StreamingOn;
        _ = this.SystemPrompt;
        _ = this.Temperature;
        _ = this.ThinkingTokens;
        _ = this.ToolCallSummary;
        _ = this.ToolsListDictionary;
    }

    public AgentSpec() { }

    public AgentSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AgentSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentSpec(string? agentName)
        : this()
    {
        this.AgentName = agentName;
    }
}

/// <summary>
/// The MCP connection to use for the agent.
/// </summary>
[JsonConverter(typeof(ModelConverter<McpConfig>))]
public sealed record class McpConfig : ModelBase, IFromRaw<McpConfig>
{
    /// <summary>
    /// Authentication token for accessing the MCP server
    /// </summary>
    public string? AuthorizationToken
    {
        get
        {
            if (!this._rawData.TryGetValue("authorization_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["authorization_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Headers to send to the MCP server
    /// </summary>
    public Dictionary<string, string>? Headers
    {
        get
        {
            if (!this._rawData.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timeout for the MCP server
    /// </summary>
    public long? Timeout
    {
        get
        {
            if (!this._rawData.TryGetValue("timeout", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["timeout"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Dictionary containing configuration settings for MCP tools
    /// </summary>
    public Dictionary<string, JsonElement>? ToolConfigurations
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_configurations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["tool_configurations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The transport protocol to use for the MCP server
    /// </summary>
    public string? Transport
    {
        get
        {
            if (!this._rawData.TryGetValue("transport", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["transport"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of connection, defaults to 'mcp'
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The URL endpoint for the MCP server
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AuthorizationToken;
        _ = this.Headers;
        _ = this.Timeout;
        _ = this.ToolConfigurations;
        _ = this.Transport;
        _ = this.Type;
        _ = this.URL;
    }

    public McpConfig() { }

    public McpConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static McpConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// The MCP connections to use for the agent. This is a list of MCP connections. Includes
/// multiple MCP connections.
/// </summary>
[JsonConverter(typeof(ModelConverter<McpConfigs>))]
public sealed record class McpConfigs : ModelBase, IFromRaw<McpConfigs>
{
    /// <summary>
    /// List of MCP connections
    /// </summary>
    public required List<Connection> Connections
    {
        get
        {
            if (!this._rawData.TryGetValue("connections", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'connections' cannot be null",
                    new ArgumentOutOfRangeException("connections", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Connection>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new SwarmsClientInvalidDataException(
                    "'connections' cannot be null",
                    new ArgumentNullException("connections")
                );
        }
        init
        {
            this._rawData["connections"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Connections)
        {
            item.Validate();
        }
    }

    public McpConfigs() { }

    public McpConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static McpConfigs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public McpConfigs(List<Connection> connections)
        : this()
    {
        this.Connections = connections;
    }
}

[JsonConverter(typeof(ModelConverter<Connection>))]
public sealed record class Connection : ModelBase, IFromRaw<Connection>
{
    /// <summary>
    /// Authentication token for accessing the MCP server
    /// </summary>
    public string? AuthorizationToken
    {
        get
        {
            if (!this._rawData.TryGetValue("authorization_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["authorization_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Headers to send to the MCP server
    /// </summary>
    public Dictionary<string, string>? Headers
    {
        get
        {
            if (!this._rawData.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timeout for the MCP server
    /// </summary>
    public long? Timeout
    {
        get
        {
            if (!this._rawData.TryGetValue("timeout", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["timeout"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Dictionary containing configuration settings for MCP tools
    /// </summary>
    public Dictionary<string, JsonElement>? ToolConfigurations
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_configurations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["tool_configurations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The transport protocol to use for the MCP server
    /// </summary>
    public string? Transport
    {
        get
        {
            if (!this._rawData.TryGetValue("transport", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["transport"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of connection, defaults to 'mcp'
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The URL endpoint for the MCP server
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AuthorizationToken;
        _ = this.Headers;
        _ = this.Timeout;
        _ = this.ToolConfigurations;
        _ = this.Transport;
        _ = this.Type;
        _ = this.URL;
    }

    public Connection() { }

    public Connection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Connection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Connection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
