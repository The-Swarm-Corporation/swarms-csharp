using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AgentCompletionProperties = Swarms.Models.Agent.AgentCompletionProperties;
using Swarms = Swarms;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(Swarms::ModelConverter<AgentCompletion>))]
public sealed record class AgentCompletion : Swarms::ModelBase, Swarms::IFromRaw<AgentCompletion>
{
    /// <summary>
    /// The configuration of the agent to be completed.
    /// </summary>
    public AgentSpec? AgentConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("agent_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AgentSpec?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["agent_config"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a
    /// dictionary or a list of message objects.
    /// </summary>
    public AgentCompletionProperties::History? History
    {
        get
        {
            if (!this.Properties.TryGetValue("history", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AgentCompletionProperties::History?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["history"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the agent's task or representation.
    /// </summary>
    public string? Img
    {
        get
        {
            if (!this.Properties.TryGetValue("img", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["img"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of image URLs that may be associated with the agent's task or representation.
    /// </summary>
    public List<string>? Imgs
    {
        get
        {
            if (!this.Properties.TryGetValue("imgs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["imgs"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A flag indicating whether the agent should stream its output.
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this.Properties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["stream"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The task to be completed by the agent.
    /// </summary>
    public string? Task
    {
        get
        {
            if (!this.Properties.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["task"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.AgentConfig?.Validate();
        this.History?.Validate();
        _ = this.Img;
        foreach (var item in this.Imgs ?? [])
        {
            _ = item;
        }
        _ = this.Stream;
        _ = this.Task;
    }

    public AgentCompletion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCompletion(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AgentCompletion FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
