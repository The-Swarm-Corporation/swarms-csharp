using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.Tools;

[JsonConverter(
    typeof(JsonModelConverter<ToolListAvailableResponse, ToolListAvailableResponseFromRaw>)
)]
public sealed record class ToolListAvailableResponse : JsonModel
{
    /// <summary>
    /// The status of the available tools.
    /// </summary>
    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The list of available tools.
    /// </summary>
    public IReadOnlyList<string>? Tools
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "tools"); }
        init { JsonModel.Set(this._rawData, "tools", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Tools;
    }

    public ToolListAvailableResponse() { }

    public ToolListAvailableResponse(ToolListAvailableResponse toolListAvailableResponse)
        : base(toolListAvailableResponse) { }

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

    /// <inheritdoc cref="ToolListAvailableResponseFromRaw.FromRawUnchecked"/>
    public static ToolListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolListAvailableResponseFromRaw : IFromRawJson<ToolListAvailableResponse>
{
    /// <inheritdoc/>
    public ToolListAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolListAvailableResponse.FromRawUnchecked(rawData);
}
