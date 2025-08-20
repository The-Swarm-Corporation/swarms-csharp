using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Models.Client.Rate.RateGetLimitsResponseProperties;

namespace Swarms.Models.Client.Rate;

[JsonConverter(typeof(ModelConverter<RateGetLimitsResponse>))]
public sealed record class RateGetLimitsResponse : ModelBase, IFromRaw<RateGetLimitsResponse>
{
    /// <summary>
    /// The configured rate limits based on the user's subscription tier.
    /// </summary>
    public required Limits? Limits
    {
        get
        {
            if (!this.Properties.TryGetValue("limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Limits?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["limits"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Current rate limit usage information for different time windows.
    /// </summary>
    public required RateLimits? RateLimits
    {
        get
        {
            if (!this.Properties.TryGetValue("rate_limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RateLimits?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["rate_limits"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The user's current subscription tier (free or premium).
    /// </summary>
    public required string? Tier
    {
        get
        {
            if (!this.Properties.TryGetValue("tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["tier"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limits information was retrieved.
    /// </summary>
    public required string? Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["timestamp"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates whether the rate limits request was successful.
    /// </summary>
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
        this.Limits?.Validate();
        this.RateLimits?.Validate();
        _ = this.Tier;
        _ = this.Timestamp;
        _ = this.Success;
    }

    public RateGetLimitsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateGetLimitsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RateGetLimitsResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
