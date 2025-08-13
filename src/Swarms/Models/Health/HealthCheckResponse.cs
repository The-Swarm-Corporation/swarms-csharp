using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms = Swarms;

namespace Swarms.Models.Health;

[JsonConverter(typeof(Swarms::ModelConverter<HealthCheckResponse>))]
public sealed record class HealthCheckResponse
    : Swarms::ModelBase,
        Swarms::IFromRaw<HealthCheckResponse>
{
    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Status;
    }

    public HealthCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HealthCheckResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static HealthCheckResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
