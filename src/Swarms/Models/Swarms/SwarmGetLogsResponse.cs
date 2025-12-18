using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(JsonModelConverter<SwarmGetLogsResponse, SwarmGetLogsResponseFromRaw>))]
public sealed record class SwarmGetLogsResponse : JsonModel
{
    public long? Count
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "count"); }
        init { JsonModel.Set(this._rawData, "count", value); }
    }

    public JsonElement? Logs
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "logs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "logs", value);
        }
    }

    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public string? Timestamp
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "timestamp"); }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Logs;
        _ = this.Status;
        _ = this.Timestamp;
    }

    public SwarmGetLogsResponse() { }

    public SwarmGetLogsResponse(SwarmGetLogsResponse swarmGetLogsResponse)
        : base(swarmGetLogsResponse) { }

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

    /// <inheritdoc cref="SwarmGetLogsResponseFromRaw.FromRawUnchecked"/>
    public static SwarmGetLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmGetLogsResponseFromRaw : IFromRawJson<SwarmGetLogsResponse>
{
    /// <inheritdoc/>
    public SwarmGetLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SwarmGetLogsResponse.FromRawUnchecked(rawData);
}
