using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Models.Agent.AgentRunParamsProperties.HistoryVariants;

namespace Swarms.Models.Agent.AgentRunParamsProperties;

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(HistoryConverter))]
public abstract record class History
{
    internal History() { }

    public static implicit operator History(Dictionary<string, JsonElement> value) =>
        new JsonElements(value);

    public static implicit operator History(List<Dictionary<string, string>> value) =>
        new Strings(value);

    public bool TryPickJsonElements([NotNullWhen(true)] out Dictionary<string, JsonElement>? value)
    {
        value = (this as JsonElements)?.Value;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out List<Dictionary<string, string>>? value)
    {
        value = (this as Strings)?.Value;
        return value != null;
    }

    public void Switch(Action<JsonElements> jsonElements, Action<Strings> strings)
    {
        switch (this)
        {
            case JsonElements inner:
                jsonElements(inner);
                break;
            case Strings inner:
                strings(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<JsonElements, T> jsonElements, Func<Strings, T> strings)
    {
        return this switch
        {
            JsonElements inner => jsonElements(inner),
            Strings inner => strings(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class HistoryConverter : JsonConverter<History?>
{
    public override History? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new JsonElements(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Strings(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, History? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            JsonElements(var jsonElements) => jsonElements,
            Strings(var strings) => strings,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
