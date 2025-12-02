using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.BatchedGridWorkflow;

[JsonConverter(
    typeof(ModelConverter<
        BatchedGridWorkflowCompleteWorkflowResponse,
        BatchedGridWorkflowCompleteWorkflowResponseFromRaw
    >)
)]
public sealed record class BatchedGridWorkflowCompleteWorkflowResponse : ModelBase
{
    /// <summary>
    /// The description of the batched grid workflow.
    /// </summary>
    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The job ID of the batched grid workflow.
    /// </summary>
    public required string JobID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "job_id"); }
        init { ModelBase.Set(this._rawData, "job_id", value); }
    }

    /// <summary>
    /// The name of the batched grid workflow.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The outputs of the batched grid workflow.
    /// </summary>
    public required JsonElement Outputs
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "outputs"); }
        init { ModelBase.Set(this._rawData, "outputs", value); }
    }

    /// <summary>
    /// The status of the batched grid workflow.
    /// </summary>
    public required string Status
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The timestamp of the batched grid workflow.
    /// </summary>
    public required string Timestamp
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The usage of the batched grid workflow.
    /// </summary>
    public required Usage Usage
    {
        get { return ModelBase.GetNotNullClass<Usage>(this.RawData, "usage"); }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

    public override void Validate()
    {
        _ = this.Description;
        _ = this.JobID;
        _ = this.Name;
        _ = this.Outputs;
        _ = this.Status;
        _ = this.Timestamp;
        this.Usage.Validate();
    }

    public BatchedGridWorkflowCompleteWorkflowResponse() { }

    public BatchedGridWorkflowCompleteWorkflowResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchedGridWorkflowCompleteWorkflowResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BatchedGridWorkflowCompleteWorkflowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchedGridWorkflowCompleteWorkflowResponseFromRaw
    : IFromRaw<BatchedGridWorkflowCompleteWorkflowResponse>
{
    public BatchedGridWorkflowCompleteWorkflowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchedGridWorkflowCompleteWorkflowResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The usage of the batched grid workflow.
/// </summary>
[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
{
    /// <summary>
    /// The cost in credits for the agents.
    /// </summary>
    public required double CostPerAgent
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "cost_per_agent"); }
        init { ModelBase.Set(this._rawData, "cost_per_agent", value); }
    }

    /// <summary>
    /// The number of input tokens.
    /// </summary>
    public required long InputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "input_tokens"); }
        init { ModelBase.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens.
    /// </summary>
    public required long OutputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { ModelBase.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The cost in credits for the tokens.
    /// </summary>
    public required double TokenCost
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "token_cost"); }
        init { ModelBase.Set(this._rawData, "token_cost", value); }
    }

    /// <summary>
    /// The total number of tokens.
    /// </summary>
    public required long TotalTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total_tokens"); }
        init { ModelBase.Set(this._rawData, "total_tokens", value); }
    }

    public override void Validate()
    {
        _ = this.CostPerAgent;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.TokenCost;
        _ = this.TotalTokens;
    }

    public Usage() { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
