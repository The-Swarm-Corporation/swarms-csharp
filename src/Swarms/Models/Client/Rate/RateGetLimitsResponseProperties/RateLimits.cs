using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Models.Client.Rate.RateGetLimitsResponseProperties.RateLimitsProperties;

namespace Swarms.Models.Client.Rate.RateGetLimitsResponseProperties;

/// <summary>
/// Current rate limit usage information for different time windows.
/// </summary>
[JsonConverter(typeof(ModelConverter<RateLimits>))]
public sealed record class RateLimits : ModelBase, IFromRaw<RateLimits>
{
    /// <summary>
    /// Rate limit information for the last day.
    /// </summary>
    public required Day Day
    {
        get
        {
            if (!this.Properties.TryGetValue("day", out JsonElement element))
                throw new ArgumentOutOfRangeException("day", "Missing required argument");

            return JsonSerializer.Deserialize<Day>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("day");
        }
        set { this.Properties["day"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Rate limit information for the last hour.
    /// </summary>
    public required Hour Hour
    {
        get
        {
            if (!this.Properties.TryGetValue("hour", out JsonElement element))
                throw new ArgumentOutOfRangeException("hour", "Missing required argument");

            return JsonSerializer.Deserialize<Hour>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("hour");
        }
        set { this.Properties["hour"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Rate limit information for the last minute.
    /// </summary>
    public required Minute Minute
    {
        get
        {
            if (!this.Properties.TryGetValue("minute", out JsonElement element))
                throw new ArgumentOutOfRangeException("minute", "Missing required argument");

            return JsonSerializer.Deserialize<Minute>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("minute");
        }
        set { this.Properties["minute"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Day.Validate();
        this.Hour.Validate();
        this.Minute.Validate();
    }

    public RateLimits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimits(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RateLimits FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
