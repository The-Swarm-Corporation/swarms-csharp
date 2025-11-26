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
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
