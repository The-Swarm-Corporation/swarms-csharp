using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.AutoSwarmBuilder;

/// <summary>
/// Generate and orchestrate agent swarms autonomously using AI-powered swarm composition
/// and task decomposition.
/// </summary>
public sealed record class AutoSwarmBuilderCreateCompletionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A description of the swarm.
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
    /// The type of execution to perform.
    /// </summary>
    public ApiEnum<string, ExecutionType>? ExecutionType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExecutionType>>(
                "execution_type"
            );
        }
        init { this._rawBodyData.Set("execution_type", value); }
    }

    /// <summary>
    /// Maximum number of loops to run.
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
    /// The maximum number of tokens to use for the swarm.
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawBodyData.Set("max_tokens", value); }
    }

    /// <summary>
    /// The model name to use for the swarm.
    /// </summary>
    public string? ModelName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model_name");
        }
        init { this._rawBodyData.Set("model_name", value); }
    }

    /// <summary>
    /// The name of the swarm.
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
    /// The task for the swarm, if any.
    /// </summary>
    public string? Task
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("task");
        }
        init { this._rawBodyData.Set("task", value); }
    }

    public AutoSwarmBuilderCreateCompletionParams() { }

    public AutoSwarmBuilderCreateCompletionParams(
        AutoSwarmBuilderCreateCompletionParams autoSwarmBuilderCreateCompletionParams
    )
        : base(autoSwarmBuilderCreateCompletionParams)
    {
        this._rawBodyData = new(autoSwarmBuilderCreateCompletionParams._rawBodyData);
    }

    public AutoSwarmBuilderCreateCompletionParams(
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
    AutoSwarmBuilderCreateCompletionParams(
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
    public static AutoSwarmBuilderCreateCompletionParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/auto-swarm-builder/completions"
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
/// The type of execution to perform.
/// </summary>
[JsonConverter(typeof(ExecutionTypeConverter))]
public enum ExecutionType
{
    ReturnAgents,
    ReturnSwarmRouterConfig,
    ReturnAgentsObjects,
}

sealed class ExecutionTypeConverter : JsonConverter<ExecutionType>
{
    public override ExecutionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "return-agents" => ExecutionType.ReturnAgents,
            "return-swarm-router-config" => ExecutionType.ReturnSwarmRouterConfig,
            "return-agents-objects" => ExecutionType.ReturnAgentsObjects,
            _ => (ExecutionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExecutionType.ReturnAgents => "return-agents",
                ExecutionType.ReturnSwarmRouterConfig => "return-swarm-router-config",
                ExecutionType.ReturnAgentsObjects => "return-agents-objects",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
