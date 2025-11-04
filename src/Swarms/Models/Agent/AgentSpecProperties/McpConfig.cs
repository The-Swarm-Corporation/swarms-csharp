using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Agent.AgentSpecProperties;

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
            if (!this.Properties.TryGetValue("authorization_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["authorization_token"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["headers"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("timeout", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timeout"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("tool_configurations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["tool_configurations"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("transport", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["transport"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static McpConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
