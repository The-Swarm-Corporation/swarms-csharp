using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Exceptions;

namespace Swarms.Models.Agent.AgentCompletionProperties;

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(HistoryConverter))]
public record class History
{
    public object Value { get; private init; }

    public History(Dictionary<string, JsonElement> value)
    {
        Value = value;
    }

    public History(List<Dictionary<string, string>> value)
    {
        Value = value;
    }

    History(UnknownVariant value)
    {
        Value = value;
    }

    public static History CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of History"
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
                "Data did not match any variant of History"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException("Data did not match any variant of History");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class HistoryConverter : JsonConverter<History?>
{
    public override History? Read(
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
                return new History(deserialized);
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
                return new History(deserialized);
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

    public override void Write(Utf8JsonWriter writer, History? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
