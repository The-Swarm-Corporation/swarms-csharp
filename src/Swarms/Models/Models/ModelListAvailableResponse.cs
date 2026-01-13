using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Models;

[JsonConverter(
    typeof(JsonModelConverter<ModelListAvailableResponse, ModelListAvailableResponseFromRaw>)
)]
public sealed record class ModelListAvailableResponse : JsonModel
{
    public JsonElement? Models
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("models");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("models", value);
        }
    }

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Models;
        _ = this.Success;
    }

    public ModelListAvailableResponse() { }

    public ModelListAvailableResponse(ModelListAvailableResponse modelListAvailableResponse)
        : base(modelListAvailableResponse) { }

    public ModelListAvailableResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelListAvailableResponseFromRaw.FromRawUnchecked"/>
    public static ModelListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelListAvailableResponseFromRaw : IFromRawJson<ModelListAvailableResponse>
{
    /// <inheritdoc/>
    public ModelListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelListAvailableResponse.FromRawUnchecked(rawData);
}
