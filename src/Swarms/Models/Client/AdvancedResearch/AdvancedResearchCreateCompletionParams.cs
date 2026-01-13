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
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The configuration for the advanced research
    /// </summary>
    public required Config? Config
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Config>("config");
        }
        init { this._rawBodyData.Set("config", value); }
    }

    /// <summary>
    /// The task to be completed
    /// </summary>
    public required string? Task
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("task");
        }
        init { this._rawBodyData.Set("task", value); }
    }

    /// <summary>
    /// The image to be used for the advanced research
    /// </summary>
    public string? Img
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("img");
        }
        init { this._rawBodyData.Set("img", value); }
    }

    public AdvancedResearchCreateCompletionParams() { }

    public AdvancedResearchCreateCompletionParams(
        AdvancedResearchCreateCompletionParams advancedResearchCreateCompletionParams
    )
        : base(advancedResearchCreateCompletionParams)
    {
        this._rawBodyData = new(advancedResearchCreateCompletionParams._rawBodyData);
    }

    public AdvancedResearchCreateCompletionParams(
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
    AdvancedResearchCreateCompletionParams(
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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

/// <summary>
/// The configuration for the advanced research
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : JsonModel
{
    /// <summary>
    /// Description of the advanced research session
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
    /// Name of the director agent
    /// </summary>
    public string? DirectorAgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("director_agent_name");
        }
        init { this._rawData.Set("director_agent_name", value); }
    }

    /// <summary>
    /// Maximum loops for the director agent
    /// </summary>
    public long? DirectorMaxLoops
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("director_max_loops");
        }
        init { this._rawData.Set("director_max_loops", value); }
    }

    /// <summary>
    /// Maximum tokens for the director agent's output
    /// </summary>
    public long? DirectorMaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("director_max_tokens");
        }
        init { this._rawData.Set("director_max_tokens", value); }
    }

    /// <summary>
    /// Model name for the director agent
    /// </summary>
    public string? DirectorModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("director_model_name");
        }
        init { this._rawData.Set("director_model_name", value); }
    }

    /// <summary>
    /// Maximum characters to return from the Exa search tool
    /// </summary>
    public long? ExaSearchMaxCharacters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("exa_search_max_characters");
        }
        init { this._rawData.Set("exa_search_max_characters", value); }
    }

    /// <summary>
    /// Number of results to return from the Exa search tool
    /// </summary>
    public long? ExaSearchNumResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("exa_search_num_results");
        }
        init { this._rawData.Set("exa_search_num_results", value); }
    }

    /// <summary>
    /// Number of research loops to run
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_loops");
        }
        init { this._rawData.Set("max_loops", value); }
    }

    /// <summary>
    /// Name of the advanced research session
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

    /// <summary>
    /// Model name for worker agents
    /// </summary>
    public string? WorkerModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("worker_model_name");
        }
        init { this._rawData.Set("worker_model_name", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRawJson<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}
