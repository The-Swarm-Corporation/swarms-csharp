using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(JsonModelConverter<McpConnection, McpConnectionFromRaw>))]
public sealed record class McpConnection : JsonModel
{
    /// <summary>
    /// Authentication token for accessing the MCP server
    /// </summary>
    public string? AuthorizationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorization_token");
        }
        init { this._rawData.Set("authorization_token", value); }
    }

    /// <summary>
    /// Headers to send to the MCP server
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeout");
        }
        init { this._rawData.Set("timeout", value); }
    }

    /// <summary>
    /// Dictionary containing configuration settings for MCP tools
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ToolConfigurations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "tool_configurations"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "tool_configurations",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transport");
        }
        init { this._rawData.Set("transport", value); }
    }

    /// <summary>
    /// The type of connection, defaults to 'mcp'
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The URL endpoint for the MCP server
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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
        _ = this.Url;
    }

    public McpConnection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpConnection(McpConnection mcpConnection)
        : base(mcpConnection) { }
#pragma warning restore CS8618

    public McpConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpConnectionFromRaw.FromRawUnchecked"/>
    public static McpConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpConnectionFromRaw : IFromRawJson<McpConnection>
{
    /// <inheritdoc/>
    public McpConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpConnection.FromRawUnchecked(rawData);
}
