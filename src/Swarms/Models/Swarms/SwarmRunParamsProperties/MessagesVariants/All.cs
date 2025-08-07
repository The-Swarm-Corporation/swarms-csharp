using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Swarms.SwarmRunParamsProperties.MessagesVariants;

[JsonConverter(typeof(VariantConverter<JsonElements, List<Dictionary<string, JsonElement>>>))]
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

[JsonConverter(typeof(VariantConverter<JsonElementsVariant, Dictionary<string, JsonElement>>))]
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
