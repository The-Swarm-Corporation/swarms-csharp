using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "agent_name"); }
        init { JsonModel.Set(this._rawData, "agent_name", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should automatically create prompts based
    /// on the task requirements.
    /// </summary>
    public bool? AutoGeneratePrompt
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "auto_generate_prompt"); }
        init { JsonModel.Set(this._rawData, "auto_generate_prompt", value); }
    }

    /// <summary>
    /// A detailed explanation of the agent's purpose, capabilities, and any specific
    /// tasks it is designed to perform.
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should dynamically adjust its temperature
    /// based on the task.
    /// </summary>
    public bool? DynamicTemperatureEnabled
    {
        get
        {
            return JsonModel.GetNullableStruct<bool>(this.RawData, "dynamic_temperature_enabled");
        }
        init { JsonModel.Set(this._rawData, "dynamic_temperature_enabled", value); }
    }

    /// <summary>
    /// Additional arguments to pass to the LLM such as top_p, frequency_penalty,
    /// presence_penalty, etc.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LlmArgs
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "llm_args"
            );
        }
        init { JsonModel.Set(this._rawData, "llm_args", value); }
    }

    /// <summary>
    /// The maximum number of times the agent is allowed to repeat its task, enabling
    /// iterative processing if necessary.
    /// </summary>
    public long? MaxLoops
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "max_loops"); }
        init { JsonModel.Set(this._rawData, "max_loops", value); }
    }

    /// <summary>
    /// The maximum number of tokens that the agent is allowed to generate in its
    /// responses, limiting output length.
    /// </summary>
    public long? MaxTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "max_tokens"); }
        init { JsonModel.Set(this._rawData, "max_tokens", value); }
    }

    /// <summary>
    /// The MCP connection to use for the agent.
    /// </summary>
    public McpConfig? McpConfig
    {
        get { return JsonModel.GetNullableClass<McpConfig>(this.RawData, "mcp_config"); }
        init { JsonModel.Set(this._rawData, "mcp_config", value); }
    }

    /// <summary>
    /// The MCP connections to use for the agent. This is a list of MCP connections.
    /// Includes multiple MCP connections.
    /// </summary>
    public McpConfigs? McpConfigs
    {
        get { return JsonModel.GetNullableClass<McpConfigs>(this.RawData, "mcp_configs"); }
        init { JsonModel.Set(this._rawData, "mcp_configs", value); }
    }

    /// <summary>
    /// The URL of the MCP server that the agent can use to complete its task.
    /// </summary>
    public string? McpURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "mcp_url"); }
        init { JsonModel.Set(this._rawData, "mcp_url", value); }
    }

    /// <summary>
    /// The name of the AI model that the agent will utilize for processing tasks
    /// and generating outputs. For example: gpt-4o, gpt-4o-mini, openai/o3-mini
    /// </summary>
    public string? ModelName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "model_name"); }
        init { JsonModel.Set(this._rawData, "model_name", value); }
    }

    /// <summary>
    /// The effort to put into reasoning.
    /// </summary>
    public string? ReasoningEffort
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reasoning_effort"); }
        init { JsonModel.Set(this._rawData, "reasoning_effort", value); }
    }

    /// <summary>
    /// A parameter enabling an agent to use reasoning.
    /// </summary>
    public bool? ReasoningEnabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "reasoning_enabled"); }
        init { JsonModel.Set(this._rawData, "reasoning_enabled", value); }
    }

    /// <summary>
    /// The designated role of the agent within the swarm, which influences its behavior
    /// and interaction with other agents.
    /// </summary>
    public string? Role
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "role"); }
        init { JsonModel.Set(this._rawData, "role", value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? StreamingOn
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "streaming_on"); }
        init { JsonModel.Set(this._rawData, "streaming_on", value); }
    }

    /// <summary>
    /// The initial instruction or context provided to the agent, guiding its behavior
    /// and responses during execution.
    /// </summary>
    public string? SystemPrompt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "system_prompt"); }
        init { JsonModel.Set(this._rawData, "system_prompt", value); }
    }

    /// <summary>
    /// A parameter that controls the randomness of the agent's output; lower values
    /// result in more deterministic responses.
    /// </summary>
    public double? Temperature
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "temperature"); }
        init { JsonModel.Set(this._rawData, "temperature", value); }
    }

    /// <summary>
    /// The number of tokens to use for thinking.
    /// </summary>
    public long? ThinkingTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "thinking_tokens"); }
        init { JsonModel.Set(this._rawData, "thinking_tokens", value); }
    }

    /// <summary>
    /// A parameter enabling an agent to summarize tool calls.
    /// </summary>
    public bool? ToolCallSummary
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "tool_call_summary"); }
        init { JsonModel.Set(this._rawData, "tool_call_summary", value); }
    }

    /// <summary>
    /// A dictionary of tools that the agent can use to complete its task.
    /// </summary>
    public IReadOnlyList<Dictionary<string, JsonElement>>? ToolsListDictionary
    {
        get
        {
            return JsonModel.GetNullableClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "tools_list_dictionary"
            );
        }
        init { JsonModel.Set(this._rawData, "tools_list_dictionary", value); }
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

    public AgentSpec(AgentSpec agentSpec)
        : base(agentSpec) { }

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
/// The MCP connection to use for the agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpConfig, McpConfigFromRaw>))]
public sealed record class McpConfig : JsonModel
{
    /// <summary>
    /// Authentication token for accessing the MCP server
    /// </summary>
    public string? AuthorizationToken
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "authorization_token"); }
        init { JsonModel.Set(this._rawData, "authorization_token", value); }
    }

    /// <summary>
    /// Headers to send to the MCP server
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(this.RawData, "headers");
        }
        init { JsonModel.Set(this._rawData, "headers", value); }
    }

    /// <summary>
    /// Timeout for the MCP server
    /// </summary>
    public long? Timeout
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "timeout"); }
        init { JsonModel.Set(this._rawData, "timeout", value); }
    }

    /// <summary>
    /// Dictionary containing configuration settings for MCP tools
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ToolConfigurations
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "tool_configurations"
            );
        }
        init { JsonModel.Set(this._rawData, "tool_configurations", value); }
    }

    /// <summary>
    /// The transport protocol to use for the MCP server
    /// </summary>
    public string? Transport
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "transport"); }
        init { JsonModel.Set(this._rawData, "transport", value); }
    }

    /// <summary>
    /// The type of connection, defaults to 'mcp'
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The URL endpoint for the MCP server
    /// </summary>
    public string? URL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
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

    public McpConfig(McpConfig mcpConfig)
        : base(mcpConfig) { }

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

    /// <inheritdoc cref="McpConfigFromRaw.FromRawUnchecked"/>
    public static McpConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpConfigFromRaw : IFromRawJson<McpConfig>
{
    /// <inheritdoc/>
    public McpConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpConfig.FromRawUnchecked(rawData);
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
    public required IReadOnlyList<Connection> Connections
    {
        get { return JsonModel.GetNotNullClass<List<Connection>>(this.RawData, "connections"); }
        init { JsonModel.Set(this._rawData, "connections", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpConfigsFromRaw.FromRawUnchecked"/>
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

class McpConfigsFromRaw : IFromRawJson<McpConfigs>
{
    /// <inheritdoc/>
    public McpConfigs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpConfigs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Connection, ConnectionFromRaw>))]
public sealed record class Connection : JsonModel
{
    /// <summary>
    /// Authentication token for accessing the MCP server
    /// </summary>
    public string? AuthorizationToken
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "authorization_token"); }
        init { JsonModel.Set(this._rawData, "authorization_token", value); }
    }

    /// <summary>
    /// Headers to send to the MCP server
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(this.RawData, "headers");
        }
        init { JsonModel.Set(this._rawData, "headers", value); }
    }

    /// <summary>
    /// Timeout for the MCP server
    /// </summary>
    public long? Timeout
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "timeout"); }
        init { JsonModel.Set(this._rawData, "timeout", value); }
    }

    /// <summary>
    /// Dictionary containing configuration settings for MCP tools
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ToolConfigurations
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "tool_configurations"
            );
        }
        init { JsonModel.Set(this._rawData, "tool_configurations", value); }
    }

    /// <summary>
    /// The transport protocol to use for the MCP server
    /// </summary>
    public string? Transport
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "transport"); }
        init { JsonModel.Set(this._rawData, "transport", value); }
    }

    /// <summary>
    /// The type of connection, defaults to 'mcp'
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The URL endpoint for the MCP server
    /// </summary>
    public string? URL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
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

    public Connection(Connection connection)
        : base(connection) { }

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

    /// <inheritdoc cref="ConnectionFromRaw.FromRawUnchecked"/>
    public static Connection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectionFromRaw : IFromRawJson<Connection>
{
    /// <inheritdoc/>
    public Connection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Connection.FromRawUnchecked(rawData);
}
