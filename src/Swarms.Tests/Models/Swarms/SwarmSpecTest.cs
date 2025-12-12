using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models.Agent;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwarmSpec
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
                        URL = "url",
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
                                URL = "url",
                            },
                        ]
                    ),
                    McpURL = "mcp_url",
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
            SwarmType = SwarmSpecSwarmType.AgentRearrange,
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
                    URL = "url",
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
                            URL = "url",
                        },
                    ]
                ),
                McpURL = "mcp_url",
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
        SwarmSpecMessages expectedMessages = new(
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
        ApiEnum<string, SwarmSpecSwarmType> expectedSwarmType = SwarmSpecSwarmType.AgentRearrange;
        string expectedTask = "task";
        List<string> expectedTasks = ["string"];

        Assert.NotNull(model.Agents);
        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHeavySwarmLoopsPerAgent, model.HeavySwarmLoopsPerAgent);
        Assert.Equal(
            expectedHeavySwarmQuestionAgentModelName,
            model.HeavySwarmQuestionAgentModelName
        );
        Assert.Equal(expectedHeavySwarmWorkerModelName, model.HeavySwarmWorkerModelName);
        Assert.Equal(expectedImg, model.Img);
        Assert.Equal(expectedMaxLoops, model.MaxLoops);
        Assert.Equal(expectedMessages, model.Messages);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRearrangeFlow, model.RearrangeFlow);
        Assert.Equal(expectedRules, model.Rules);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedStream, model.Stream);
        Assert.Equal(expectedSwarmType, model.SwarmType);
        Assert.Equal(expectedTask, model.Task);
        Assert.NotNull(model.Tasks);
        Assert.Equal(expectedTasks.Count, model.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], model.Tasks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwarmSpec
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
                        URL = "url",
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
                                URL = "url",
                            },
                        ]
                    ),
                    McpURL = "mcp_url",
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
            SwarmType = SwarmSpecSwarmType.AgentRearrange,
            Task = "task",
            Tasks = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmSpec>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwarmSpec
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
                        URL = "url",
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
                                URL = "url",
                            },
                        ]
                    ),
                    McpURL = "mcp_url",
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
            SwarmType = SwarmSpecSwarmType.AgentRearrange,
            Task = "task",
            Tasks = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmSpec>(json);
        Assert.NotNull(deserialized);

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
                    URL = "url",
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
                            URL = "url",
                        },
                    ]
                ),
                McpURL = "mcp_url",
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
        SwarmSpecMessages expectedMessages = new(
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
        ApiEnum<string, SwarmSpecSwarmType> expectedSwarmType = SwarmSpecSwarmType.AgentRearrange;
        string expectedTask = "task";
        List<string> expectedTasks = ["string"];

        Assert.NotNull(deserialized.Agents);
        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHeavySwarmLoopsPerAgent, deserialized.HeavySwarmLoopsPerAgent);
        Assert.Equal(
            expectedHeavySwarmQuestionAgentModelName,
            deserialized.HeavySwarmQuestionAgentModelName
        );
        Assert.Equal(expectedHeavySwarmWorkerModelName, deserialized.HeavySwarmWorkerModelName);
        Assert.Equal(expectedImg, deserialized.Img);
        Assert.Equal(expectedMaxLoops, deserialized.MaxLoops);
        Assert.Equal(expectedMessages, deserialized.Messages);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRearrangeFlow, deserialized.RearrangeFlow);
        Assert.Equal(expectedRules, deserialized.Rules);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.Equal(expectedSwarmType, deserialized.SwarmType);
        Assert.Equal(expectedTask, deserialized.Task);
        Assert.NotNull(deserialized.Tasks);
        Assert.Equal(expectedTasks.Count, deserialized.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], deserialized.Tasks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwarmSpec
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
                        URL = "url",
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
                                URL = "url",
                            },
                        ]
                    ),
                    McpURL = "mcp_url",
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
            SwarmType = SwarmSpecSwarmType.AgentRearrange,
            Task = "task",
            Tasks = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SwarmSpec { };

        Assert.Null(model.Agents);
        Assert.False(model.RawData.ContainsKey("agents"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.HeavySwarmLoopsPerAgent);
        Assert.False(model.RawData.ContainsKey("heavy_swarm_loops_per_agent"));
        Assert.Null(model.HeavySwarmQuestionAgentModelName);
        Assert.False(model.RawData.ContainsKey("heavy_swarm_question_agent_model_name"));
        Assert.Null(model.HeavySwarmWorkerModelName);
        Assert.False(model.RawData.ContainsKey("heavy_swarm_worker_model_name"));
        Assert.Null(model.Img);
        Assert.False(model.RawData.ContainsKey("img"));
        Assert.Null(model.MaxLoops);
        Assert.False(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.RearrangeFlow);
        Assert.False(model.RawData.ContainsKey("rearrange_flow"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.SwarmType);
        Assert.False(model.RawData.ContainsKey("swarm_type"));
        Assert.Null(model.Task);
        Assert.False(model.RawData.ContainsKey("task"));
        Assert.Null(model.Tasks);
        Assert.False(model.RawData.ContainsKey("tasks"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SwarmSpec { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SwarmSpec
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

        Assert.Null(model.Agents);
        Assert.True(model.RawData.ContainsKey("agents"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.HeavySwarmLoopsPerAgent);
        Assert.True(model.RawData.ContainsKey("heavy_swarm_loops_per_agent"));
        Assert.Null(model.HeavySwarmQuestionAgentModelName);
        Assert.True(model.RawData.ContainsKey("heavy_swarm_question_agent_model_name"));
        Assert.Null(model.HeavySwarmWorkerModelName);
        Assert.True(model.RawData.ContainsKey("heavy_swarm_worker_model_name"));
        Assert.Null(model.Img);
        Assert.True(model.RawData.ContainsKey("img"));
        Assert.Null(model.MaxLoops);
        Assert.True(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.Messages);
        Assert.True(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.RearrangeFlow);
        Assert.True(model.RawData.ContainsKey("rearrange_flow"));
        Assert.Null(model.Rules);
        Assert.True(model.RawData.ContainsKey("rules"));
        Assert.Null(model.ServiceTier);
        Assert.True(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Stream);
        Assert.True(model.RawData.ContainsKey("stream"));
        Assert.Null(model.SwarmType);
        Assert.True(model.RawData.ContainsKey("swarm_type"));
        Assert.Null(model.Task);
        Assert.True(model.RawData.ContainsKey("task"));
        Assert.Null(model.Tasks);
        Assert.True(model.RawData.ContainsKey("tasks"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SwarmSpec
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

        model.Validate();
    }
}

public class SwarmSpecMessagesTest : TestBase
{
    [Fact]
    public void JsonElementsValidation_Works()
    {
        SwarmSpecMessages value = new(
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
        SwarmSpecMessages value = new(
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
        SwarmSpecMessages value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SwarmSpecMessages>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works1()
    {
        SwarmSpecMessages value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<SwarmSpecMessages>(json);

        Assert.Equal(value, deserialized);
    }
}

public class SwarmSpecSwarmTypeTest : TestBase
{
    [Theory]
    [InlineData(SwarmSpecSwarmType.AgentRearrange)]
    [InlineData(SwarmSpecSwarmType.MixtureOfAgents)]
    [InlineData(SwarmSpecSwarmType.SequentialWorkflow)]
    [InlineData(SwarmSpecSwarmType.ConcurrentWorkflow)]
    [InlineData(SwarmSpecSwarmType.GroupChat)]
    [InlineData(SwarmSpecSwarmType.MultiAgentRouter)]
    [InlineData(SwarmSpecSwarmType.AutoSwarmBuilder)]
    [InlineData(SwarmSpecSwarmType.HiearchicalSwarm)]
    [InlineData(SwarmSpecSwarmType.Auto)]
    [InlineData(SwarmSpecSwarmType.MajorityVoting)]
    [InlineData(SwarmSpecSwarmType.Malt)]
    [InlineData(SwarmSpecSwarmType.DeepResearchSwarm)]
    [InlineData(SwarmSpecSwarmType.CouncilAsAJudge)]
    [InlineData(SwarmSpecSwarmType.InteractiveGroupChat)]
    [InlineData(SwarmSpecSwarmType.HeavySwarm)]
    public void Validation_Works(SwarmSpecSwarmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwarmSpecSwarmType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwarmSpecSwarmType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SwarmsClientInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwarmSpecSwarmType.AgentRearrange)]
    [InlineData(SwarmSpecSwarmType.MixtureOfAgents)]
    [InlineData(SwarmSpecSwarmType.SequentialWorkflow)]
    [InlineData(SwarmSpecSwarmType.ConcurrentWorkflow)]
    [InlineData(SwarmSpecSwarmType.GroupChat)]
    [InlineData(SwarmSpecSwarmType.MultiAgentRouter)]
    [InlineData(SwarmSpecSwarmType.AutoSwarmBuilder)]
    [InlineData(SwarmSpecSwarmType.HiearchicalSwarm)]
    [InlineData(SwarmSpecSwarmType.Auto)]
    [InlineData(SwarmSpecSwarmType.MajorityVoting)]
    [InlineData(SwarmSpecSwarmType.Malt)]
    [InlineData(SwarmSpecSwarmType.DeepResearchSwarm)]
    [InlineData(SwarmSpecSwarmType.CouncilAsAJudge)]
    [InlineData(SwarmSpecSwarmType.InteractiveGroupChat)]
    [InlineData(SwarmSpecSwarmType.HeavySwarm)]
    public void SerializationRoundtrip_Works(SwarmSpecSwarmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwarmSpecSwarmType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwarmSpecSwarmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwarmSpecSwarmType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwarmSpecSwarmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
