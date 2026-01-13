using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The list of available tools.
    /// </summary>
    public IReadOnlyList<string>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolListAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
