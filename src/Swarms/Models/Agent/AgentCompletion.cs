using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(ModelConverter<AgentCompletion>))]
public sealed record class AgentCompletion : ModelBase, IFromRaw<AgentCompletion>
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

            return JsonSerializer.Deserialize<AgentSpec?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["agent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a
    /// dictionary or a list of message objects.
    /// </summary>
    public HistoryModel? History
    {
        get
        {
            if (!this.Properties.TryGetValue("history", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<HistoryModel?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["history"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["img"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["imgs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["task"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of tools that the agent should use to complete its task.
    /// </summary>
    public List<string>? ToolsEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("tools_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tools_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AgentConfig?.Validate();
        this.History?.Validate();
        _ = this.Img;
        _ = this.Imgs;
        _ = this.Task;
        _ = this.ToolsEnabled;
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

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(HistoryModelConverter))]
public record class HistoryModel
{
    public object Value { get; private init; }

    public HistoryModel(Dictionary<string, JsonElement> value)
    {
        Value = value;
    }

    public HistoryModel(List<Dictionary<string, string>> value)
    {
        Value = value;
    }

    HistoryModel(UnknownVariant value)
    {
        Value = value;
    }

    public static HistoryModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickJsonElements([NotNullWhen(true)] out Dictionary<string, JsonElement>? value)
    {
        value = this.Value as Dictionary<string, JsonElement>;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out List<Dictionary<string, string>>? value)
    {
        value = this.Value as List<Dictionary<string, string>>;
        return value != null;
    }

    public void Switch(
        Action<Dictionary<string, JsonElement>> jsonElements,
        Action<List<Dictionary<string, string>>> strings
    )
    {
        switch (this.Value)
        {
            case Dictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case List<Dictionary<string, string>> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of HistoryModel"
                );
        }
    }

    public T Match<T>(
        Func<Dictionary<string, JsonElement>, T> jsonElements,
        Func<List<Dictionary<string, string>>, T> strings
    )
    {
        return this.Value switch
        {
            Dictionary<string, JsonElement> value => jsonElements(value),
            List<Dictionary<string, string>> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of HistoryModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of HistoryModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class HistoryModelConverter : JsonConverter<HistoryModel?>
{
    public override HistoryModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new HistoryModel(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'Dictionary<string, JsonElement>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new HistoryModel(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<Dictionary<string, string>>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoryModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
