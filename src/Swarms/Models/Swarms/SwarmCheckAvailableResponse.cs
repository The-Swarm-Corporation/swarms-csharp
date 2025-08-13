using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms = Swarms;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(Swarms::ModelConverter<SwarmCheckAvailableResponse>))]
public sealed record class SwarmCheckAvailableResponse
    : Swarms::ModelBase,
        Swarms::IFromRaw<SwarmCheckAvailableResponse>
{
    public bool? Success
    {
        get
        {
            if (!this.Properties.TryGetValue("success", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, Swarms::ModelBase.SerializerOptions);
        }
        set { this.Properties["success"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement? SwarmTypes
    {
        get
        {
            if (!this.Properties.TryGetValue("swarm_types", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(
                element,
                Swarms::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["swarm_types"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Success;
        _ = this.SwarmTypes;
    }

    public SwarmCheckAvailableResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmCheckAvailableResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SwarmCheckAvailableResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
