using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.Rate;

[JsonConverter(typeof(JsonModelConverter<RateLimitWindow, RateLimitWindowFromRaw>))]
public sealed record class RateLimitWindow : JsonModel
{
    /// <summary>
    /// The number of requests made in this time window.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("exceeded");
        }
        init { this._rawData.Set("exceeded", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("remaining");
        }
        init { this._rawData.Set("remaining", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reset_time");
        }
        init { this._rawData.Set("reset_time", value); }
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

    public RateLimitWindow() { }

    public RateLimitWindow(RateLimitWindow rateLimitWindow)
        : base(rateLimitWindow) { }

    public RateLimitWindow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimitWindow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateLimitWindowFromRaw.FromRawUnchecked"/>
    public static RateLimitWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateLimitWindowFromRaw : IFromRawJson<RateLimitWindow>
{
    /// <inheritdoc/>
    public RateLimitWindow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateLimitWindow.FromRawUnchecked(rawData);
}
