using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(ModelConverter<SwarmGetLogsResponse>))]
public sealed record class SwarmGetLogsResponse : ModelBase, IFromRaw<SwarmGetLogsResponse>
{
    public long? Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["count"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement? Logs
    {
        get
        {
            if (!this.Properties.TryGetValue("logs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["logs"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["timestamp"] = JsonSerializer.SerializeToElement(value); }
    }

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
    SwarmGetLogsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SwarmGetLogsResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
