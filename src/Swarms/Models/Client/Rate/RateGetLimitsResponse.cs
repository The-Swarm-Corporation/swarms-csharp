using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

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
            if (!this._properties.TryGetValue("limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Limits?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["limits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current rate limit usage information for different time windows.
    /// </summary>
    public required RateLimits? RateLimits
    {
        get
        {
            if (!this._properties.TryGetValue("rate_limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RateLimits?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["rate_limits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user's current subscription tier (free or premium).
    /// </summary>
    public required string? Tier
    {
        get
        {
            if (!this._properties.TryGetValue("tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO timestamp when the rate limits information was retrieved.
    /// </summary>
    public required string? Timestamp
    {
        get
        {
            if (!this._properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the rate limits request was successful.
    /// </summary>
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
        this.Limits?.Validate();
        this.RateLimits?.Validate();
        _ = this.Tier;
        _ = this.Timestamp;
        _ = this.Success;
    }

    public RateGetLimitsResponse() { }

    public RateGetLimitsResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateGetLimitsResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RateGetLimitsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

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
            if (!this._properties.TryGetValue("maximum_requests_per_day", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'maximum_requests_per_day' cannot be null",
                    new ArgumentOutOfRangeException(
                        "maximum_requests_per_day",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_requests_per_day"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("maximum_requests_per_hour", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'maximum_requests_per_hour' cannot be null",
                    new ArgumentOutOfRangeException(
                        "maximum_requests_per_hour",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_requests_per_hour"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "maximum_requests_per_minute",
                    out JsonElement element
                )
            )
                throw new SwarmsClientInvalidDataException(
                    "'maximum_requests_per_minute' cannot be null",
                    new ArgumentOutOfRangeException(
                        "maximum_requests_per_minute",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_requests_per_minute"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tokens_per_agent", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'tokens_per_agent' cannot be null",
                    new ArgumentOutOfRangeException("tokens_per_agent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tokens_per_agent"] = JsonSerializer.SerializeToElement(
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

    public Limits(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Limits(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Limits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

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
            if (!this._properties.TryGetValue("day", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'day' cannot be null",
                    new ArgumentOutOfRangeException("day", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Day>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'day' cannot be null",
                    new ArgumentNullException("day")
                );
        }
        init
        {
            this._properties["day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Rate limit information for the last hour.
    /// </summary>
    public required Hour Hour
    {
        get
        {
            if (!this._properties.TryGetValue("hour", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'hour' cannot be null",
                    new ArgumentOutOfRangeException("hour", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Hour>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'hour' cannot be null",
                    new ArgumentNullException("hour")
                );
        }
        init
        {
            this._properties["hour"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Rate limit information for the last minute.
    /// </summary>
    public required Minute Minute
    {
        get
        {
            if (!this._properties.TryGetValue("minute", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'minute' cannot be null",
                    new ArgumentOutOfRangeException("minute", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Minute>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'minute' cannot be null",
                    new ArgumentNullException("minute")
                );
        }
        init
        {
            this._properties["minute"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Day.Validate();
        this.Hour.Validate();
        this.Minute.Validate();
    }

    public RateLimits() { }

    public RateLimits(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimits(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RateLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Rate limit information for the last day.
/// </summary>
[JsonConverter(typeof(ModelConverter<Day>))]
public sealed record class Day : ModelBase, IFromRaw<Day>
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this._properties.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get
        {
            if (!this._properties.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["exceeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get
        {
            if (!this._properties.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get
        {
            if (!this._properties.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["remaining"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get
        {
            if (!this._properties.TryGetValue("reset_time", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentOutOfRangeException("reset_time", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentNullException("reset_time")
                );
        }
        init
        {
            this._properties["reset_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Day() { }

    public Day(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Day(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Day FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

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
            if (!this._properties.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get
        {
            if (!this._properties.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["exceeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get
        {
            if (!this._properties.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get
        {
            if (!this._properties.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["remaining"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get
        {
            if (!this._properties.TryGetValue("reset_time", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentOutOfRangeException("reset_time", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentNullException("reset_time")
                );
        }
        init
        {
            this._properties["reset_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Hour(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hour(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Hour FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Rate limit information for the last minute.
/// </summary>
[JsonConverter(typeof(ModelConverter<Minute>))]
public sealed record class Minute : ModelBase, IFromRaw<Minute>
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this._properties.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get
        {
            if (!this._properties.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["exceeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get
        {
            if (!this._properties.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get
        {
            if (!this._properties.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["remaining"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get
        {
            if (!this._properties.TryGetValue("reset_time", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentOutOfRangeException("reset_time", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'reset_time' cannot be null",
                    new ArgumentNullException("reset_time")
                );
        }
        init
        {
            this._properties["reset_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Minute() { }

    public Minute(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Minute(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Minute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
