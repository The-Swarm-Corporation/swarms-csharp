using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent.AgentSpecProperties.McpConfigsProperties;

namespace Swarms.Models.Agent.AgentSpecProperties;

/// <summary>
/// The MCP connections to use for the agent. This is a list of MCP connections.
/// Includes multiple MCP connections.
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
            if (!this.Properties.TryGetValue("connections", out JsonElement element))
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
        set
        {
            this.Properties["connections"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpConfigs(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static McpConfigs FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public McpConfigs(List<Connection> connections)
        : this()
    {
        this.Connections = connections;
    }
}
