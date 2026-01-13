using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.AdvancedResearch;

[JsonConverter(
    typeof(JsonModelConverter<
        AdvancedResearchCreateCompletionResponse,
        AdvancedResearchCreateCompletionResponseFromRaw
    >)
)]
public sealed record class AdvancedResearchCreateCompletionResponse : JsonModel
{
    /// <summary>
    /// The id of the advanced research session
    /// </summary>
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The number of characters per source used for the advanced research session
    /// </summary>
    public required long? CharactersPerSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("characters_per_source");
        }
        init { this._rawData.Set("characters_per_source", value); }
    }

    /// <summary>
    /// The description of the advanced research session
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the advanced research session
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The outputs of the advanced research session
    /// </summary>
    public required JsonElement Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("outputs");
        }
        init { this._rawData.Set("outputs", value); }
    }

    /// <summary>
    /// The number of sources used for the advanced research session
    /// </summary>
    public required long? Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sources");
        }
        init { this._rawData.Set("sources", value); }
    }

    /// <summary>
    /// The timestamp of the advanced research session
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
    /// The usage of the advanced research session
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("usage");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "usage",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharactersPerSource;
        _ = this.Description;
        _ = this.Name;
        _ = this.Outputs;
        _ = this.Sources;
        _ = this.Timestamp;
        _ = this.Usage;
    }

    public AdvancedResearchCreateCompletionResponse() { }

    public AdvancedResearchCreateCompletionResponse(
        AdvancedResearchCreateCompletionResponse advancedResearchCreateCompletionResponse
    )
        : base(advancedResearchCreateCompletionResponse) { }

    public AdvancedResearchCreateCompletionResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedResearchCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdvancedResearchCreateCompletionResponseFromRaw.FromRawUnchecked"/>
    public static AdvancedResearchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdvancedResearchCreateCompletionResponseFromRaw
    : IFromRawJson<AdvancedResearchCreateCompletionResponse>
{
    /// <inheritdoc/>
    public AdvancedResearchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AdvancedResearchCreateCompletionResponse.FromRawUnchecked(rawData);
}
