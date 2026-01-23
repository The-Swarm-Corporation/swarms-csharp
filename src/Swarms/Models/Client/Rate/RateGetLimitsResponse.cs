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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Limits>("limits");
        }
        init { this._rawData.Set("limits", value); }
    }

    /// <summary>
    /// Current rate limit usage information for different time windows.
    /// </summary>
    public required RateLimits? RateLimits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RateLimits>("rate_limits");
        }
        init { this._rawData.Set("rate_limits", value); }
    }

    /// <summary>
    /// The user's current subscription tier (free or premium).
    /// </summary>
    public required string? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier");
        }
        init { this._rawData.Set("tier", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limits information was retrieved.
    /// </summary>
    public required string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// Indicates whether the rate limits request was successful.
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateGetLimitsResponse(RateGetLimitsResponse rateGetLimitsResponse)
        : base(rateGetLimitsResponse) { }
#pragma warning restore CS8618

    public RateGetLimitsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateGetLimitsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maximum_requests_per_day");
        }
        init { this._rawData.Set("maximum_requests_per_day", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per hour.
    /// </summary>
    public required long MaximumRequestsPerHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maximum_requests_per_hour");
        }
        init { this._rawData.Set("maximum_requests_per_hour", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed per minute.
    /// </summary>
    public required long MaximumRequestsPerMinute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maximum_requests_per_minute");
        }
        init { this._rawData.Set("maximum_requests_per_minute", value); }
    }

    /// <summary>
    /// The maximum number of tokens allowed per agent.
    /// </summary>
    public required long TokensPerAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tokens_per_agent");
        }
        init { this._rawData.Set("tokens_per_agent", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Limits(Limits limits)
        : base(limits) { }
#pragma warning restore CS8618

    public Limits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Limits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RateLimitWindow>("day");
        }
        init { this._rawData.Set("day", value); }
    }

    /// <summary>
    /// Rate limit information for the last hour.
    /// </summary>
    public required RateLimitWindow Hour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RateLimitWindow>("hour");
        }
        init { this._rawData.Set("hour", value); }
    }

    /// <summary>
    /// Rate limit information for the last minute.
    /// </summary>
    public required RateLimitWindow Minute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RateLimitWindow>("minute");
        }
        init { this._rawData.Set("minute", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Day.Validate();
        this.Hour.Validate();
        this.Minute.Validate();
    }

    public RateLimits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateLimits(RateLimits rateLimits)
        : base(rateLimits) { }
#pragma warning restore CS8618

    public RateLimits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
