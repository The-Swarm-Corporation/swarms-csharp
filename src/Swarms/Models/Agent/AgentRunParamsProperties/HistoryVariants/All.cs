using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Agent.AgentRunParamsProperties.HistoryVariants;

[JsonConverter(typeof(VariantConverter<JsonElements, Dictionary<string, JsonElement>>))]
public sealed record class JsonElements(Dictionary<string, JsonElement> Value)
    : History,
        IVariant<JsonElements, Dictionary<string, JsonElement>>
{
    public static JsonElements From(Dictionary<string, JsonElement> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<Strings, List<Dictionary<string, string>>>))]
public sealed record class Strings(List<Dictionary<string, string>> Value)
    : History,
        IVariant<Strings, List<Dictionary<string, string>>>
{
    public static Strings From(List<Dictionary<string, string>> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
