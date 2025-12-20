using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Client.AutoSwarmBuilder;

namespace Swarms.Tests.Models.Client.AutoSwarmBuilder;

public class AutoSwarmBuilderCreateCompletionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AutoSwarmBuilderCreateCompletionParams
        {
            Description = "description",
            ExecutionType = ExecutionType.ReturnAgents,
            MaxLoops = 0,
            MaxTokens = 0,
            ModelName = "model_name",
            Name = "name",
            Task = "task",
        };

        string expectedDescription = "description";
        ApiEnum<string, ExecutionType> expectedExecutionType = ExecutionType.ReturnAgents;
        long expectedMaxLoops = 0;
        long expectedMaxTokens = 0;
        string expectedModelName = "model_name";
        string expectedName = "name";
        string expectedTask = "task";

        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExecutionType, parameters.ExecutionType);
        Assert.Equal(expectedMaxLoops, parameters.MaxLoops);
        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedModelName, parameters.ModelName);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedTask, parameters.Task);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AutoSwarmBuilderCreateCompletionParams { };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExecutionType);
        Assert.False(parameters.RawBodyData.ContainsKey("execution_type"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.ModelName);
        Assert.False(parameters.RawBodyData.ContainsKey("model_name"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AutoSwarmBuilderCreateCompletionParams
        {
            Description = null,
            ExecutionType = null,
            MaxLoops = null,
            MaxTokens = null,
            ModelName = null,
            Name = null,
            Task = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExecutionType);
        Assert.False(parameters.RawBodyData.ContainsKey("execution_type"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.ModelName);
        Assert.False(parameters.RawBodyData.ContainsKey("model_name"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
    }
}

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

        Assert.NotNull(value);
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
