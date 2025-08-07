using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Models;

[JsonConverter(typeof(ModelConverter<ModelListAvailableResponse>))]
public sealed record class ModelListAvailableResponse
    : ModelBase,
        IFromRaw<ModelListAvailableResponse>
{
    public JsonElement? Models
    {
        get
        {
            if (!this.Properties.TryGetValue("models", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["models"] = JsonSerializer.SerializeToElement(value); }
    }

    public bool? Success
    {
        get
        {
            if (!this.Properties.TryGetValue("success", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["success"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Models;
        _ = this.Success;
    }

    public ModelListAvailableResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListAvailableResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ModelListAvailableResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
