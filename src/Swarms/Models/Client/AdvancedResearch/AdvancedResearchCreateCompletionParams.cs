using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.AdvancedResearch;

/// <summary>
/// Execute comprehensive research sessions with multi-source data collection, analysis,
/// and synthesis capabilities.
/// </summary>
public sealed record class AdvancedResearchCreateCompletionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The configuration for the advanced research
    /// </summary>
    public required Config? Config
    {
        get { return ModelBase.GetNullableClass<Config>(this.RawBodyData, "config"); }
        init { ModelBase.Set(this._rawBodyData, "config", value); }
    }

    /// <summary>
    /// The task to be completed
    /// </summary>
    public required string? Task
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "task"); }
        init { ModelBase.Set(this._rawBodyData, "task", value); }
    }

    /// <summary>
    /// The image to be used for the advanced research
    /// </summary>
    public string? Img
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "img"); }
        init { ModelBase.Set(this._rawBodyData, "img", value); }
    }

    public AdvancedResearchCreateCompletionParams() { }

    public AdvancedResearchCreateCompletionParams(
        AdvancedResearchCreateCompletionParams advancedResearchCreateCompletionParams
    )
        : base(advancedResearchCreateCompletionParams)
    {
        this._rawBodyData = [.. advancedResearchCreateCompletionParams._rawBodyData];
    }

    public AdvancedResearchCreateCompletionParams(
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
    AdvancedResearchCreateCompletionParams(
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
    public static AdvancedResearchCreateCompletionParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/advanced-research/completions"
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

/// <summary>
/// The configuration for the advanced research
/// </summary>
[JsonConverter(typeof(ModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : ModelBase
{
    /// <summary>
    /// Description of the advanced research session
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Name of the director agent
    /// </summary>
    public string? DirectorAgentName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "director_agent_name"); }
        init { ModelBase.Set(this._rawData, "director_agent_name", value); }
    }

    /// <summary>
    /// Maximum loops for the director agent
    /// </summary>
    public long? DirectorMaxLoops
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "director_max_loops"); }
        init { ModelBase.Set(this._rawData, "director_max_loops", value); }
    }

    /// <summary>
    /// Maximum tokens for the director agent's output
    /// </summary>
    public long? DirectorMaxTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "director_max_tokens"); }
        init { ModelBase.Set(this._rawData, "director_max_tokens", value); }
    }

    /// <summary>
    /// Model name for the director agent
    /// </summary>
    public string? DirectorModelName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "director_model_name"); }
        init { ModelBase.Set(this._rawData, "director_model_name", value); }
    }

    /// <summary>
    /// Maximum characters to return from the Exa search tool
    /// </summary>
    public long? ExaSearchMaxCharacters
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "exa_search_max_characters"); }
        init { ModelBase.Set(this._rawData, "exa_search_max_characters", value); }
    }

    /// <summary>
    /// Number of results to return from the Exa search tool
    /// </summary>
    public long? ExaSearchNumResults
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "exa_search_num_results"); }
        init { ModelBase.Set(this._rawData, "exa_search_num_results", value); }
    }

    /// <summary>
    /// Number of research loops to run
    /// </summary>
    public long? MaxLoops
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "max_loops"); }
        init { ModelBase.Set(this._rawData, "max_loops", value); }
    }

    /// <summary>
    /// Name of the advanced research session
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Model name for worker agents
    /// </summary>
    public string? WorkerModelName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "worker_model_name"); }
        init { ModelBase.Set(this._rawData, "worker_model_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.DirectorAgentName;
        _ = this.DirectorMaxLoops;
        _ = this.DirectorMaxTokens;
        _ = this.DirectorModelName;
        _ = this.ExaSearchMaxCharacters;
        _ = this.ExaSearchNumResults;
        _ = this.MaxLoops;
        _ = this.Name;
        _ = this.WorkerModelName;
    }

    public Config() { }

    public Config(Config config)
        : base(config) { }

    public Config(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRaw<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}
