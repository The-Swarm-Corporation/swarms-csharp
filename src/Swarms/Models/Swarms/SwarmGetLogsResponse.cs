using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(ModelConverter<SwarmGetLogsResponse>))]
public sealed record class SwarmGetLogsResponse : ModelBase, IFromRaw<SwarmGetLogsResponse>
{
    public long? Count
    {
        get
        {
            if (!this._rawData.TryGetValue("count", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Logs
    {
        get
        {
            if (!this._rawData.TryGetValue("logs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["logs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Timestamp
    {
        get
        {
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
