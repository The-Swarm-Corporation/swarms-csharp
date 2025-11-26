using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.Tools;

[JsonConverter(typeof(ModelConverter<ToolListAvailableResponse, ToolListAvailableResponseFromRaw>))]
public sealed record class ToolListAvailableResponse : ModelBase
{
    /// <summary>
    /// The status of the available tools.
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The list of available tools.
    /// </summary>
    public List<string>? Tools
    {
        get
        {
            if (!this._rawData.TryGetValue("tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tools"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Status;
        _ = this.Tools;
    }

    public ToolListAvailableResponse() { }

    public ToolListAvailableResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolListAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ToolListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolListAvailableResponseFromRaw : IFromRaw<ToolListAvailableResponse>
{
    public ToolListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolListAvailableResponse.FromRawUnchecked(rawData);
}
