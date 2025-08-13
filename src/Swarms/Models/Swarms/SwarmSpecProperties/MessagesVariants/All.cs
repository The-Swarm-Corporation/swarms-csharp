using System.Collections.Generic;
using System.Text.Json;

namespace Swarms.Models.Swarms.SwarmSpecProperties.MessagesVariants;

public sealed record class JsonElements(List<Dictionary<string, JsonElement>> Value)
    : Messages,
        IVariant<JsonElements, List<Dictionary<string, JsonElement>>>
{
    public static JsonElements From(List<Dictionary<string, JsonElement>> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class JsonElementsVariant(Dictionary<string, JsonElement> Value)
    : Messages,
        IVariant<JsonElementsVariant, Dictionary<string, JsonElement>>
{
    public static JsonElementsVariant From(Dictionary<string, JsonElement> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
