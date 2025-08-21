using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Models.Swarms.SwarmSpecProperties.MessagesVariants;

namespace Swarms.Models.Swarms.SwarmSpecProperties;

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesConverter))]
public abstract record class Messages
{
    internal Messages() { }

    public static implicit operator Messages(List<Dictionary<string, JsonElement>> value) =>
        new JsonElements(value);

    public static implicit operator Messages(Dictionary<string, JsonElement> value) =>
        new JsonElementsVariant(value);

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out List<Dictionary<string, JsonElement>>? value
    )
    {
        value = (this as JsonElements)?.Value;
        return value != null;
    }

    public bool TryPickJsonElementsVariant(
        [NotNullWhen(true)] out Dictionary<string, JsonElement>? value
    )
    {
        value = (this as JsonElementsVariant)?.Value;
        return value != null;
    }

    public void Switch(Action<JsonElements> jsonElements, Action<JsonElementsVariant> jsonElements1)
    {
        switch (this)
        {
            case JsonElements inner:
                jsonElements(inner);
                break;
            case JsonElementsVariant inner:
                jsonElements1(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<JsonElements, T> jsonElements,
        Func<JsonElementsVariant, T> jsonElements1
    )
    {
        return this switch
        {
            JsonElements inner => jsonElements(inner),
            JsonElementsVariant inner => jsonElements1(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MessagesConverter : JsonConverter<Messages?>
{
    public override Messages? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
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
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new JsonElementsVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Messages? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            JsonElements(var jsonElements) => jsonElements,
            JsonElementsVariant(var jsonElements) => jsonElements,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
