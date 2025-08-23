using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.Swarms.SwarmSpecProperties;

/// <summary>
/// The classification of the swarm, indicating its operational style and methodology.
/// </summary>
[JsonConverter(typeof(SwarmTypeConverter))]
public enum SwarmType
{
    AgentRearrange,
    MixtureOfAgents,
    SpreadSheetSwarm,
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
            "SpreadSheetSwarm" => SwarmType.SpreadSheetSwarm,
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
                SwarmType.SpreadSheetSwarm => "SpreadSheetSwarm",
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
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
