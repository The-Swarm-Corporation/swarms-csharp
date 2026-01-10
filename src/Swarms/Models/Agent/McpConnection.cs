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
    public string? Url
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
        _ = this.Url;
    }

    public McpConnection() { }

    public McpConnection(McpConnection mcpConnection)
        : base(mcpConnection) { }

    public McpConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
