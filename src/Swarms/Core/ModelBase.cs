using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.ReasoningAgents;
using Swarms = Swarms.Models.Swarms;

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
            new ApiEnumConverter<string, Swarms::SwarmTypeModel>(),
            new ApiEnumConverter<string, Swarms::SwarmType>(),
            new ApiEnumConverter<string, OutputType>(),
            new ApiEnumConverter<string, SwarmType>(),
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
