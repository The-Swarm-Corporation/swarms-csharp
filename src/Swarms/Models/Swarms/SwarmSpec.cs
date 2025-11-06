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
            if (!this._properties.TryGetValue("agents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AgentSpec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["agents"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "heavy_swarm_loops_per_agent",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["heavy_swarm_loops_per_agent"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "heavy_swarm_question_agent_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["heavy_swarm_question_agent_model_name"] =
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
                !this._properties.TryGetValue(
                    "heavy_swarm_worker_model_name",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["heavy_swarm_worker_model_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("img", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["img"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("max_loops", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["max_loops"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of messages that the swarm should complete.
    /// </summary>
    public MessagesModel? Messages
    {
        get
        {
            if (!this._properties.TryGetValue("messages", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MessagesModel?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["messages"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("rearrange_flow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["rearrange_flow"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["rules"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["service_tier"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
    /// </summary>
    public ApiEnum<string, SwarmTypeModel>? SwarmType
    {
        get
        {
            if (!this._properties.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SwarmTypeModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["swarm_type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("task", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["task"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tasks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tasks"] = JsonSerializer.SerializeToElement(
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

    public SwarmSpec(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmSpec(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SwarmSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesModelConverter))]
public record class MessagesModel
{
    public object Value { get; private init; }

    public MessagesModel(IReadOnlyList<Dictionary<string, JsonElement>> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public MessagesModel(IReadOnlyDictionary<string, JsonElement> value)
    {
        Value = FrozenDictionary.ToFrozenDictionary(value);
    }

    MessagesModel(UnknownVariant value)
    {
        Value = value;
    }

    public static MessagesModel CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of MessagesModel"
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
                "Data did not match any variant of MessagesModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of MessagesModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class MessagesModelConverter : JsonConverter<MessagesModel?>
{
    public override MessagesModel? Read(
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
                return new MessagesModel(deserialized);
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
                return new MessagesModel(deserialized);
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
        MessagesModel? value,
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
[JsonConverter(typeof(SwarmTypeModelConverter))]
public enum SwarmTypeModel
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

sealed class SwarmTypeModelConverter : JsonConverter<SwarmTypeModel>
{
    public override SwarmTypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AgentRearrange" => SwarmTypeModel.AgentRearrange,
            "MixtureOfAgents" => SwarmTypeModel.MixtureOfAgents,
            "SequentialWorkflow" => SwarmTypeModel.SequentialWorkflow,
            "ConcurrentWorkflow" => SwarmTypeModel.ConcurrentWorkflow,
            "GroupChat" => SwarmTypeModel.GroupChat,
            "MultiAgentRouter" => SwarmTypeModel.MultiAgentRouter,
            "AutoSwarmBuilder" => SwarmTypeModel.AutoSwarmBuilder,
            "HiearchicalSwarm" => SwarmTypeModel.HiearchicalSwarm,
            "auto" => SwarmTypeModel.Auto,
            "MajorityVoting" => SwarmTypeModel.MajorityVoting,
            "MALT" => SwarmTypeModel.Malt,
            "DeepResearchSwarm" => SwarmTypeModel.DeepResearchSwarm,
            "CouncilAsAJudge" => SwarmTypeModel.CouncilAsAJudge,
            "InteractiveGroupChat" => SwarmTypeModel.InteractiveGroupChat,
            "HeavySwarm" => SwarmTypeModel.HeavySwarm,
            _ => (SwarmTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SwarmTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SwarmTypeModel.AgentRearrange => "AgentRearrange",
                SwarmTypeModel.MixtureOfAgents => "MixtureOfAgents",
                SwarmTypeModel.SequentialWorkflow => "SequentialWorkflow",
                SwarmTypeModel.ConcurrentWorkflow => "ConcurrentWorkflow",
                SwarmTypeModel.GroupChat => "GroupChat",
                SwarmTypeModel.MultiAgentRouter => "MultiAgentRouter",
                SwarmTypeModel.AutoSwarmBuilder => "AutoSwarmBuilder",
                SwarmTypeModel.HiearchicalSwarm => "HiearchicalSwarm",
                SwarmTypeModel.Auto => "auto",
                SwarmTypeModel.MajorityVoting => "MajorityVoting",
                SwarmTypeModel.Malt => "MALT",
                SwarmTypeModel.DeepResearchSwarm => "DeepResearchSwarm",
                SwarmTypeModel.CouncilAsAJudge => "CouncilAsAJudge",
                SwarmTypeModel.InteractiveGroupChat => "InteractiveGroupChat",
                SwarmTypeModel.HeavySwarm => "HeavySwarm",
                _ => throw new SwarmsClientInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
