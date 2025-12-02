using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
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
        Assert.Equal(expectedTasks.Count, model.Tasks.Count);
        for (int i = 0; i < expectedTasks.Count; i++)
        {
            Assert.Equal(expectedTasks[i], model.Tasks[i]);
        }
    }
}
