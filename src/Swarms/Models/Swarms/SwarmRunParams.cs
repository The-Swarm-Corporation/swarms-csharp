using System;
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

namespace Swarms.Models.Swarms;

/// <summary>
/// Run a swarm with the specified task. Supports streaming when stream=True.
/// </summary>
public sealed record class SwarmRunParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return ModelBase.GetNullableClass<List<AgentSpec>>(this.RawBodyData, "agents"); }
        init { ModelBase.Set(this._rawBodyData, "agents", value); }
    }

    /// <summary>
    /// A comprehensive description of the swarm's objectives, capabilities, and intended outcomes.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { ModelBase.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// The number of loops to run per agent in the heavy swarm.
    /// </summary>
    public long? HeavySwarmLoopsPerAgent
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(
                this.RawBodyData,
                "heavy_swarm_loops_per_agent"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "heavy_swarm_loops_per_agent", value); }
    }

    /// <summary>
    /// The model name to use for the question agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmQuestionAgentModelName
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawBodyData,
                "heavy_swarm_question_agent_model_name"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "heavy_swarm_question_agent_model_name", value); }
    }

    /// <summary>
    /// The model name to use for the worker agent in the heavy swarm.
    /// </summary>
    public string? HeavySwarmWorkerModelName
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawBodyData,
                "heavy_swarm_worker_model_name"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "heavy_swarm_worker_model_name", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the swarm's task or representation.
    /// </summary>
    public string? Img
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "img"); }
        init { ModelBase.Set(this._rawBodyData, "img", value); }
    }

    /// <summary>
    /// The maximum number of execution loops allowed for the swarm, enabling repeated
    /// processing if needed.
    /// </summary>
    public long? MaxLoops
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "max_loops"); }
        init { ModelBase.Set(this._rawBodyData, "max_loops", value); }
    }

    /// <summary>
    /// A list of messages that the swarm should complete.
    /// </summary>
    public Messages? Messages
    {
        get { return ModelBase.GetNullableClass<Messages>(this.RawBodyData, "messages"); }
        init { ModelBase.Set(this._rawBodyData, "messages", value); }
    }

    /// <summary>
    /// The name of the swarm, which serves as an identifier for the group of agents
    /// and their collective task.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Instructions on how to rearrange the flow of tasks among agents, if applicable.
    /// </summary>
    public string? RearrangeFlow
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "rearrange_flow"); }
        init { ModelBase.Set(this._rawBodyData, "rearrange_flow", value); }
    }

    /// <summary>
    /// Guidelines or constraints that govern the behavior and interactions of the
    /// agents within the swarm.
    /// </summary>
    public string? Rules
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "rules"); }
        init { ModelBase.Set(this._rawBodyData, "rules", value); }
    }

    /// <summary>
    /// The service tier to use for processing. Options: 'standard' (default) or 'flex'
    /// for lower cost but slower processing.
    /// </summary>
    public string? ServiceTier
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "service_tier"); }
        init { ModelBase.Set(this._rawBodyData, "service_tier", value); }
    }

    /// <summary>
    /// A flag indicating whether the swarm should stream its output.
    /// </summary>
    public bool? Stream
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "stream"); }
        init { ModelBase.Set(this._rawBodyData, "stream", value); }
    }

    /// <summary>
    /// The classification of the swarm, indicating its operational style and methodology.
    /// </summary>
    public ApiEnum<string, SwarmType>? SwarmType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, SwarmType>>(
                this.RawBodyData,
                "swarm_type"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "swarm_type", value); }
    }

    /// <summary>
    /// The specific task or objective that the swarm is designed to accomplish.
    /// </summary>
    public string? Task
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "task"); }
        init { ModelBase.Set(this._rawBodyData, "task", value); }
    }

    /// <summary>
    /// A list of tasks that the swarm should complete.
    /// </summary>
    public IReadOnlyList<string>? Tasks
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "tasks"); }
        init { ModelBase.Set(this._rawBodyData, "tasks", value); }
    }

    public SwarmRunParams() { }

    public SwarmRunParams(
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
    SwarmRunParams(
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
/// A list of messages that the swarm should complete.
/// </summary>
[JsonConverter(typeof(MessagesConverter))]
public record class Messages
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Messages(IReadOnlyList<Dictionary<string, JsonElement>> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public Messages(IReadOnlyDictionary<string, JsonElement> value, JsonElement? json = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._json = json;
    }

    public Messages(JsonElement json)
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
        Action<IReadOnlyList<Dictionary<string, JsonElement>>> jsonElements,
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements1
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
        Func<IReadOnlyList<Dictionary<string, JsonElement>>, T> jsonElements,
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements1
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
}

sealed class MessagesConverter : JsonConverter<Messages?>
{
    public override Messages? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(json);
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
