using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(JsonModelConverter<SwarmSpec, SwarmSpecFromRaw>))]
public sealed record class SwarmSpec : JsonModel
{
    /// <summary>
    /// A list of agents or specifications that define the agents participating in
    /// the swarm.
    /// </summary>
    public IReadOnlyList<AgentSpec>? Agents
    {
        get { return JsonModel.GetNullableClass<List<AgentSpec>>(this.RawData, "agents"); }
        init { JsonModel.Set(this._rawData, "agents", value); }
    }

    /// <summary>
    /// A comprehensive description of the swarm's objectives, capabilities, and intended outcomes.
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            return JsonModel.GetNullableStruct<long>(this.RawData, "heavy_swarm_loops_per_agent");
        }
        init { JsonModel.Set(this._rawData, "heavy_swarm_loops_per_agent", value); }
    }

    /// <summary>
    /// The model name to use for the question agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmQuestionAgentModelName
    {
        get
        {
            return JsonModel.GetNullableClass<string>(
                this.RawData,
                "heavy_swarm_question_agent_model_name"
            );
        }
        init { JsonModel.Set(this._rawData, "heavy_swarm_question_agent_model_name", value); }
    }

    /// <summary>
    /// The model name to use for the worker agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmWorkerModelName
    {
        get
        {
            return JsonModel.GetNullableClass<string>(
                this.RawData,
                "heavy_swarm_worker_model_name"
            );
        }
        init { JsonModel.Set(this._rawData, "heavy_swarm_worker_model_name", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
    /// </summary>
    public string? Img
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "img"); }
        init { JsonModel.Set(this._rawData, "img", value); }
    }

    /// <summary>
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
    /// </summary>
    public long? MaxLoops
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "max_loops"); }
        init { JsonModel.Set(this._rawData, "max_loops", value); }
    }

    /// <summary>
    /// A list of messages that the swarm should complete.
    /// </summary>
    public SwarmSpecMessages? Messages
    {
        get { return JsonModel.GetNullableClass<SwarmSpecMessages>(this.RawData, "messages"); }
        init { JsonModel.Set(this._rawData, "messages", value); }
    }

    /// <summary>
    /// The name of the swarm, which serves as an identifier for the group of agents
    /// and their collective task.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "rearrange_flow"); }
        init { JsonModel.Set(this._rawData, "rearrange_flow", value); }
    }

    /// <summary>
    /// Guidelines or constraints that govern the behavior and interactions of the
    /// agents within the swarm.
    /// </summary>
    public string? Rules
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "rules"); }
        init { JsonModel.Set(this._rawData, "rules", value); }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or 'flex'
    /// for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "service_tier"); }
        init { JsonModel.Set(this._rawData, "service_tier", value); }
    }

    /// <summary>
    /// A flag indicating whether the swarm should stream its output.
    /// </summary>
    public bool? Stream
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "stream"); }
        init { JsonModel.Set(this._rawData, "stream", value); }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
    /// </summary>
    public ApiEnum<string, SwarmSpecSwarmType>? SwarmType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, SwarmSpecSwarmType>>(
                this.RawData,
                "swarm_type"
            );
        }
        init { JsonModel.Set(this._rawData, "swarm_type", value); }
    }

    /// <summary>
    /// The specific task or objective that the swarm is designed to accomplish.
    /// </summary>
    public string? Task
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "task"); }
        init { JsonModel.Set(this._rawData, "task", value); }
    }

    /// <summary>
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public IReadOnlyList<string>? Tasks
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "tasks"); }
        init { JsonModel.Set(this._rawData, "tasks", value); }
    }

    /// <inheritdoc/>
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

    public SwarmSpec(SwarmSpec swarmSpec)
        : base(swarmSpec) { }

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

    /// <inheritdoc cref="SwarmSpecFromRaw.FromRawUnchecked"/>
    public static SwarmSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmSpecFromRaw : IFromRawJson<SwarmSpec>
{
    /// <inheritdoc/>
    public SwarmSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SwarmSpec.FromRawUnchecked(rawData);
}

/// <summary>
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(SwarmSpecMessagesConverter))]
public record class SwarmSpecMessages : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SwarmSpecMessages(
        IReadOnlyList<Dictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public SwarmSpecMessages(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public SwarmSpecMessages(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<Dictionary<string, JsonElement>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList<Dictionary<string, JsonElement>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, JsonElement>>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyDictionary<string, JsonElement>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary<string, JsonElement>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList<Dictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<Dictionary<string, JsonElement>>> jsonElements,
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<Dictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of SwarmSpecMessages"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList<Dictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<Dictionary<string, JsonElement>>, T> jsonElements,
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements1
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of SwarmSpecMessages"
            );
        }
    }

    public virtual bool Equals(SwarmSpecMessages? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class SwarmSpecMessagesConverter : JsonConverter<SwarmSpecMessages?>
{
    public override SwarmSpecMessages? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
        Type typeToConvert,
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
