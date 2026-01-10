using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.Rate;

[JsonConverter(typeof(JsonModelConverter<RateGetLimitsResponse, RateGetLimitsResponseFromRaw>))]
public sealed record class RateGetLimitsResponse : JsonModel
{
    /// <summary>
    /// The configured rate limits based on the user's subscription tier.
    /// </summary>
    public required Limits? Limits
    {
        get { return JsonModel.GetNullableClass<Limits>(this.RawData, "limits"); }
        init { JsonModel.Set(this._rawData, "limits", value); }
    }

    /// <summary>
    /// Current rate limit usage information for different time windows.
    /// </summary>
    public required RateLimits? RateLimits
    {
        get { return JsonModel.GetNullableClass<RateLimits>(this.RawData, "rate_limits"); }
        init { JsonModel.Set(this._rawData, "rate_limits", value); }
    }

    /// <summary>
    /// The user's current subscription tier (free or premium).
    /// </summary>
    public required string? Tier
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tier"); }
        init { JsonModel.Set(this._rawData, "tier", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limits information was retrieved.
    /// </summary>
    public required string? Timestamp
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "timestamp"); }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// Indicates whether the rate limits request was successful.
    /// </summary>
    public bool? Success
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "success"); }
        init { JsonModel.Set(this._rawData, "success", value); }
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

class RateGetLimitsResponseFromRaw : IFromRawJson<RateGetLimitsResponse>
{
    /// <inheritdoc/>
    public RateGetLimitsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateGetLimitsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The configured rate limits based on the user's subscription tier.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Limits, LimitsFromRaw>))]
public sealed record class Limits : JsonModel
{
    /// <summary>
    /// The maximum number of requests allowed per day.
    /// </summary>
    public required long MaximumRequestsPerDay
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_day"); }
        init { JsonModel.Set(this._rawData, "maximum_requests_per_day", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per hour.
    /// </summary>
    public required long MaximumRequestsPerHour
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_hour"); }
        init { JsonModel.Set(this._rawData, "maximum_requests_per_hour", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per minute.
    /// </summary>
    public required long MaximumRequestsPerMinute
    {
        get
        {
            return JsonModel.GetNotNullStruct<long>(this.RawData, "maximum_requests_per_minute");
        }
        init { JsonModel.Set(this._rawData, "maximum_requests_per_minute", value); }
    }

    /// <summary>
    /// The maximum number of tokens allowed per agent.
    /// </summary>
    public required long TokensPerAgent
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "tokens_per_agent"); }
        init { JsonModel.Set(this._rawData, "tokens_per_agent", value); }
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

class LimitsFromRaw : IFromRawJson<Limits>
{
    /// <inheritdoc/>
    public Limits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Limits.FromRawUnchecked(rawData);
}

/// <summary>
/// Current rate limit usage information for different time windows.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RateLimits, RateLimitsFromRaw>))]
public sealed record class RateLimits : JsonModel
{
    /// <summary>
    /// Rate limit information for the last day.
    /// </summary>
    public required RateLimitWindow Day
    {
        get { return JsonModel.GetNotNullClass<RateLimitWindow>(this.RawData, "day"); }
        init { JsonModel.Set(this._rawData, "day", value); }
    }

    /// <summary>
    /// Rate limit information for the last hour.
    /// </summary>
    public required RateLimitWindow Hour
    {
        get { return JsonModel.GetNotNullClass<RateLimitWindow>(this.RawData, "hour"); }
        init { JsonModel.Set(this._rawData, "hour", value); }
    }

    /// <summary>
    /// Rate limit information for the last minute.
    /// </summary>
    public required RateLimitWindow Minute
    {
        get { return JsonModel.GetNotNullClass<RateLimitWindow>(this.RawData, "minute"); }
        init { JsonModel.Set(this._rawData, "minute", value); }
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

class RateLimitsFromRaw : IFromRawJson<RateLimits>
{
    /// <inheritdoc/>
    public RateLimits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateLimits.FromRawUnchecked(rawData);
}
