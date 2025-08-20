using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Swarms.SwarmSpecProperties;
using ReasoningAgentCreateCompletionParamsProperties = Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;
using SwarmRunParamsProperties = Swarms.Models.Swarms.SwarmRunParamsProperties;

namespace Swarms;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, SwarmType>(),
            new ApiEnumConverter<string, SwarmRunParamsProperties::SwarmType>(),
            new ApiEnumConverter<
                string,
                ReasoningAgentCreateCompletionParamsProperties::OutputType
            >(),
            new ApiEnumConverter<
                string,
                ReasoningAgentCreateCompletionParamsProperties::SwarmType
            >(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
