using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Client.AdvancedResearch.Batch;

/// <summary>
/// Execute multiple advanced research sessions concurrently with independent configurations
/// for high-throughput research workflows.
/// </summary>
public sealed record class BatchCreateCompletionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The input schemas for the advanced research
    /// </summary>
    public required IReadOnlyList<InputSchema>? InputSchemas
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("input_schemas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<InputSchema>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["input_schemas"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BatchCreateCompletionParams() { }

    public BatchCreateCompletionParams(
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
    BatchCreateCompletionParams(
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

    public static BatchCreateCompletionParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/advanced-research/batch/completions"
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

[JsonConverter(typeof(ModelConverter<InputSchema, InputSchemaFromRaw>))]
public sealed record class InputSchema : ModelBase
{
    /// <summary>
    /// The configuration for the advanced research
    /// </summary>
    public required global::Swarms.Models.Client.AdvancedResearch.Batch.Config? Config
    {
        get
        {
            if (!this._rawData.TryGetValue("config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Swarms.Models.Client.AdvancedResearch.Batch.Config?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The task to be completed
    /// </summary>
    public required string? Task
    {
        get
        {
            if (!this._rawData.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["task"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The image to be used for the advanced research
    /// </summary>
    public string? Img
    {
        get
        {
            if (!this._rawData.TryGetValue("img", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["img"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Config?.Validate();
        _ = this.Task;
        _ = this.Img;
    }

    public InputSchema() { }

    public InputSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputSchemaFromRaw : IFromRaw<InputSchema>
{
    public InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputSchema.FromRawUnchecked(rawData);
}

/// <summary>
/// The configuration for the advanced research
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Swarms.Models.Client.AdvancedResearch.Batch.Config,
        global::Swarms.Models.Client.AdvancedResearch.Batch.ConfigFromRaw
    >)
)]
public sealed record class Config : ModelBase
{
    /// <summary>
    /// Description of the advanced research session
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the director agent
    /// </summary>
    public string? DirectorAgentName
    {
        get
        {
            if (!this._rawData.TryGetValue("director_agent_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["director_agent_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum loops for the director agent
    /// </summary>
    public long? DirectorMaxLoops
    {
        get
        {
            if (!this._rawData.TryGetValue("director_max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["director_max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum tokens for the director agent's output
    /// </summary>
    public long? DirectorMaxTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("director_max_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["director_max_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Model name for the director agent
    /// </summary>
    public string? DirectorModelName
    {
        get
        {
            if (!this._rawData.TryGetValue("director_model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["director_model_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum characters to return from the Exa search tool
    /// </summary>
    public long? ExaSearchMaxCharacters
    {
        get
        {
            if (!this._rawData.TryGetValue("exa_search_max_characters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exa_search_max_characters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of results to return from the Exa search tool
    /// </summary>
    public long? ExaSearchNumResults
    {
        get
        {
            if (!this._rawData.TryGetValue("exa_search_num_results", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exa_search_num_results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of research loops to run
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this._rawData.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the advanced research session
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Model name for worker agents
    /// </summary>
    public string? WorkerModelName
    {
        get
        {
            if (!this._rawData.TryGetValue("worker_model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["worker_model_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static global::Swarms.Models.Client.AdvancedResearch.Batch.Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRaw<global::Swarms.Models.Client.AdvancedResearch.Batch.Config>
{
    public global::Swarms.Models.Client.AdvancedResearch.Batch.Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Swarms.Models.Client.AdvancedResearch.Batch.Config.FromRawUnchecked(rawData);
}
