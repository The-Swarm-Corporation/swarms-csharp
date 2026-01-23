using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.AutoSwarmBuilder;

/// <summary>
/// Schema for the Auto Swarm Builder API response.
///
/// <para>Attributes:     success (bool): Whether the swarm was built successfully.
///     job_id (Optional[str]): The job ID of the swarm.     outputs (Optional[dict]):
/// The outputs of the auto swarms builder.     type (Optional[str]): The type of
/// the swarm execution.     timestamp (Optional[str]): The timestamp of the swarm
/// execution.     usage (Optional[dict]): The usage statistics of the swarm execution.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AutoSwarmBuilderCreateCompletionResponse,
        AutoSwarmBuilderCreateCompletionResponseFromRaw
    >)
)]
public sealed record class AutoSwarmBuilderCreateCompletionResponse : JsonModel
{
    /// <summary>
    /// Whether the swarm was built successfully.
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// The job ID of the swarm.
    /// </summary>
    public string? JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// The outputs of the auto swarms builder.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("outputs");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "outputs",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The timestamp of the swarm execution.
    /// </summary>
    public string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The type of the swarm execution.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The usage of the swarm execution.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Usage
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
        _ = this.Success;
        _ = this.JobID;
        _ = this.Outputs;
        _ = this.Timestamp;
        _ = this.Type;
        _ = this.Usage;
    }

    public AutoSwarmBuilderCreateCompletionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoSwarmBuilderCreateCompletionResponse(
        AutoSwarmBuilderCreateCompletionResponse autoSwarmBuilderCreateCompletionResponse
    )
        : base(autoSwarmBuilderCreateCompletionResponse) { }
#pragma warning restore CS8618

    public AutoSwarmBuilderCreateCompletionResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoSwarmBuilderCreateCompletionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoSwarmBuilderCreateCompletionResponseFromRaw.FromRawUnchecked"/>
    public static AutoSwarmBuilderCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutoSwarmBuilderCreateCompletionResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class AutoSwarmBuilderCreateCompletionResponseFromRaw
    : IFromRawJson<AutoSwarmBuilderCreateCompletionResponse>
{
    /// <inheritdoc/>
    public AutoSwarmBuilderCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutoSwarmBuilderCreateCompletionResponse.FromRawUnchecked(rawData);
}
