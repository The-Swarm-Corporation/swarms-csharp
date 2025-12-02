using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Health;

[JsonConverter(typeof(ModelConverter<HealthCheckResponse, HealthCheckResponseFromRaw>))]
public sealed record class HealthCheckResponse : ModelBase
{
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    public override void Validate()
    {
        _ = this.Status;
    }

    public HealthCheckResponse() { }

    public HealthCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HealthCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static HealthCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HealthCheckResponseFromRaw : IFromRaw<HealthCheckResponse>
{
    public HealthCheckResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HealthCheckResponse.FromRawUnchecked(rawData);
}
