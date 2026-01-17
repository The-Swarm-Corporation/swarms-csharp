using System;
using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Tests.Models.ReasoningAgents;

public class ReasoningAgentCreateCompletionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReasoningAgentCreateCompletionParams
        {
            AgentName = "agent_name",
            Description = "description",
            MaxLoops = 0,
            MemoryCapacity = 0,
            ModelName = "model_name",
            NumKnowledgeItems = 0,
            NumSamples = 0,
            OutputType = OutputType.List,
            SwarmType = SwarmType.ReasoningDuo,
            SystemPrompt = "system_prompt",
            Task = "task",
        };

        string expectedAgentName = "agent_name";
        string expectedDescription = "description";
        long expectedMaxLoops = 0;
        long expectedMemoryCapacity = 0;
        string expectedModelName = "model_name";
        long expectedNumKnowledgeItems = 0;
        long expectedNumSamples = 0;
        ApiEnum<string, OutputType> expectedOutputType = OutputType.List;
        ApiEnum<string, SwarmType> expectedSwarmType = SwarmType.ReasoningDuo;
        string expectedSystemPrompt = "system_prompt";
        string expectedTask = "task";

        Assert.Equal(expectedAgentName, parameters.AgentName);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMaxLoops, parameters.MaxLoops);
        Assert.Equal(expectedMemoryCapacity, parameters.MemoryCapacity);
        Assert.Equal(expectedModelName, parameters.ModelName);
        Assert.Equal(expectedNumKnowledgeItems, parameters.NumKnowledgeItems);
        Assert.Equal(expectedNumSamples, parameters.NumSamples);
        Assert.Equal(expectedOutputType, parameters.OutputType);
        Assert.Equal(expectedSwarmType, parameters.SwarmType);
        Assert.Equal(expectedSystemPrompt, parameters.SystemPrompt);
        Assert.Equal(expectedTask, parameters.Task);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReasoningAgentCreateCompletionParams { };

        Assert.Null(parameters.AgentName);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_name"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.MemoryCapacity);
        Assert.False(parameters.RawBodyData.ContainsKey("memory_capacity"));
        Assert.Null(parameters.ModelName);
        Assert.False(parameters.RawBodyData.ContainsKey("model_name"));
        Assert.Null(parameters.NumKnowledgeItems);
        Assert.False(parameters.RawBodyData.ContainsKey("num_knowledge_items"));
        Assert.Null(parameters.NumSamples);
        Assert.False(parameters.RawBodyData.ContainsKey("num_samples"));
        Assert.Null(parameters.OutputType);
        Assert.False(parameters.RawBodyData.ContainsKey("output_type"));
        Assert.Null(parameters.SwarmType);
        Assert.False(parameters.RawBodyData.ContainsKey("swarm_type"));
        Assert.Null(parameters.SystemPrompt);
        Assert.False(parameters.RawBodyData.ContainsKey("system_prompt"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ReasoningAgentCreateCompletionParams
        {
            AgentName = null,
            Description = null,
            MaxLoops = null,
            MemoryCapacity = null,
            ModelName = null,
            NumKnowledgeItems = null,
            NumSamples = null,
            OutputType = null,
            SwarmType = null,
            SystemPrompt = null,
            Task = null,
        };

        Assert.Null(parameters.AgentName);
        Assert.True(parameters.RawBodyData.ContainsKey("agent_name"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxLoops);
        Assert.True(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.MemoryCapacity);
        Assert.True(parameters.RawBodyData.ContainsKey("memory_capacity"));
        Assert.Null(parameters.ModelName);
        Assert.True(parameters.RawBodyData.ContainsKey("model_name"));
        Assert.Null(parameters.NumKnowledgeItems);
        Assert.True(parameters.RawBodyData.ContainsKey("num_knowledge_items"));
        Assert.Null(parameters.NumSamples);
        Assert.True(parameters.RawBodyData.ContainsKey("num_samples"));
        Assert.Null(parameters.OutputType);
        Assert.True(parameters.RawBodyData.ContainsKey("output_type"));
        Assert.Null(parameters.SwarmType);
        Assert.True(parameters.RawBodyData.ContainsKey("swarm_type"));
        Assert.Null(parameters.SystemPrompt);
        Assert.True(parameters.RawBodyData.ContainsKey("system_prompt"));
        Assert.Null(parameters.Task);
        Assert.True(parameters.RawBodyData.ContainsKey("task"));
    }

    [Fact]
    public void Url_Works()
    {
        ReasoningAgentCreateCompletionParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/reasoning-agent/completions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReasoningAgentCreateCompletionParams
        {
            AgentName = "agent_name",
            Description = "description",
            MaxLoops = 0,
            MemoryCapacity = 0,
            ModelName = "model_name",
            NumKnowledgeItems = 0,
            NumSamples = 0,
            OutputType = OutputType.List,
            SwarmType = SwarmType.ReasoningDuo,
            SystemPrompt = "system_prompt",
            Task = "task",
        };

        ReasoningAgentCreateCompletionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
