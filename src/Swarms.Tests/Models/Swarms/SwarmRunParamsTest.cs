using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class MessagesTest : TestBase
{
    [Fact]
    public void JsonElementsValidation_Works()
    {
        Messages value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidation_Works1()
    {
        Messages value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works()
    {
        Messages value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works1()
    {
        Messages value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages>(json);

        Assert.Equal(value, deserialized);
    }
}

public class SwarmTypeTest : TestBase
{
    [Theory]
    [InlineData(SwarmType.AgentRearrange)]
    [InlineData(SwarmType.MixtureOfAgents)]
    [InlineData(SwarmType.SequentialWorkflow)]
    [InlineData(SwarmType.ConcurrentWorkflow)]
    [InlineData(SwarmType.GroupChat)]
    [InlineData(SwarmType.MultiAgentRouter)]
    [InlineData(SwarmType.AutoSwarmBuilder)]
    [InlineData(SwarmType.HiearchicalSwarm)]
    [InlineData(SwarmType.Auto)]
    [InlineData(SwarmType.MajorityVoting)]
    [InlineData(SwarmType.Malt)]
    [InlineData(SwarmType.DeepResearchSwarm)]
    [InlineData(SwarmType.CouncilAsAJudge)]
    [InlineData(SwarmType.InteractiveGroupChat)]
    [InlineData(SwarmType.HeavySwarm)]
    public void Validation_Works(SwarmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwarmType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwarmType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SwarmsClientInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwarmType.AgentRearrange)]
    [InlineData(SwarmType.MixtureOfAgents)]
    [InlineData(SwarmType.SequentialWorkflow)]
    [InlineData(SwarmType.ConcurrentWorkflow)]
    [InlineData(SwarmType.GroupChat)]
    [InlineData(SwarmType.MultiAgentRouter)]
    [InlineData(SwarmType.AutoSwarmBuilder)]
    [InlineData(SwarmType.HiearchicalSwarm)]
    [InlineData(SwarmType.Auto)]
    [InlineData(SwarmType.MajorityVoting)]
    [InlineData(SwarmType.Malt)]
    [InlineData(SwarmType.DeepResearchSwarm)]
    [InlineData(SwarmType.CouncilAsAJudge)]
    [InlineData(SwarmType.InteractiveGroupChat)]
    [InlineData(SwarmType.HeavySwarm)]
    public void SerializationRoundtrip_Works(SwarmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwarmType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwarmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwarmType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwarmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
