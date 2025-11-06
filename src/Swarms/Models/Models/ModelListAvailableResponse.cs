using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

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
            if (!this._properties.TryGetValue("models", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["models"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Success
    {
        get
        {
            if (!this._properties.TryGetValue("success", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["success"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Models;
        _ = this.Success;
    }

    public ModelListAvailableResponse() { }

    public ModelListAvailableResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListAvailableResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ModelListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
