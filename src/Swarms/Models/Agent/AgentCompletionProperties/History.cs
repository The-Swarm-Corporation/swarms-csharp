using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using HistoryVariants = Swarms.Models.Agent.AgentCompletionProperties.HistoryVariants;

namespace Swarms.Models.Agent.AgentCompletionProperties;

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(UnionConverter<History>))]
public abstract record class History
{
    internal History() { }

    public static implicit operator History(Dictionary<string, JsonElement> value) =>
        new HistoryVariants::JsonElements(value);

    public static implicit operator History(List<Dictionary<string, string>> value) =>
        new HistoryVariants::Strings(value);

    public abstract void Validate();
}
