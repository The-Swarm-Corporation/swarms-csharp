using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.AdvancedResearch.Batch;

[JsonConverter(
    typeof(ModelConverter<BatchCreateCompletionResponse, BatchCreateCompletionResponseFromRaw>)
)]
public sealed record class BatchCreateCompletionResponse : ModelBase
{
    /// <summary>
    /// The id of the advanced research session
    /// </summary>
    public required string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The number of characters per source used for the advanced research session
    /// </summary>
    public required long? CharactersPerSource
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "characters_per_source"); }
        init { ModelBase.Set(this._rawData, "characters_per_source", value); }
    }

    /// <summary>
    /// The description of the advanced research session
    /// </summary>
    public required string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The name of the advanced research session
    /// </summary>
    public required string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The outputs of the advanced research session
    /// </summary>
    public required JsonElement Outputs
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "outputs"); }
        init { ModelBase.Set(this._rawData, "outputs", value); }
    }

    /// <summary>
    /// The number of sources used for the advanced research session
    /// </summary>
    public required long? Sources
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "sources"); }
        init { ModelBase.Set(this._rawData, "sources", value); }
    }

    /// <summary>
    /// The timestamp of the advanced research session
    /// </summary>
    public required string? Timestamp
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The usage of the advanced research session
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Usage
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "usage"
            );
        }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

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

    public BatchCreateCompletionResponse() { }

    public BatchCreateCompletionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BatchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchCreateCompletionResponseFromRaw : IFromRaw<BatchCreateCompletionResponse>
{
    public BatchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchCreateCompletionResponse.FromRawUnchecked(rawData);
}
