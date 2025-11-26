using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.Rate;

[JsonConverter(typeof(ModelConverter<RateGetLimitsResponse, RateGetLimitsResponseFromRaw>))]
public sealed record class RateGetLimitsResponse : ModelBase
{
    /// <summary>
    /// The configured rate limits based on the user's subscription tier.
    /// </summary>
    public required Limits? Limits
    {
        get
        {
            if (!this._rawData.TryGetValue("limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Limits?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["limits"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("rate_limits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RateLimits?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["rate_limits"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tier"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("success", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["success"] = JsonSerializer.SerializeToElement(
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

    public RateGetLimitsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateGetLimitsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static RateGetLimitsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateGetLimitsResponseFromRaw : IFromRaw<RateGetLimitsResponse>
{
    public RateGetLimitsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateGetLimitsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The configured rate limits based on the user's subscription tier.
/// </summary>
[JsonConverter(typeof(ModelConverter<Limits, LimitsFromRaw>))]
public sealed record class Limits : ModelBase
{
    /// <summary>
    /// The maximum number of requests allowed per day.
    /// </summary>
    public required long MaximumRequestsPerDay
    {
        get
        {
            if (!this._rawData.TryGetValue("maximum_requests_per_day", out JsonElement element))
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
            this._rawData["maximum_requests_per_day"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("maximum_requests_per_hour", out JsonElement element))
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
            this._rawData["maximum_requests_per_hour"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("maximum_requests_per_minute", out JsonElement element))
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
            this._rawData["maximum_requests_per_minute"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("tokens_per_agent", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'tokens_per_agent' cannot be null",
                    new ArgumentOutOfRangeException("tokens_per_agent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tokens_per_agent"] = JsonSerializer.SerializeToElement(
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

    public Limits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Limits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Limits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LimitsFromRaw : IFromRaw<Limits>
{
    public Limits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Limits.FromRawUnchecked(rawData);
}

/// <summary>
/// Current rate limit usage information for different time windows.
/// </summary>
[JsonConverter(typeof(ModelConverter<RateLimits, RateLimitsFromRaw>))]
public sealed record class RateLimits : ModelBase
{
    /// <summary>
    /// Rate limit information for the last day.
    /// </summary>
    public required Day Day
    {
        get
        {
            if (!this._rawData.TryGetValue("day", out JsonElement element))
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
            this._rawData["day"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("hour", out JsonElement element))
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
            this._rawData["hour"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("minute", out JsonElement element))
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
            this._rawData["minute"] = JsonSerializer.SerializeToElement(
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

    public RateLimits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static RateLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateLimitsFromRaw : IFromRaw<RateLimits>
{
    public RateLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateLimits.FromRawUnchecked(rawData);
}

/// <summary>
/// Rate limit information for the last day.
/// </summary>
[JsonConverter(typeof(ModelConverter<Day, DayFromRaw>))]
public sealed record class Day : ModelBase
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this._rawData.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["count"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exceeded"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["limit"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["remaining"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reset_time", out JsonElement element))
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
            this._rawData["reset_time"] = JsonSerializer.SerializeToElement(
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

    public Day(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Day(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Day FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DayFromRaw : IFromRaw<Day>
{
    public Day FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Day.FromRawUnchecked(rawData);
}

/// <summary>
/// Rate limit information for the last hour.
/// </summary>
[JsonConverter(typeof(ModelConverter<Hour, HourFromRaw>))]
public sealed record class Hour : ModelBase
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this._rawData.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["count"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exceeded"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["limit"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["remaining"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reset_time", out JsonElement element))
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
            this._rawData["reset_time"] = JsonSerializer.SerializeToElement(
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

    public Hour(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hour(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Hour FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HourFromRaw : IFromRaw<Hour>
{
    public Hour FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Hour.FromRawUnchecked(rawData);
}

/// <summary>
/// Rate limit information for the last minute.
/// </summary>
[JsonConverter(typeof(ModelConverter<Minute, MinuteFromRaw>))]
public sealed record class Minute : ModelBase
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this._rawData.TryGetValue("count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["count"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("exceeded", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'exceeded' cannot be null",
                    new ArgumentOutOfRangeException("exceeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exceeded"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("limit", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'limit' cannot be null",
                    new ArgumentOutOfRangeException("limit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["limit"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("remaining", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'remaining' cannot be null",
                    new ArgumentOutOfRangeException("remaining", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["remaining"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reset_time", out JsonElement element))
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
            this._rawData["reset_time"] = JsonSerializer.SerializeToElement(
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

    public Minute(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Minute(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Minute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinuteFromRaw : IFromRaw<Minute>
{
    public Minute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minute.FromRawUnchecked(rawData);
}
