using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessagesVariants = Swarms.Models.Swarms.SwarmSpecProperties.MessagesVariants;

namespace Swarms.Models.Swarms.SwarmSpecProperties;

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(UnionConverter<Messages>))]
public abstract record class Messages
{
    internal Messages() { }

    public static implicit operator Messages(List<Dictionary<string, JsonElement>> value) =>
        new MessagesVariants::JsonElements(value);

    public static implicit operator Messages(Dictionary<string, JsonElement> value) =>
        new MessagesVariants::JsonElementsVariant(value);

    public abstract void Validate();
}
