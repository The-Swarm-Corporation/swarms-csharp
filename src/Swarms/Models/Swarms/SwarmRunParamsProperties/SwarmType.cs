using System;
using System.Text.Json.Serialization;
using Swarms = Swarms;

namespace Swarms.Models.Swarms.SwarmRunParamsProperties;

/// <summary>
/// The classification of the swarm, indicating its operational style and methodology.
/// </summary>
[JsonConverter(typeof(Swarms::EnumConverter<SwarmType, string>))]
public sealed record class SwarmType(string value) : Swarms::IEnum<SwarmType, string>
{
    public static readonly SwarmType AgentRearrange = new("AgentRearrange");

    public static readonly SwarmType MixtureOfAgents = new("MixtureOfAgents");

    public static readonly SwarmType SpreadSheetSwarm = new("SpreadSheetSwarm");

    public static readonly SwarmType SequentialWorkflow = new("SequentialWorkflow");

    public static readonly SwarmType ConcurrentWorkflow = new("ConcurrentWorkflow");

    public static readonly SwarmType GroupChat = new("GroupChat");

    public static readonly SwarmType MultiAgentRouter = new("MultiAgentRouter");

    public static readonly SwarmType AutoSwarmBuilder = new("AutoSwarmBuilder");

    public static readonly SwarmType HiearchicalSwarm = new("HiearchicalSwarm");

    public static readonly SwarmType Auto = new("auto");

    public static readonly SwarmType MajorityVoting = new("MajorityVoting");

    public static readonly SwarmType Malt = new("MALT");

    public static readonly SwarmType DeepResearchSwarm = new("DeepResearchSwarm");

    public static readonly SwarmType CouncilAsAJudge = new("CouncilAsAJudge");

    public static readonly SwarmType InteractiveGroupChat = new("InteractiveGroupChat");

    public static readonly SwarmType HeavySwarm = new("HeavySwarm");

    readonly string _value = value;

    public enum Value
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

    public Value Known() =>
        _value switch
        {
            "AgentRearrange" => Value.AgentRearrange,
            "MixtureOfAgents" => Value.MixtureOfAgents,
            "SpreadSheetSwarm" => Value.SpreadSheetSwarm,
            "SequentialWorkflow" => Value.SequentialWorkflow,
            "ConcurrentWorkflow" => Value.ConcurrentWorkflow,
            "GroupChat" => Value.GroupChat,
            "MultiAgentRouter" => Value.MultiAgentRouter,
            "AutoSwarmBuilder" => Value.AutoSwarmBuilder,
            "HiearchicalSwarm" => Value.HiearchicalSwarm,
            "auto" => Value.Auto,
            "MajorityVoting" => Value.MajorityVoting,
            "MALT" => Value.Malt,
            "DeepResearchSwarm" => Value.DeepResearchSwarm,
            "CouncilAsAJudge" => Value.CouncilAsAJudge,
            "InteractiveGroupChat" => Value.InteractiveGroupChat,
            "HeavySwarm" => Value.HeavySwarm,
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
