using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Health;

[JsonConverter(typeof(JsonModelConverter<HealthCheckResponse, HealthCheckResponseFromRaw>))]
public sealed record class HealthCheckResponse : JsonModel
{
    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
    }

    public HealthCheckResponse() { }

    public HealthCheckResponse(HealthCheckResponse healthCheckResponse)
        : base(healthCheckResponse) { }

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

    /// <inheritdoc cref="HealthCheckResponseFromRaw.FromRawUnchecked"/>
    public static HealthCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HealthCheckResponseFromRaw : IFromRawJson<HealthCheckResponse>
{
    /// <inheritdoc/>
    public HealthCheckResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HealthCheckResponse.FromRawUnchecked(rawData);
}
