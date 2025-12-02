using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(ModelConverter<AgentCompletion, AgentCompletionFromRaw>))]
public sealed record class AgentCompletion : ModelBase
{
    /// <summary>
    /// The configuration of the agent to be completed.
    /// </summary>
    public AgentSpec? AgentConfig
    {
        get { return ModelBase.GetNullableClass<AgentSpec>(this.RawData, "agent_config"); }
        init { ModelBase.Set(this._rawData, "agent_config", value); }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a dictionary
    /// or a list of message objects.
    /// </summary>
    public AgentCompletionHistory? History
    {
        get { return ModelBase.GetNullableClass<AgentCompletionHistory>(this.RawData, "history"); }
        init { ModelBase.Set(this._rawData, "history", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the agent's task or representation.
    /// </summary>
    public string? Img
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "img"); }
        init { ModelBase.Set(this._rawData, "img", value); }
    }

    /// <summary>
    /// A list of image URLs that may be associated with the agent's task or representation.
    /// </summary>
    public IReadOnlyList<string>? Imgs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "imgs"); }
        init { ModelBase.Set(this._rawData, "imgs", value); }
    }

    /// <summary>
    /// The task to be completed by the agent.
    /// </summary>
    public string? Task
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "task"); }
        init { ModelBase.Set(this._rawData, "task", value); }
    }

    /// <summary>
    /// A list of tools that the agent should use to complete its task.
    /// </summary>
    public IReadOnlyList<string>? ToolsEnabled
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "tools_enabled"); }
        init { ModelBase.Set(this._rawData, "tools_enabled", value); }
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

    public AgentCompletion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCompletion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AgentCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentCompletionFromRaw : IFromRaw<AgentCompletion>
{
    public AgentCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentCompletion.FromRawUnchecked(rawData);
}

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(AgentCompletionHistoryConverter))]
public record class AgentCompletionHistory
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AgentCompletionHistory(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? json = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._json = json;
    }

    public AgentCompletionHistory(
        IReadOnlyList<Dictionary<string, string>> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public AgentCompletionHistory(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    public bool TryPickStrings(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, string>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, string>>;
        return value != null;
    }

    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<Dictionary<string, string>>> strings
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
                    "Data did not match any variant of AgentCompletionHistory"
                );
        }
    }

    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<Dictionary<string, string>>, T> strings
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<Dictionary<string, string>> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of AgentCompletionHistory"
            ),
        };
    }

    public static implicit operator AgentCompletionHistory(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator AgentCompletionHistory(
        List<Dictionary<string, string>> value
    ) => new((IReadOnlyList<Dictionary<string, string>>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of AgentCompletionHistory"
            );
        }
    }

    public virtual bool Equals(AgentCompletionHistory? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AgentCompletionHistoryConverter : JsonConverter<AgentCompletionHistory?>
{
    public override AgentCompletionHistory? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentCompletionHistory? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
