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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public JsonElement? Logs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("logs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logs", value);
        }
    }

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SwarmGetLogsResponse(SwarmGetLogsResponse swarmGetLogsResponse)
        : base(swarmGetLogsResponse) { }
#pragma warning restore CS8618

    public SwarmGetLogsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmGetLogsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
