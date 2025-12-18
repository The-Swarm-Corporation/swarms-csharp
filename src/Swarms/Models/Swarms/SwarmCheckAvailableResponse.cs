using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(
    typeof(JsonModelConverter<SwarmCheckAvailableResponse, SwarmCheckAvailableResponseFromRaw>)
)]
public sealed record class SwarmCheckAvailableResponse : JsonModel
{
    public bool? Success
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
    }

    public IReadOnlyList<string>? SwarmTypes
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "swarm_types"); }
        init { JsonModel.Set(this._rawData, "swarm_types", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.SwarmTypes;
    }

    public SwarmCheckAvailableResponse() { }

    public SwarmCheckAvailableResponse(SwarmCheckAvailableResponse swarmCheckAvailableResponse)
        : base(swarmCheckAvailableResponse) { }

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

    /// <inheritdoc cref="SwarmCheckAvailableResponseFromRaw.FromRawUnchecked"/>
    public static SwarmCheckAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmCheckAvailableResponseFromRaw : IFromRawJson<SwarmCheckAvailableResponse>
{
    /// <inheritdoc/>
    public SwarmCheckAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwarmCheckAvailableResponse.FromRawUnchecked(rawData);
}
