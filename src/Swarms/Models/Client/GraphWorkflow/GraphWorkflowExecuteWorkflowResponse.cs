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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// The outputs of the graph workflow.
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
    /// The status of the graph workflow.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The timestamp of the graph workflow execution.
    /// </summary>
    public required string Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The usage statistics of the workflow.
    /// </summary>
    public required Usage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Usage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// The description of the graph workflow.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the graph workflow.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GraphWorkflowExecuteWorkflowResponse(
        GraphWorkflowExecuteWorkflowResponse graphWorkflowExecuteWorkflowResponse
    )
        : base(graphWorkflowExecuteWorkflowResponse) { }
#pragma warning restore CS8618

    public GraphWorkflowExecuteWorkflowResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphWorkflowExecuteWorkflowResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cost_per_agent");
        }
        init { this._rawData.Set("cost_per_agent", value); }
    }

    /// <summary>
    /// The number of input tokens.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// The cost in credits for the tokens.
    /// </summary>
    public required double TokenCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("token_cost");
        }
        init { this._rawData.Set("token_cost", value); }
    }

    /// <summary>
    /// The total number of tokens.
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tokens");
        }
        init { this._rawData.Set("total_tokens", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
