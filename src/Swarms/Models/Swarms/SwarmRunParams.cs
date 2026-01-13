using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;

namespace Swarms.Models.Swarms;

/// <summary>
/// Run a swarm with the specified task. Supports streaming when stream=True.
/// </summary>
public sealed record class SwarmRunParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A list of agents or specifications that define the agents participating in
    /// the swarm.
    /// </summary>
    public IReadOnlyList<AgentSpec>? Agents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AgentSpec>>("agents");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AgentSpec>?>(
                "agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("heavy_swarm_loops_per_agent");
        }
        init { this._rawBodyData.Set("heavy_swarm_loops_per_agent", value); }
    }

    /// <summary>
    /// The model name to use for the question agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmQuestionAgentModelName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "heavy_swarm_question_agent_model_name"
            );
        }
        init { this._rawBodyData.Set("heavy_swarm_question_agent_model_name", value); }
    }

    /// <summary>
    /// The model name to use for the worker agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmWorkerModelName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("heavy_swarm_worker_model_name");
        }
        init { this._rawBodyData.Set("heavy_swarm_worker_model_name", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
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

    /// <summary>
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
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
    /// A list of messages that the swarm should complete.
    /// </summary>
    public Messages? Messages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Messages>("messages");
        }
        init { this._rawBodyData.Set("messages", value); }
    }

    /// <summary>
    /// The name of the swarm, which serves as an identifier for the group of agents
    /// and their collective task.
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
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rearrange_flow");
        }
        init { this._rawBodyData.Set("rearrange_flow", value); }
    }

    /// <summary>
    /// Guidelines or constraints that govern the behavior and interactions of the
    /// agents within the swarm.
    /// </summary>
    public string? Rules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rules");
        }
        init { this._rawBodyData.Set("rules", value); }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or 'flex'
    /// for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("service_tier");
        }
        init { this._rawBodyData.Set("service_tier", value); }
    }

    /// <summary>
    /// A flag indicating whether the swarm should stream its output.
    /// </summary>
    public bool? Stream
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("stream");
        }
        init { this._rawBodyData.Set("stream", value); }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
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
    /// The specific task or objective that the swarm is designed to accomplish.
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

    /// <summary>
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public IReadOnlyList<string>? Tasks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tasks");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tasks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public SwarmRunParams() { }

    public SwarmRunParams(SwarmRunParams swarmRunParams)
        : base(swarmRunParams)
    {
        this._rawBodyData = new(swarmRunParams._rawBodyData);
    }

    public SwarmRunParams(
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
    SwarmRunParams(
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
    public static SwarmRunParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/swarm/completions")
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
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesConverter))]
public record class Messages : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Messages(
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public Messages(IReadOnlyDictionary<string, JsonElement> value, JsonElement? element = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Messages(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>;
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
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>> jsonElements,
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Messages"
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
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>, T> jsonElements,
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value => jsonElements(value),
            IReadOnlyDictionary<string, JsonElement> value => jsonElements1(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Messages"
            ),
        };
    }

    public static implicit operator Messages(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>)value);

    public static implicit operator Messages(Dictionary<string, JsonElement> value) =>
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
                "Data did not match any variant of Messages"
            );
        }
    }

    public virtual bool Equals(Messages? other)
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

sealed class MessagesConverter : JsonConverter<Messages?>
{
    public override Messages? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >(element, options);
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
            var deserialized = JsonSerializer.Deserialize<FrozenDictionary<string, JsonElement>>(
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
        Messages? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
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
        Type typeToConvert,
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
