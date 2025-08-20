using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

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
        Type _typeToConvert,
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
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
