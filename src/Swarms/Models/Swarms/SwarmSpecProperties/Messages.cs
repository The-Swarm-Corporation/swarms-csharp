using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Exceptions;

namespace Swarms.Models.Swarms.SwarmSpecProperties;

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesConverter))]
public record class Messages
{
    public object Value { get; private init; }

    public Messages(List<Dictionary<string, JsonElement>> value)
    {
        Value = value;
    }

    public Messages(Dictionary<string, JsonElement> value)
    {
        Value = value;
    }

    Messages(UnknownVariant value)
    {
        Value = value;
    }

    public static Messages CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out List<Dictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as List<Dictionary<string, JsonElement>>;
        return value != null;
    }

    public bool TryPickJsonElements1([NotNullWhen(true)] out Dictionary<string, JsonElement>? value)
    {
        value = this.Value as Dictionary<string, JsonElement>;
        return value != null;
    }

    public void Switch(
        Action<List<Dictionary<string, JsonElement>>> jsonElements,
        Action<Dictionary<string, JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case List<Dictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case Dictionary<string, JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Messages"
                );
        }
    }

    public T Match<T>(
        Func<List<Dictionary<string, JsonElement>>, T> jsonElements,
        Func<Dictionary<string, JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            List<Dictionary<string, JsonElement>> value => jsonElements(value),
            Dictionary<string, JsonElement> value => jsonElements1(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Messages"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Messages"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class MessagesConverter : JsonConverter<Messages?>
{
    public override Messages? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Messages(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<Dictionary<string, JsonElement>>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Messages(deserialized);
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

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Messages? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
