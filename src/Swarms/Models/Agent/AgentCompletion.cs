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

    /// <inheritdoc/>
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

    public AgentCompletion(AgentCompletion agentCompletion)
        : base(agentCompletion) { }

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

    /// <inheritdoc cref="AgentCompletionFromRaw.FromRawUnchecked"/>
    public static AgentCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentCompletionFromRaw : IFromRaw<AgentCompletion>
{
    /// <inheritdoc/>
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

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyDictionary<string, JsonElement>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary<string, JsonElement>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<Dictionary<string, string>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<Dictionary<string, string>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, string>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, string>>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...},
    ///     (IReadOnlyList<Dictionary<string, string>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...},
    ///     (IReadOnlyList<Dictionary<string, string>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
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
