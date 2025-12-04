using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Agent;

namespace Swarms.Models.Client.BatchedGridWorkflow;

/// <summary>
/// Complete a batched grid workflow with the specified input data. Enables you to
/// run a grid workflow with multiple agents and tasks in a single request.
/// </summary>
public sealed record class BatchedGridWorkflowCompleteWorkflowParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The agent completions to be completed by the batched grid workflow.
    /// </summary>
    public IReadOnlyList<AgentSpec>? AgentCompletions
    {
        get
        {
            return ModelBase.GetNullableClass<List<AgentSpec>>(
                this.RawBodyData,
                "agent_completions"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "agent_completions", value); }
    }

    /// <summary>
    /// The description of the batched grid workflow.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// The images to be used by the batched grid workflow.
    /// </summary>
    public IReadOnlyList<string>? Imgs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "imgs"); }
        init { ModelBase.Set(this._rawBodyData, "imgs", value); }
    }

    /// <summary>
    /// The maximum number of loops to be completed by the batched grid workflow.
    /// </summary>
    public long? MaxLoops
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "max_loops"); }
        init { ModelBase.Set(this._rawBodyData, "max_loops", value); }
    }

    /// <summary>
    /// The name of the batched grid workflow.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// The tasks to be completed by the batched grid workflow.
    /// </summary>
    public IReadOnlyList<string>? Tasks
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "tasks"); }
        init { ModelBase.Set(this._rawBodyData, "tasks", value); }
    }

    public BatchedGridWorkflowCompleteWorkflowParams() { }

    public BatchedGridWorkflowCompleteWorkflowParams(
        BatchedGridWorkflowCompleteWorkflowParams batchedGridWorkflowCompleteWorkflowParams
    )
        : base(batchedGridWorkflowCompleteWorkflowParams)
    {
        this._rawBodyData = [.. batchedGridWorkflowCompleteWorkflowParams._rawBodyData];
    }

    public BatchedGridWorkflowCompleteWorkflowParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchedGridWorkflowCompleteWorkflowParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static BatchedGridWorkflowCompleteWorkflowParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/batched-grid-workflow/completions"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
