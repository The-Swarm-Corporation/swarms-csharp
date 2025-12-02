using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(
    typeof(ModelConverter<SwarmCheckAvailableResponse, SwarmCheckAvailableResponseFromRaw>)
)]
public sealed record class SwarmCheckAvailableResponse : ModelBase
{
    public bool? Success
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    public IReadOnlyList<string>? SwarmTypes
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "swarm_types"); }
        init { ModelBase.Set(this._rawData, "swarm_types", value); }
    }

    public override void Validate()
    {
        _ = this.Success;
        _ = this.SwarmTypes;
    }

    public SwarmCheckAvailableResponse() { }

    public SwarmCheckAvailableResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmCheckAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SwarmCheckAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmCheckAvailableResponseFromRaw : IFromRaw<SwarmCheckAvailableResponse>
{
    public SwarmCheckAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwarmCheckAvailableResponse.FromRawUnchecked(rawData);
}
