using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Client.AutoSwarmBuilder;

namespace Swarms.Tests.Models.Client.AutoSwarmBuilder;

public class ExecutionTypeTest : TestBase
{
    [Theory]
    [InlineData(ExecutionType.ReturnAgents)]
    [InlineData(ExecutionType.ReturnSwarmRouterConfig)]
    [InlineData(ExecutionType.ReturnAgentsObjects)]
    public void Validation_Works(ExecutionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExecutionType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SwarmsClientInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExecutionType.ReturnAgents)]
    [InlineData(ExecutionType.ReturnSwarmRouterConfig)]
    [InlineData(ExecutionType.ReturnAgentsObjects)]
    public void SerializationRoundtrip_Works(ExecutionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExecutionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExecutionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExecutionType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExecutionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
