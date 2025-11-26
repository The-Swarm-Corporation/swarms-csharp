using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.AdvancedResearch;

[JsonConverter(
    typeof(ModelConverter<
        AdvancedResearchCreateCompletionResponse,
        AdvancedResearchCreateCompletionResponseFromRaw
    >)
)]
public sealed record class AdvancedResearchCreateCompletionResponse : ModelBase
{
    /// <summary>
    /// The id of the advanced research session
    /// </summary>
    public required string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of characters per source used for the advanced research session
    /// </summary>
    public required long? CharactersPerSource
    {
        get
        {
            if (!this._rawData.TryGetValue("characters_per_source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["characters_per_source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The description of the advanced research session
    /// </summary>
    public required string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the advanced research session
    /// </summary>
    public required string? Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The outputs of the advanced research session
    /// </summary>
    public required JsonElement Outputs
    {
        get
        {
            if (!this._rawData.TryGetValue("outputs", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'outputs' cannot be null",
                    new ArgumentOutOfRangeException("outputs", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["outputs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of sources used for the advanced research session
    /// </summary>
    public required long? Sources
    {
        get
        {
            if (!this._rawData.TryGetValue("sources", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["sources"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of the advanced research session
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
    /// The usage of the advanced research session
    /// </summary>
    public required Dictionary<string, JsonElement>? Usage
    {
        get
        {
            if (!this._rawData.TryGetValue("usage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public AdvancedResearchCreateCompletionResponse() { }

    public AdvancedResearchCreateCompletionResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedResearchCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AdvancedResearchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdvancedResearchCreateCompletionResponseFromRaw
    : IFromRaw<AdvancedResearchCreateCompletionResponse>
{
    public AdvancedResearchCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AdvancedResearchCreateCompletionResponse.FromRawUnchecked(rawData);
}
