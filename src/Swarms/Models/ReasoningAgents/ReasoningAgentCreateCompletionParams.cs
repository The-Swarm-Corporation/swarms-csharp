using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using System = System;

namespace Swarms.Models.ReasoningAgents;

/// <summary>
/// Run a reasoning agent with the specified task.
/// </summary>
public sealed record class ReasoningAgentCreateCompletionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
            if (!this._rawBodyData.TryGetValue("agent_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["agent_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A detailed explanation of the reasoning agent's purpose and capabilities.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of times the reasoning agent is allowed to repeat its task.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The memory capacity for the reasoning agent.
    /// </summary>
    public long? MemoryCapacity
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("memory_capacity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["memory_capacity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the AI model that the reasoning agent will utilize.
    /// </summary>
    public string? ModelName
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["model_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of knowledge items to use for the reasoning agent.
    /// </summary>
    public long? NumKnowledgeItems
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("num_knowledge_items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["num_knowledge_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of samples to generate for the reasoning agent.
    /// </summary>
    public long? NumSamples
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("num_samples", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["num_samples"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of output format for the reasoning agent.
    /// </summary>
    public ApiEnum<string, OutputType>? OutputType
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("output_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, OutputType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["output_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of reasoning swarm to use (e.g., reasoning duo, self-consistency, IRE).
    /// </summary>
    public ApiEnum<string, SwarmType>? SwarmType
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SwarmType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["swarm_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The initial instruction or context provided to the reasoning agent.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("system_prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["system_prompt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The task to be completed by the reasoning agent.
    /// </summary>
    public string? Task
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["task"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReasoningAgentCreateCompletionParams() { }

    public ReasoningAgentCreateCompletionParams(
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
    ReasoningAgentCreateCompletionParams(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/reasoning-agent/completions"
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
        System::Type typeToConvert,
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
        System::Type typeToConvert,
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
