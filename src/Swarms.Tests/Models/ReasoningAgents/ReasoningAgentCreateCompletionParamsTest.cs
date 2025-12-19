using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Tests.Models.ReasoningAgents;

public class OutputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputType.List)]
    [InlineData(OutputType.Dict)]
    [InlineData(OutputType.Dictionary)]
    [InlineData(OutputType.String)]
    [InlineData(OutputType.Str)]
    [InlineData(OutputType.Final)]
    [InlineData(OutputType.Last)]
    [InlineData(OutputType.Json)]
    [InlineData(OutputType.All)]
    [InlineData(OutputType.Yaml)]
    [InlineData(OutputType.Xml)]
    [InlineData(OutputType.DictAllExceptFirst)]
    [InlineData(OutputType.StrAllExceptFirst)]
    [InlineData(OutputType.Basemodel)]
    [InlineData(OutputType.DictFinal)]
    [InlineData(OutputType.ListFinal)]
    public void Validation_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SwarmsClientInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputType.List)]
    [InlineData(OutputType.Dict)]
    [InlineData(OutputType.Dictionary)]
    [InlineData(OutputType.String)]
    [InlineData(OutputType.Str)]
    [InlineData(OutputType.Final)]
    [InlineData(OutputType.Last)]
    [InlineData(OutputType.Json)]
    [InlineData(OutputType.All)]
    [InlineData(OutputType.Yaml)]
    [InlineData(OutputType.Xml)]
    [InlineData(OutputType.DictAllExceptFirst)]
    [InlineData(OutputType.StrAllExceptFirst)]
    [InlineData(OutputType.Basemodel)]
    [InlineData(OutputType.DictFinal)]
    [InlineData(OutputType.ListFinal)]
    public void SerializationRoundtrip_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SwarmTypeTest : TestBase
{
    [Theory]
    [InlineData(SwarmType.ReasoningDuo)]
    [InlineData(SwarmType.SelfConsistency)]
    [InlineData(SwarmType.Ire)]
    [InlineData(SwarmType.ReasoningAgent)]
    [InlineData(SwarmType.ConsistencyAgent)]
    [InlineData(SwarmType.IreAgent)]
    [InlineData(SwarmType.ReflexionAgent)]
    [InlineData(SwarmType.GkpAgent)]
    [InlineData(SwarmType.AgentJudge)]
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

        Assert.NotNull(value);
        Assert.Throws<SwarmsClientInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwarmType.ReasoningDuo)]
    [InlineData(SwarmType.SelfConsistency)]
    [InlineData(SwarmType.Ire)]
    [InlineData(SwarmType.ReasoningAgent)]
    [InlineData(SwarmType.ConsistencyAgent)]
    [InlineData(SwarmType.IreAgent)]
    [InlineData(SwarmType.ReflexionAgent)]
    [InlineData(SwarmType.GkpAgent)]
    [InlineData(SwarmType.AgentJudge)]
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
