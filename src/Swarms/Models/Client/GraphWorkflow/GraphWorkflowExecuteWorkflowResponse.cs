using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.GraphWorkflow;

/// <summary>
/// Output schema for GraphWorkflow completion responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        GraphWorkflowExecuteWorkflowResponse,
        GraphWorkflowExecuteWorkflowResponseFromRaw
    >)
)]
public sealed record class GraphWorkflowExecuteWorkflowResponse : JsonModel
{
    /// <summary>
    /// The job ID of the graph workflow.
    /// </summary>
    public required string JobID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "job_id"); }
        init { JsonModel.Set(this._rawData, "job_id", value); }
    }

    /// <summary>
    /// The outputs of the graph workflow.
    /// </summary>
    public required JsonElement Outputs
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "outputs"); }
        init { JsonModel.Set(this._rawData, "outputs", value); }
    }

    /// <summary>
    /// The status of the graph workflow.
    /// </summary>
    public required string Status
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The timestamp of the graph workflow execution.
    /// </summary>
    public required string Timestamp
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "timestamp"); }
        init { JsonModel.Set(this._rawData, "timestamp", value); }
    }

    /// <summary>
    /// The usage statistics of the workflow.
    /// </summary>
    public required Usage Usage
    {
        get { return JsonModel.GetNotNullClass<Usage>(this.RawData, "usage"); }
        init { JsonModel.Set(this._rawData, "usage", value); }
    }

    /// <summary>
    /// The description of the graph workflow.
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The name of the graph workflow.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
        _ = this.Outputs;
        _ = this.Status;
        _ = this.Timestamp;
        this.Usage.Validate();
        _ = this.Description;
        _ = this.Name;
    }

    public GraphWorkflowExecuteWorkflowResponse() { }

    public GraphWorkflowExecuteWorkflowResponse(
        GraphWorkflowExecuteWorkflowResponse graphWorkflowExecuteWorkflowResponse
    )
        : base(graphWorkflowExecuteWorkflowResponse) { }

    public GraphWorkflowExecuteWorkflowResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphWorkflowExecuteWorkflowResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GraphWorkflowExecuteWorkflowResponseFromRaw.FromRawUnchecked"/>
    public static GraphWorkflowExecuteWorkflowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GraphWorkflowExecuteWorkflowResponseFromRaw
    : IFromRawJson<GraphWorkflowExecuteWorkflowResponse>
{
    /// <inheritdoc/>
    public GraphWorkflowExecuteWorkflowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GraphWorkflowExecuteWorkflowResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The usage statistics of the workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// The cost in credits for the agents.
    /// </summary>
    public required double CostPerAgent
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "cost_per_agent"); }
        init { JsonModel.Set(this._rawData, "cost_per_agent", value); }
    }

    /// <summary>
    /// The number of input tokens.
    /// </summary>
    public required long InputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "input_tokens"); }
        init { JsonModel.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens.
    /// </summary>
    public required long OutputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { JsonModel.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The cost in credits for the tokens.
    /// </summary>
    public required double TokenCost
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "token_cost"); }
        init { JsonModel.Set(this._rawData, "token_cost", value); }
    }

    /// <summary>
    /// The total number of tokens.
    /// </summary>
    public required long TotalTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total_tokens"); }
        init { JsonModel.Set(this._rawData, "total_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CostPerAgent;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.TokenCost;
        _ = this.TotalTokens;
    }

    public Usage() { }

    public Usage(Usage usage)
        : base(usage) { }

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

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}
