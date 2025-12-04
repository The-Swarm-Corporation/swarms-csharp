using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.Rate;

[JsonConverter(typeof(ModelConverter<RateGetLimitsResponse, RateGetLimitsResponseFromRaw>))]
public sealed record class RateGetLimitsResponse : ModelBase
{
    /// <summary>
    /// The configured rate limits based on the user's subscription tier.
    /// </summary>
    public required Limits? Limits
    {
        get { return ModelBase.GetNullableClass<Limits>(this.RawData, "limits"); }
        init { ModelBase.Set(this._rawData, "limits", value); }
    }

    /// <summary>
    /// Current rate limit usage information for different time windows.
    /// </summary>
    public required RateLimits? RateLimits
    {
        get { return ModelBase.GetNullableClass<RateLimits>(this.RawData, "rate_limits"); }
        init { ModelBase.Set(this._rawData, "rate_limits", value); }
    }

    /// <summary>
    /// The user's current subscription tier (free or premium).
    /// </summary>
    public required string? Tier
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tier"); }
        init { ModelBase.Set(this._rawData, "tier", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limits information was retrieved.
    /// </summary>
    public required string? Timestamp
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// Indicates whether the rate limits request was successful.
    /// </summary>
    public bool? Success
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Limits?.Validate();
        this.RateLimits?.Validate();
        _ = this.Tier;
        _ = this.Timestamp;
        _ = this.Success;
    }

    public RateGetLimitsResponse() { }

    public RateGetLimitsResponse(RateGetLimitsResponse rateGetLimitsResponse)
        : base(rateGetLimitsResponse) { }

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

    /// <inheritdoc cref="RateGetLimitsResponseFromRaw.FromRawUnchecked"/>
    public static RateGetLimitsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateGetLimitsResponseFromRaw : IFromRaw<RateGetLimitsResponse>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_day"); }
        init { ModelBase.Set(this._rawData, "maximum_requests_per_day", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per hour.
    /// </summary>
    public required long MaximumRequestsPerHour
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_hour"); }
        init { ModelBase.Set(this._rawData, "maximum_requests_per_hour", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per minute.
    /// </summary>
    public required long MaximumRequestsPerMinute
    {
        get
        {
            return ModelBase.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_minute");
        }
        init { ModelBase.Set(this._rawData, "maximum_requests_per_minute", value); }
    }

    /// <summary>
    /// The maximum number of tokens allowed per agent.
    /// </summary>
    public required long TokensPerAgent
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "tokens_per_agent"); }
        init { ModelBase.Set(this._rawData, "tokens_per_agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaximumRequestsPerDay;
        _ = this.MaximumRequestsPerHour;
        _ = this.MaximumRequestsPerMinute;
        _ = this.TokensPerAgent;
    }

    public Limits() { }

    public Limits(Limits limits)
        : base(limits) { }

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

    /// <inheritdoc cref="LimitsFromRaw.FromRawUnchecked"/>
    public static Limits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LimitsFromRaw : IFromRaw<Limits>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<Day>(this.RawData, "day"); }
        init { ModelBase.Set(this._rawData, "day", value); }
    }

    /// <summary>
    /// Rate limit information for the last hour.
    /// </summary>
    public required Hour Hour
    {
        get { return ModelBase.GetNotNullClass<Hour>(this.RawData, "hour"); }
        init { ModelBase.Set(this._rawData, "hour", value); }
    }

    /// <summary>
    /// Rate limit information for the last minute.
    /// </summary>
    public required Minute Minute
    {
        get { return ModelBase.GetNotNullClass<Minute>(this.RawData, "minute"); }
        init { ModelBase.Set(this._rawData, "minute", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Day.Validate();
        this.Hour.Validate();
        this.Minute.Validate();
    }

    public RateLimits() { }

    public RateLimits(RateLimits rateLimits)
        : base(rateLimits) { }

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

    /// <inheritdoc cref="RateLimitsFromRaw.FromRawUnchecked"/>
    public static RateLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateLimitsFromRaw : IFromRaw<RateLimits>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "count"); }
        init { ModelBase.Set(this._rawData, "count", value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "exceeded"); }
        init { ModelBase.Set(this._rawData, "exceeded", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "remaining"); }
        init { ModelBase.Set(this._rawData, "remaining", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "reset_time"); }
        init { ModelBase.Set(this._rawData, "reset_time", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Day() { }

    public Day(Day day)
        : base(day) { }

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

    /// <inheritdoc cref="DayFromRaw.FromRawUnchecked"/>
    public static Day FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DayFromRaw : IFromRaw<Day>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "count"); }
        init { ModelBase.Set(this._rawData, "count", value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "exceeded"); }
        init { ModelBase.Set(this._rawData, "exceeded", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "remaining"); }
        init { ModelBase.Set(this._rawData, "remaining", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "reset_time"); }
        init { ModelBase.Set(this._rawData, "reset_time", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Hour() { }

    public Hour(Hour hour)
        : base(hour) { }

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

    /// <inheritdoc cref="HourFromRaw.FromRawUnchecked"/>
    public static Hour FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HourFromRaw : IFromRaw<Hour>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "count"); }
        init { ModelBase.Set(this._rawData, "count", value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "exceeded"); }
        init { ModelBase.Set(this._rawData, "exceeded", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "remaining"); }
        init { ModelBase.Set(this._rawData, "remaining", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "reset_time"); }
        init { ModelBase.Set(this._rawData, "reset_time", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Exceeded;
        _ = this.Limit;
        _ = this.Remaining;
        _ = this.ResetTime;
    }

    public Minute() { }

    public Minute(Minute minute)
        : base(minute) { }

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

    /// <inheritdoc cref="MinuteFromRaw.FromRawUnchecked"/>
    public static Minute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinuteFromRaw : IFromRaw<Minute>
{
    /// <inheritdoc/>
    public Minute FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minute.FromRawUnchecked(rawData);
}
