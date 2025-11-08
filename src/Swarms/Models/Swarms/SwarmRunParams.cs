using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;
using System = System;

namespace Swarms.Models.Swarms;

/// <summary>
/// Run a swarm with the specified task. Supports streaming when stream=True.
/// </summary>
public sealed record class SwarmRunParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// A list of agents or specifications that define the agents participating in
    /// the swarm.
    /// </summary>
    public List<AgentSpec>? Agents
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("agents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AgentSpec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["agents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A comprehensive description of the swarm's objectives, capabilities, and
    /// intended outcomes.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "heavy_swarm_loops_per_agent",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["heavy_swarm_loops_per_agent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The model name to use for the question agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmQuestionAgentModelName
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "heavy_swarm_question_agent_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["heavy_swarm_question_agent_model_name"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The model name to use for the worker agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmWorkerModelName
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "heavy_swarm_worker_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["heavy_swarm_worker_model_name"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
    /// </summary>
    public string? Img
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("img", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["img"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of messages that the swarm should complete.
    /// </summary>
    public Messages? Messages
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("messages", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Messages?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["messages"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the swarm, which serves as an identifier for the group of agents
    /// and their collective task.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("rearrange_flow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["rearrange_flow"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Guidelines or constraints that govern the behavior and interactions of the
    /// agents within the swarm.
    /// </summary>
    public string? Rules
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or
    /// 'flex' for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["service_tier"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A flag indicating whether the swarm should stream its output.
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
    /// </summary>
    public ApiEnum<string, SwarmType>? SwarmType
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SwarmType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["swarm_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The specific task or objective that the swarm is designed to accomplish.
    /// </summary>
    public string? Task
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["task"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public List<string>? Tasks
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tasks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["tasks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SwarmRunParams() { }

    public SwarmRunParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmRunParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static SwarmRunParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/completions"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesConverter))]
public record class Messages
{
    public object Value { get; private init; }

    public Messages(IReadOnlyList<Dictionary<string, JsonElement>> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public Messages(IReadOnlyDictionary<string, JsonElement> value)
    {
        Value = FrozenDictionary.ToFrozenDictionary(value);
    }

    Messages(UnknownVariant value)
    {
        Value = value;
    }

    public static Messages CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, JsonElement>>;
        return value != null;
    }

    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<Dictionary<string, JsonElement>>> jsonElements,
        System::Action<IReadOnlyDictionary<string, JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case List<Dictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case Dictionary<string, JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Messages"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<Dictionary<string, JsonElement>>, T> jsonElements,
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            IReadOnlyList<Dictionary<string, JsonElement>> value => jsonElements(value),
            IReadOnlyDictionary<string, JsonElement> value => jsonElements1(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Messages"
            ),
        };
    }

    public static implicit operator Messages(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<Dictionary<string, JsonElement>>)value);

    public static implicit operator Messages(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Messages"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class MessagesConverter : JsonConverter<Messages?>
{
    public override Messages? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Messages(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<Dictionary<string, JsonElement>>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Messages(deserialized);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'Dictionary<string, JsonElement>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Messages? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// The classification of the swarm, indicating its operational style and methodology.
/// </summary>
[JsonConverter(typeof(SwarmTypeConverter))]
public enum SwarmType
{
    AgentRearrange,
    MixtureOfAgents,
    SequentialWorkflow,
    ConcurrentWorkflow,
    GroupChat,
    MultiAgentRouter,
    AutoSwarmBuilder,
    HiearchicalSwarm,
    Auto,
    MajorityVoting,
    Malt,
    DeepResearchSwarm,
    CouncilAsAJudge,
    InteractiveGroupChat,
    HeavySwarm,
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
            "AgentRearrange" => SwarmType.AgentRearrange,
            "MixtureOfAgents" => SwarmType.MixtureOfAgents,
            "SequentialWorkflow" => SwarmType.SequentialWorkflow,
            "ConcurrentWorkflow" => SwarmType.ConcurrentWorkflow,
            "GroupChat" => SwarmType.GroupChat,
            "MultiAgentRouter" => SwarmType.MultiAgentRouter,
            "AutoSwarmBuilder" => SwarmType.AutoSwarmBuilder,
            "HiearchicalSwarm" => SwarmType.HiearchicalSwarm,
            "auto" => SwarmType.Auto,
            "MajorityVoting" => SwarmType.MajorityVoting,
            "MALT" => SwarmType.Malt,
            "DeepResearchSwarm" => SwarmType.DeepResearchSwarm,
            "CouncilAsAJudge" => SwarmType.CouncilAsAJudge,
            "InteractiveGroupChat" => SwarmType.InteractiveGroupChat,
            "HeavySwarm" => SwarmType.HeavySwarm,
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
                SwarmType.AgentRearrange => "AgentRearrange",
                SwarmType.MixtureOfAgents => "MixtureOfAgents",
                SwarmType.SequentialWorkflow => "SequentialWorkflow",
                SwarmType.ConcurrentWorkflow => "ConcurrentWorkflow",
                SwarmType.GroupChat => "GroupChat",
                SwarmType.MultiAgentRouter => "MultiAgentRouter",
                SwarmType.AutoSwarmBuilder => "AutoSwarmBuilder",
                SwarmType.HiearchicalSwarm => "HiearchicalSwarm",
                SwarmType.Auto => "auto",
                SwarmType.MajorityVoting => "MajorityVoting",
                SwarmType.Malt => "MALT",
                SwarmType.DeepResearchSwarm => "DeepResearchSwarm",
                SwarmType.CouncilAsAJudge => "CouncilAsAJudge",
                SwarmType.InteractiveGroupChat => "InteractiveGroupChat",
                SwarmType.HeavySwarm => "HeavySwarm",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
