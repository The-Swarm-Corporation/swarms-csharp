using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Agent;

[JsonConverter(typeof(JsonModelConverter<AgentCompletion, AgentCompletionFromRaw>))]
public sealed record class AgentCompletion : JsonModel
{
    /// <summary>
    /// The configuration of the agent to be completed.
    /// </summary>
    public AgentSpec? AgentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentSpec>("agent_config");
        }
        init { this._rawData.Set("agent_config", value); }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a dictionary
    /// or a list of message objects.
    /// </summary>
    public AgentCompletionHistory? History
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentCompletionHistory>("history");
        }
        init { this._rawData.Set("history", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the agent's task or representation.
    /// </summary>
    public string? Img
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("img");
        }
        init { this._rawData.Set("img", value); }
    }

    /// <summary>
    /// A list of image URLs that may be associated with the agent's task or representation.
    /// </summary>
    public IReadOnlyList<string>? Imgs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("imgs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "imgs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("task");
        }
        init { this._rawData.Set("task", value); }
    }

    /// <summary>
    /// A list of tools that the agent should use to complete its task.
    /// </summary>
    public IReadOnlyList<string>? ToolsEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tools_enabled");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tools_enabled",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCompletion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentCompletionFromRaw.FromRawUnchecked"/>
    public static AgentCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentCompletionFromRaw : IFromRawJson<AgentCompletion>
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
public record class AgentCompletionHistory : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AgentCompletionHistory(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public AgentCompletionHistory(
        IReadOnlyList<IReadOnlyDictionary<string, string>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public AgentCompletionHistory(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="IReadOnlyList<IReadOnlyDictionary<string, string>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<IReadOnlyDictionary<string, string>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, string>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, string>>;
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
    ///     (IReadOnlyList<IReadOnlyDictionary<string, string>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<IReadOnlyDictionary<string, string>>> strings
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<IReadOnlyDictionary<string, string>> value:
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
    ///     (IReadOnlyList<IReadOnlyDictionary<string, string>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<IReadOnlyDictionary<string, string>>, T> strings
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<IReadOnlyDictionary<string, string>> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of AgentCompletionHistory"
            ),
        };
    }

    public static implicit operator AgentCompletionHistory(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator AgentCompletionHistory(
        List<Dictionary<string, string>> value
    ) => new((IReadOnlyList<IReadOnlyDictionary<string, string>>)value);

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
    public override void Validate()
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

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class AgentCompletionHistoryConverter : JsonConverter<AgentCompletionHistory?>
{
    public override AgentCompletionHistory? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<FrozenDictionary<string, JsonElement>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ImmutableArray<FrozenDictionary<string, string>>
            >(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
