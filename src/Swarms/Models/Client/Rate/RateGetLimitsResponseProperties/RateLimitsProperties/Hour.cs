using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Client.Rate.RateGetLimitsResponseProperties.RateLimitsProperties;

/// <summary>
/// Rate limit information for the last hour.
/// </summary>
[JsonConverter(typeof(ModelConverter<Hour>))]
public sealed record class Hour : ModelBase, IFromRaw<Hour>
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new ArgumentOutOfRangeException("count", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["count"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get
        {
            if (!this.Properties.TryGetValue("exceeded", out JsonElement element))
                throw new ArgumentOutOfRangeException("exceeded", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["exceeded"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get
        {
            if (!this.Properties.TryGetValue("limit", out JsonElement element))
                throw new ArgumentOutOfRangeException("limit", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get
        {
            if (!this.Properties.TryGetValue("remaining", out JsonElement element))
                throw new ArgumentOutOfRangeException("remaining", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["remaining"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get
        {
            if (!this.Properties.TryGetValue("reset_time", out JsonElement element))
                throw new ArgumentOutOfRangeException("reset_time", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("reset_time");
        }
        set { this.Properties["reset_time"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Hour() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hour(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Hour FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
