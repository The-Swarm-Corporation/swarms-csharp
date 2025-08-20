using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Client.Rate.RateGetLimitsResponseProperties;

/// <summary>
/// The configured rate limits based on the user's subscription tier.
/// </summary>
[JsonConverter(typeof(ModelConverter<Limits>))]
public sealed record class Limits : ModelBase, IFromRaw<Limits>
{
    /// <summary>
    /// The maximum number of requests allowed per day.
    /// </summary>
    public required long MaximumRequestsPerDay
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_requests_per_day", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "maximum_requests_per_day",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_requests_per_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of requests allowed per hour.
    /// </summary>
    public required long MaximumRequestsPerHour
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_requests_per_hour", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "maximum_requests_per_hour",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_requests_per_hour"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of requests allowed per minute.
    /// </summary>
    public required long MaximumRequestsPerMinute
    {
        get
        {
            if (
                !this.Properties.TryGetValue("maximum_requests_per_minute", out JsonElement element)
            )
                throw new ArgumentOutOfRangeException(
                    "maximum_requests_per_minute",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_requests_per_minute"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of tokens allowed per agent.
    /// </summary>
    public required long TokensPerAgent
    {
        get
        {
            if (!this.Properties.TryGetValue("tokens_per_agent", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "tokens_per_agent",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tokens_per_agent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MaximumRequestsPerDay;
        _ = this.MaximumRequestsPerHour;
        _ = this.MaximumRequestsPerMinute;
        _ = this.TokensPerAgent;
    }

    public Limits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Limits(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Limits FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
