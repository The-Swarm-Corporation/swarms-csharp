using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(ModelConverter<SwarmGetLogsResponse, SwarmGetLogsResponseFromRaw>))]
public sealed record class SwarmGetLogsResponse : ModelBase
{
    public long? Count
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "count"); }
        init { ModelBase.Set(this._rawData, "count", value); }
    }

    public JsonElement? Logs
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "logs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "logs", value);
        }
    }

    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public string? Timestamp
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.Logs;
        _ = this.Status;
        _ = this.Timestamp;
    }

    public SwarmGetLogsResponse() { }

    public SwarmGetLogsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmGetLogsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SwarmGetLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmGetLogsResponseFromRaw : IFromRaw<SwarmGetLogsResponse>
{
    public SwarmGetLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwarmGetLogsResponse.FromRawUnchecked(rawData);
}
