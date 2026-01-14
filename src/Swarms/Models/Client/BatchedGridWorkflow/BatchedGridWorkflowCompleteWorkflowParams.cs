using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AgentSpec>>(
                "agent_completions"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AgentSpec>?>(
                "agent_completions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The description of the batched grid workflow.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The images to be used by the batched grid workflow.
    /// </summary>
    public IReadOnlyList<string>? Imgs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("imgs");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "imgs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum number of loops to be completed by the batched grid workflow.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_loops");
        }
        init { this._rawBodyData.Set("max_loops", value); }
    }

    /// <summary>
    /// The name of the batched grid workflow.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The tasks to be completed by the batched grid workflow.
    /// </summary>
    public IReadOnlyList<string>? Tasks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tasks");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tasks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public BatchedGridWorkflowCompleteWorkflowParams() { }

    public BatchedGridWorkflowCompleteWorkflowParams(
        BatchedGridWorkflowCompleteWorkflowParams batchedGridWorkflowCompleteWorkflowParams
    )
        : base(batchedGridWorkflowCompleteWorkflowParams)
    {
        this._rawBodyData = new(batchedGridWorkflowCompleteWorkflowParams._rawBodyData);
    }

    public BatchedGridWorkflowCompleteWorkflowParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchedGridWorkflowCompleteWorkflowParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
