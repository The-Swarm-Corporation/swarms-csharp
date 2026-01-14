using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(JsonModelConverter<AgentSpec, AgentSpecFromRaw>))]
public sealed record class AgentSpec : JsonModel
{
    /// <summary>
    /// The unique name assigned to the agent, which identifies its role and functionality
    /// within the swarm.
    /// </summary>
    public required string? AgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_name");
        }
        init { this._rawData.Set("agent_name", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should automatically create prompts based
    /// on the task requirements.
    /// </summary>
    public bool? AutoGeneratePrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_generate_prompt");
        }
        init { this._rawData.Set("auto_generate_prompt", value); }
    }

    /// <summary>
    /// A detailed explanation of the agent's purpose, capabilities, and any specific
    /// tasks it is designed to perform.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should dynamically adjust its temperature
    /// based on the task.
    /// </summary>
    public bool? DynamicTemperatureEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("dynamic_temperature_enabled");
        }
        init { this._rawData.Set("dynamic_temperature_enabled", value); }
    }

    /// <summary>
    /// Additional arguments to pass to the LLM such as top_p, frequency_penalty,
    /// presence_penalty, etc.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LlmArgs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "llm_args"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "llm_args",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_loops");
        }
        init { this._rawData.Set("max_loops", value); }
    }

    /// <summary>
    /// The maximum number of tokens that the agent is allowed to generate in its
    /// responses, limiting output length.
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    /// <summary>
    /// The MCP connection to use for the agent.
    /// </summary>
    public McpConnection? McpConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<McpConnection>("mcp_config");
        }
        init { this._rawData.Set("mcp_config", value); }
    }

    /// <summary>
    /// The MCP connections to use for the agent. This is a list of MCP connections.
    /// Includes multiple MCP connections.
    /// </summary>
    public McpConfigs? McpConfigs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<McpConfigs>("mcp_configs");
        }
        init { this._rawData.Set("mcp_configs", value); }
    }

    /// <summary>
    /// The URL of the MCP server that the agent can use to complete its task.
    /// </summary>
    public string? McpUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mcp_url");
        }
        init { this._rawData.Set("mcp_url", value); }
    }

    /// <summary>
    /// The name of the AI model that the agent will utilize for processing tasks
    /// and generating outputs. For example: gpt-4o, gpt-4o-mini, openai/o3-mini
    /// </summary>
    public string? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model_name");
        }
        init { this._rawData.Set("model_name", value); }
    }

    /// <summary>
    /// The effort to put into reasoning.
    /// </summary>
    public string? ReasoningEffort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reasoning_effort");
        }
        init { this._rawData.Set("reasoning_effort", value); }
    }

    /// <summary>
    /// A parameter enabling an agent to use reasoning.
    /// </summary>
    public bool? ReasoningEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("reasoning_enabled");
        }
        init { this._rawData.Set("reasoning_enabled", value); }
    }

    /// <summary>
    /// The designated role of the agent within the swarm, which influences its behavior
    /// and interaction with other agents.
    /// </summary>
    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? StreamingOn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("streaming_on");
        }
        init { this._rawData.Set("streaming_on", value); }
    }

    /// <summary>
    /// The initial instruction or context provided to the agent, guiding its behavior
    /// and responses during execution.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawData.Set("system_prompt", value); }
    }

    /// <summary>
    /// A parameter that controls the randomness of the agent's output; lower values
    /// result in more deterministic responses.
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    /// <summary>
    /// The number of tokens to use for thinking.
    /// </summary>
    public long? ThinkingTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("thinking_tokens");
        }
        init { this._rawData.Set("thinking_tokens", value); }
    }

    /// <summary>
    /// A parameter enabling an agent to summarize tool calls.
    /// </summary>
    public bool? ToolCallSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tool_call_summary");
        }
        init { this._rawData.Set("tool_call_summary", value); }
    }

    /// <summary>
    /// A dictionary of tools that the agent can use to complete its task.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? ToolsListDictionary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("tools_list_dictionary");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "tools_list_dictionary",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <inheritdoc/>
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
        _ = this.McpUrl;
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

    public AgentSpec(AgentSpec agentSpec)
        : base(agentSpec) { }

    public AgentSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentSpecFromRaw.FromRawUnchecked"/>
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

class AgentSpecFromRaw : IFromRawJson<AgentSpec>
{
    /// <inheritdoc/>
    public AgentSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentSpec.FromRawUnchecked(rawData);
}

/// <summary>
/// The MCP connections to use for the agent. This is a list of MCP connections. Includes
/// multiple MCP connections.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpConfigs, McpConfigsFromRaw>))]
public sealed record class McpConfigs : JsonModel
{
    /// <summary>
    /// List of MCP connections
    /// </summary>
    public required IReadOnlyList<McpConnection> Connections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<McpConnection>>("connections");
        }
        init
        {
            this._rawData.Set<ImmutableArray<McpConnection>>(
                "connections",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Connections)
        {
            item.Validate();
        }
    }

    public McpConfigs() { }

    public McpConfigs(McpConfigs mcpConfigs)
        : base(mcpConfigs) { }

    public McpConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpConfigsFromRaw.FromRawUnchecked"/>
    public static McpConfigs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public McpConfigs(IReadOnlyList<McpConnection> connections)
        : this()
    {
        this.Connections = connections;
    }
}

class McpConfigsFromRaw : IFromRawJson<McpConfigs>
{
    /// <inheritdoc/>
    public McpConfigs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpConfigs.FromRawUnchecked(rawData);
}
