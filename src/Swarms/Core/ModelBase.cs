using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Client.AutoSwarmBuilder;
using Swarms.Models.Swarms;
using ReasoningAgents = Swarms.Models.ReasoningAgents;

namespace Swarms.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, SwarmSpecSwarmType>(),
            new ApiEnumConverter<string, SwarmType>(),
            new ApiEnumConverter<string, ReasoningAgents::OutputType>(),
            new ApiEnumConverter<string, ReasoningAgents::SwarmType>(),
            new ApiEnumConverter<string, ExecutionType>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
