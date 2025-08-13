using System;
using System.Text.Json.Serialization;
using Swarms = Swarms;

namespace Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

/// <summary>
/// The type of reasoning swarm to use (e.g., reasoning duo, self-consistency, IRE).
/// </summary>
[JsonConverter(typeof(Swarms::EnumConverter<SwarmType, string>))]
public sealed record class SwarmType(string value) : Swarms::IEnum<SwarmType, string>
{
    public static readonly SwarmType ReasoningDuo = new("reasoning-duo");

    public static readonly SwarmType SelfConsistency = new("self-consistency");

    public static readonly SwarmType Ire = new("ire");

    public static readonly SwarmType ReasoningAgent = new("reasoning-agent");

    public static readonly SwarmType ConsistencyAgent = new("consistency-agent");

    public static readonly SwarmType IreAgent = new("ire-agent");

    public static readonly SwarmType ReflexionAgent = new("ReflexionAgent");

    public static readonly SwarmType GkpAgent = new("GKPAgent");

    public static readonly SwarmType AgentJudge = new("AgentJudge");

    readonly string _value = value;

    public enum Value
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

    public Value Known() =>
        _value switch
        {
            "reasoning-duo" => Value.ReasoningDuo,
            "self-consistency" => Value.SelfConsistency,
            "ire" => Value.Ire,
            "reasoning-agent" => Value.ReasoningAgent,
            "consistency-agent" => Value.ConsistencyAgent,
            "ire-agent" => Value.IreAgent,
            "ReflexionAgent" => Value.ReflexionAgent,
            "GKPAgent" => Value.GkpAgent,
            "AgentJudge" => Value.AgentJudge,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static SwarmType FromRaw(string value)
    {
        return new(value);
    }
}
