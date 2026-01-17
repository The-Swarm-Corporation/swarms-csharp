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

namespace Swarms.Models.ReasoningAgents;

/// <summary>
/// Run a reasoning agent with the specified task.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReasoningAgentCreateCompletionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The unique name assigned to the reasoning agent.
    /// </summary>
    public string? AgentName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("agent_name");
        }
        init { this._rawBodyData.Set("agent_name", value); }
    }

    /// <summary>
    /// A detailed explanation of the reasoning agent's purpose and capabilities.
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
    /// The maximum number of times the reasoning agent is allowed to repeat its task.
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
    /// The memory capacity for the reasoning agent.
    /// </summary>
    public long? MemoryCapacity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("memory_capacity");
        }
        init { this._rawBodyData.Set("memory_capacity", value); }
    }

    /// <summary>
    /// The name of the AI model that the reasoning agent will utilize.
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
    /// The number of knowledge items to use for the reasoning agent.
    /// </summary>
    public long? NumKnowledgeItems
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("num_knowledge_items");
        }
        init { this._rawBodyData.Set("num_knowledge_items", value); }
    }

    /// <summary>
    /// The number of samples to generate for the reasoning agent.
    /// </summary>
    public long? NumSamples
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("num_samples");
        }
        init { this._rawBodyData.Set("num_samples", value); }
    }

    /// <summary>
    /// The type of output format for the reasoning agent.
    /// </summary>
    public ApiEnum<string, OutputType>? OutputType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, OutputType>>("output_type");
        }
        init { this._rawBodyData.Set("output_type", value); }
    }

    /// <summary>
    /// The type of reasoning swarm to use (e.g., reasoning duo, self-consistency, IRE).
    /// </summary>
    public ApiEnum<string, SwarmType>? SwarmType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SwarmType>>("swarm_type");
        }
        init { this._rawBodyData.Set("swarm_type", value); }
    }

    /// <summary>
    /// The initial instruction or context provided to the reasoning agent.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawBodyData.Set("system_prompt", value); }
    }

    /// <summary>
    /// The task to be completed by the reasoning agent.
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

    public ReasoningAgentCreateCompletionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReasoningAgentCreateCompletionParams(
        ReasoningAgentCreateCompletionParams reasoningAgentCreateCompletionParams
    )
        : base(reasoningAgentCreateCompletionParams)
    {
        this._rawBodyData = new(reasoningAgentCreateCompletionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ReasoningAgentCreateCompletionParams(
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
    ReasoningAgentCreateCompletionParams(
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
    public static ReasoningAgentCreateCompletionParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ReasoningAgentCreateCompletionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/reasoning-agent/completions"
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

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The type of output format for the reasoning agent.
/// </summary>
[JsonConverter(typeof(OutputTypeConverter))]
public enum OutputType
{
    List,
    Dict,
    Dictionary,
    String,
    Str,
    Final,
    Last,
    Json,
    All,
    Yaml,
    Xml,
    DictAllExceptFirst,
    StrAllExceptFirst,
    Basemodel,
    DictFinal,
    ListFinal,
}

sealed class OutputTypeConverter : JsonConverter<OutputType>
{
    public override OutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => OutputType.List,
            "dict" => OutputType.Dict,
            "dictionary" => OutputType.Dictionary,
            "string" => OutputType.String,
            "str" => OutputType.Str,
            "final" => OutputType.Final,
            "last" => OutputType.Last,
            "json" => OutputType.Json,
            "all" => OutputType.All,
            "yaml" => OutputType.Yaml,
            "xml" => OutputType.Xml,
            "dict-all-except-first" => OutputType.DictAllExceptFirst,
            "str-all-except-first" => OutputType.StrAllExceptFirst,
            "basemodel" => OutputType.Basemodel,
            "dict-final" => OutputType.DictFinal,
            "list-final" => OutputType.ListFinal,
            _ => (OutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputType.List => "list",
                OutputType.Dict => "dict",
                OutputType.Dictionary => "dictionary",
                OutputType.String => "string",
                OutputType.Str => "str",
                OutputType.Final => "final",
                OutputType.Last => "last",
                OutputType.Json => "json",
                OutputType.All => "all",
                OutputType.Yaml => "yaml",
                OutputType.Xml => "xml",
                OutputType.DictAllExceptFirst => "dict-all-except-first",
                OutputType.StrAllExceptFirst => "str-all-except-first",
                OutputType.Basemodel => "basemodel",
                OutputType.DictFinal => "dict-final",
                OutputType.ListFinal => "list-final",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of reasoning swarm to use (e.g., reasoning duo, self-consistency, IRE).
/// </summary>
[JsonConverter(typeof(SwarmTypeConverter))]
public enum SwarmType
{
    ReasoningDuo,
    SelfConsistency,
    Ire,
    ReasoningAgent,
    ConsistencyAgent,
    IreAgent,
    ReflexionAgent,
    GkpAgent,
    AgentJudge,
}

sealed class SwarmTypeConverter : JsonConverter<SwarmType>
{
    public override SwarmType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reasoning-duo" => SwarmType.ReasoningDuo,
            "self-consistency" => SwarmType.SelfConsistency,
            "ire" => SwarmType.Ire,
            "reasoning-agent" => SwarmType.ReasoningAgent,
            "consistency-agent" => SwarmType.ConsistencyAgent,
            "ire-agent" => SwarmType.IreAgent,
            "ReflexionAgent" => SwarmType.ReflexionAgent,
            "GKPAgent" => SwarmType.GkpAgent,
            "AgentJudge" => SwarmType.AgentJudge,
            _ => (SwarmType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwarmType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SwarmType.ReasoningDuo => "reasoning-duo",
                SwarmType.SelfConsistency => "self-consistency",
                SwarmType.Ire => "ire",
                SwarmType.ReasoningAgent => "reasoning-agent",
                SwarmType.ConsistencyAgent => "consistency-agent",
                SwarmType.IreAgent => "ire-agent",
                SwarmType.ReflexionAgent => "ReflexionAgent",
                SwarmType.GkpAgent => "GKPAgent",
                SwarmType.AgentJudge => "AgentJudge",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
