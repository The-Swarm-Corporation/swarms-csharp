using System.Collections.Generic;
using System.Text.Json;

namespace Swarms.Models.Agent.AgentRunParamsProperties.HistoryVariants;

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
