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
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "models"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "models", value);
        }
    }

    public bool? Success
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
