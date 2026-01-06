using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SwarmRunParams
        {
            Agents =
            [
                new()
                {
                    AgentName = "agent_name",
                    AutoGeneratePrompt = true,
                    Description = "description",
                    DynamicTemperatureEnabled = true,
                    LlmArgs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MaxLoops = 0,
                    MaxTokens = 0,
                    McpConfig = new()
                    {
                        AuthorizationToken = "authorization_token",
                        Headers = new Dictionary<string, string>() { { "foo", "string" } },
                        Timeout = 0,
                        ToolConfigurations = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Transport = "transport",
                        Type = "type",
                        Url = "url",
                    },
                    McpConfigs = new(
                        [
                            new()
                            {
                                AuthorizationToken = "authorization_token",
                                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                                Timeout = 0,
                                ToolConfigurations = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                Transport = "transport",
                                Type = "type",
                                Url = "url",
                            },
                        ]
                    ),
                    McpUrl = "mcp_url",
                    ModelName = "model_name",
                    ReasoningEffort = "reasoning_effort",
                    ReasoningEnabled = true,
                    Role = "role",
                    StreamingOn = true,
                    SystemPrompt = "system_prompt",
                    Temperature = 0,
                    ThinkingTokens = 0,
                    ToolCallSummary = true,
                    ToolsListDictionary =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                },
            ],
            Description = "description",
            HeavySwarmLoopsPerAgent = 0,
            HeavySwarmQuestionAgentModelName = "heavy_swarm_question_agent_model_name",
            HeavySwarmWorkerModelName = "heavy_swarm_worker_model_name",
            Img = "img",
            MaxLoops = 0,
            Messages = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            RearrangeFlow = "rearrange_flow",
            Rules = "rules",
            ServiceTier = "service_tier",
            Stream = true,
            SwarmType = SwarmType.AgentRearrange,
            Task = "task",
            Tasks = ["string"],
        };

        List<AgentSpec> expectedAgents =
        [
            new()
            {
                AgentName = "agent_name",
                AutoGeneratePrompt = true,
                Description = "description",
                DynamicTemperatureEnabled = true,
                LlmArgs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MaxLoops = 0,
                MaxTokens = 0,
                McpConfig = new()
                {
                    AuthorizationToken = "authorization_token",
                    Headers = new Dictionary<string, string>() { { "foo", "string" } },
                    Timeout = 0,
                    ToolConfigurations = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Transport = "transport",
                    Type = "type",
                    Url = "url",
                },
                McpConfigs = new(
                    [
                        new()
                        {
                            AuthorizationToken = "authorization_token",
                            Headers = new Dictionary<string, string>() { { "foo", "string" } },
                            Timeout = 0,
                            ToolConfigurations = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Transport = "transport",
                            Type = "type",
                            Url = "url",
                        },
                    ]
                ),
                McpUrl = "mcp_url",
                ModelName = "model_name",
                ReasoningEffort = "reasoning_effort",
                ReasoningEnabled = true,
                Role = "role",
                StreamingOn = true,
                SystemPrompt = "system_prompt",
                Temperature = 0,
                ThinkingTokens = 0,
                ToolCallSummary = true,
                ToolsListDictionary =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
            },
        ];
        string expectedDescription = "description";
        long expectedHeavySwarmLoopsPerAgent = 0;
        string expectedHeavySwarmQuestionAgentModelName = "heavy_swarm_question_agent_model_name";
        string expectedHeavySwarmWorkerModelName = "heavy_swarm_worker_model_name";
        string expectedImg = "img";
        long expectedMaxLoops = 0;
        Messages expectedMessages = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string expectedName = "name";
        string expectedRearrangeFlow = "rearrange_flow";
        string expectedRules = "rules";
        string expectedServiceTier = "service_tier";
        bool expectedStream = true;
        ApiEnum<string, SwarmType> expectedSwarmType = SwarmType.AgentRearrange;
        string expectedTask = "task";
        List<string> expectedTasks = ["string"];

        Assert.NotNull(parameters.Agents);
        Assert.Equal(expectedAgents.Count, parameters.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], parameters.Agents[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHeavySwarmLoopsPerAgent, parameters.HeavySwarmLoopsPerAgent);
        Assert.Equal(
            expectedHeavySwarmQuestionAgentModelName,
            parameters.HeavySwarmQuestionAgentModelName
        );
        Assert.Equal(expectedHeavySwarmWorkerModelName, parameters.HeavySwarmWorkerModelName);
        Assert.Equal(expectedImg, parameters.Img);
        Assert.Equal(expectedMaxLoops, parameters.MaxLoops);
        Assert.Equal(expectedMessages, parameters.Messages);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRearrangeFlow, parameters.RearrangeFlow);
        Assert.Equal(expectedRules, parameters.Rules);
        Assert.Equal(expectedServiceTier, parameters.ServiceTier);
        Assert.Equal(expectedStream, parameters.Stream);
        Assert.Equal(expectedSwarmType, parameters.SwarmType);
        Assert.Equal(expectedTask, parameters.Task);
        Assert.NotNull(parameters.Tasks);
        Assert.Equal(expectedTasks.Count, parameters.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], parameters.Tasks[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SwarmRunParams { };

        Assert.Null(parameters.Agents);
        Assert.False(parameters.RawBodyData.ContainsKey("agents"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HeavySwarmLoopsPerAgent);
        Assert.False(parameters.RawBodyData.ContainsKey("heavy_swarm_loops_per_agent"));
        Assert.Null(parameters.HeavySwarmQuestionAgentModelName);
        Assert.False(parameters.RawBodyData.ContainsKey("heavy_swarm_question_agent_model_name"));
        Assert.Null(parameters.HeavySwarmWorkerModelName);
        Assert.False(parameters.RawBodyData.ContainsKey("heavy_swarm_worker_model_name"));
        Assert.Null(parameters.Img);
        Assert.False(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Messages);
        Assert.False(parameters.RawBodyData.ContainsKey("messages"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RearrangeFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("rearrange_flow"));
        Assert.Null(parameters.Rules);
        Assert.False(parameters.RawBodyData.ContainsKey("rules"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.SwarmType);
        Assert.False(parameters.RawBodyData.ContainsKey("swarm_type"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.Tasks);
        Assert.False(parameters.RawBodyData.ContainsKey("tasks"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SwarmRunParams
        {
            Agents = null,
            Description = null,
            HeavySwarmLoopsPerAgent = null,
            HeavySwarmQuestionAgentModelName = null,
            HeavySwarmWorkerModelName = null,
            Img = null,
            MaxLoops = null,
            Messages = null,
            Name = null,
            RearrangeFlow = null,
            Rules = null,
            ServiceTier = null,
            Stream = null,
            SwarmType = null,
            Task = null,
            Tasks = null,
        };

        Assert.Null(parameters.Agents);
        Assert.True(parameters.RawBodyData.ContainsKey("agents"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HeavySwarmLoopsPerAgent);
        Assert.True(parameters.RawBodyData.ContainsKey("heavy_swarm_loops_per_agent"));
        Assert.Null(parameters.HeavySwarmQuestionAgentModelName);
        Assert.True(parameters.RawBodyData.ContainsKey("heavy_swarm_question_agent_model_name"));
        Assert.Null(parameters.HeavySwarmWorkerModelName);
        Assert.True(parameters.RawBodyData.ContainsKey("heavy_swarm_worker_model_name"));
        Assert.Null(parameters.Img);
        Assert.True(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.MaxLoops);
        Assert.True(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Messages);
        Assert.True(parameters.RawBodyData.ContainsKey("messages"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RearrangeFlow);
        Assert.True(parameters.RawBodyData.ContainsKey("rearrange_flow"));
        Assert.Null(parameters.Rules);
        Assert.True(parameters.RawBodyData.ContainsKey("rules"));
        Assert.Null(parameters.ServiceTier);
        Assert.True(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Stream);
        Assert.True(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.SwarmType);
        Assert.True(parameters.RawBodyData.ContainsKey("swarm_type"));
        Assert.Null(parameters.Task);
        Assert.True(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.Tasks);
        Assert.True(parameters.RawBodyData.ContainsKey("tasks"));
    }

    [Fact]
    public void Url_Works()
    {
        SwarmRunParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/swarm/completions"), url);
    }
}

public class MessagesTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
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
    public void JsonElementsValidationWorks1()
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
    public void JsonElementsSerializationRoundtripWorks()
    {
        Messages value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        Messages value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages>(element);

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

        Assert.NotNull(value);
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
