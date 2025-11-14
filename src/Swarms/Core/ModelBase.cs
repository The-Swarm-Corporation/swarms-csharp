using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Swarms;
using ReasoningAgents = Swarms.Models.ReasoningAgents;

namespace Swarms.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, SwarmSpecSwarmType>(),
            new ApiEnumConverter<string, SwarmType>(),
            new ApiEnumConverter<string, ReasoningAgents::OutputType>(),
            new ApiEnumConverter<string, ReasoningAgents::SwarmType>(),
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
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
}
