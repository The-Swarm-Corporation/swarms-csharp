using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;
using System = System;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(ModelConverter<SwarmSpec>))]
public sealed record class SwarmSpec : ModelBase, IFromRaw<SwarmSpec>
{
    /// <summary>
    /// A list of agents or specifications that define the agents participating in
    /// the swarm.
    /// </summary>
    public List<AgentSpec>? Agents
    {
        get
        {
            if (!this._rawData.TryGetValue("agents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AgentSpec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["agents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A comprehensive description of the swarm's objectives, capabilities, and intended outcomes.
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
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            if (!this._rawData.TryGetValue("heavy_swarm_loops_per_agent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["heavy_swarm_loops_per_agent"] = JsonSerializer.SerializeToElement(
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
                !this._rawData.TryGetValue(
                    "heavy_swarm_question_agent_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["heavy_swarm_question_agent_model_name"] =
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
                !this._rawData.TryGetValue("heavy_swarm_worker_model_name", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["heavy_swarm_worker_model_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
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

    /// <summary>
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
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
    /// A list of messages that the swarm should complete.
    /// </summary>
    public SwarmSpecMessages? Messages
    {
        get
        {
            if (!this._rawData.TryGetValue("messages", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SwarmSpecMessages?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["messages"] = JsonSerializer.SerializeToElement(
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
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get
        {
            if (!this._rawData.TryGetValue("rearrange_flow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["rearrange_flow"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or 'flex'
    /// for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            if (!this._rawData.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["service_tier"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
    /// </summary>
    public ApiEnum<string, SwarmSpecSwarmType>? SwarmType
    {
        get
        {
            if (!this._rawData.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SwarmSpecSwarmType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["swarm_type"] = JsonSerializer.SerializeToElement(
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
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public List<string>? Tasks
    {
        get
        {
            if (!this._rawData.TryGetValue("tasks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tasks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Agents ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.HeavySwarmLoopsPerAgent;
        _ = this.HeavySwarmQuestionAgentModelName;
        _ = this.HeavySwarmWorkerModelName;
        _ = this.Img;
        _ = this.MaxLoops;
        this.Messages?.Validate();
        _ = this.Name;
        _ = this.RearrangeFlow;
        _ = this.Rules;
        _ = this.ServiceTier;
        _ = this.Stream;
        this.SwarmType?.Validate();
        _ = this.Task;
        _ = this.Tasks;
    }

    public SwarmSpec() { }

    public SwarmSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SwarmSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(SwarmSpecMessagesConverter))]
public record class SwarmSpecMessages
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SwarmSpecMessages(
        IReadOnlyList<Dictionary<string, JsonElement>> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public SwarmSpecMessages(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? json = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._json = json;
    }

    public SwarmSpecMessages(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of SwarmSpecMessages"
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
                "Data did not match any variant of SwarmSpecMessages"
            ),
        };
    }

    public static implicit operator SwarmSpecMessages(
        List<Dictionary<string, JsonElement>> value
    ) => new((IReadOnlyList<Dictionary<string, JsonElement>>)value);

    public static implicit operator SwarmSpecMessages(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of SwarmSpecMessages"
            );
        }
    }
}

sealed class SwarmSpecMessagesConverter : JsonConverter<SwarmSpecMessages?>
{
    public override SwarmSpecMessages? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwarmSpecMessages? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The classification of the swarm, indicating its operational style and methodology.
/// </summary>
[JsonConverter(typeof(SwarmSpecSwarmTypeConverter))]
public enum SwarmSpecSwarmType
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

sealed class SwarmSpecSwarmTypeConverter : JsonConverter<SwarmSpecSwarmType>
{
    public override SwarmSpecSwarmType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AgentRearrange" => SwarmSpecSwarmType.AgentRearrange,
            "MixtureOfAgents" => SwarmSpecSwarmType.MixtureOfAgents,
            "SequentialWorkflow" => SwarmSpecSwarmType.SequentialWorkflow,
            "ConcurrentWorkflow" => SwarmSpecSwarmType.ConcurrentWorkflow,
            "GroupChat" => SwarmSpecSwarmType.GroupChat,
            "MultiAgentRouter" => SwarmSpecSwarmType.MultiAgentRouter,
            "AutoSwarmBuilder" => SwarmSpecSwarmType.AutoSwarmBuilder,
            "HiearchicalSwarm" => SwarmSpecSwarmType.HiearchicalSwarm,
            "auto" => SwarmSpecSwarmType.Auto,
            "MajorityVoting" => SwarmSpecSwarmType.MajorityVoting,
            "MALT" => SwarmSpecSwarmType.Malt,
            "DeepResearchSwarm" => SwarmSpecSwarmType.DeepResearchSwarm,
            "CouncilAsAJudge" => SwarmSpecSwarmType.CouncilAsAJudge,
            "InteractiveGroupChat" => SwarmSpecSwarmType.InteractiveGroupChat,
            "HeavySwarm" => SwarmSpecSwarmType.HeavySwarm,
            _ => (SwarmSpecSwarmType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwarmSpecSwarmType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SwarmSpecSwarmType.AgentRearrange => "AgentRearrange",
                SwarmSpecSwarmType.MixtureOfAgents => "MixtureOfAgents",
                SwarmSpecSwarmType.SequentialWorkflow => "SequentialWorkflow",
                SwarmSpecSwarmType.ConcurrentWorkflow => "ConcurrentWorkflow",
                SwarmSpecSwarmType.GroupChat => "GroupChat",
                SwarmSpecSwarmType.MultiAgentRouter => "MultiAgentRouter",
                SwarmSpecSwarmType.AutoSwarmBuilder => "AutoSwarmBuilder",
                SwarmSpecSwarmType.HiearchicalSwarm => "HiearchicalSwarm",
                SwarmSpecSwarmType.Auto => "auto",
                SwarmSpecSwarmType.MajorityVoting => "MajorityVoting",
                SwarmSpecSwarmType.Malt => "MALT",
                SwarmSpecSwarmType.DeepResearchSwarm => "DeepResearchSwarm",
                SwarmSpecSwarmType.CouncilAsAJudge => "CouncilAsAJudge",
                SwarmSpecSwarmType.InteractiveGroupChat => "InteractiveGroupChat",
                SwarmSpecSwarmType.HeavySwarm => "HeavySwarm",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
