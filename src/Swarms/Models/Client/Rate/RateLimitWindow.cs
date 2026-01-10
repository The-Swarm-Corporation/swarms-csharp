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
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "count"); }
        init { JsonModel.Set(this._rawData, "count", value); }
    }

    /// <summary>
    /// Whether the rate limit has been exceeded for this time window.
    /// </summary>
    public required bool Exceeded
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "exceeded"); }
        init { JsonModel.Set(this._rawData, "exceeded", value); }
    }

    /// <summary>
    /// The maximum number of requests allowed in this time window.
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// The number of requests remaining before hitting the limit.
    /// </summary>
    public required long Remaining
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "remaining"); }
        init { JsonModel.Set(this._rawData, "remaining", value); }
    }

    /// <summary>
    /// ISO timestamp when the rate limit will reset.
    /// </summary>
    public required string ResetTime
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "reset_time"); }
        init { JsonModel.Set(this._rawData, "reset_time", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimitWindow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
