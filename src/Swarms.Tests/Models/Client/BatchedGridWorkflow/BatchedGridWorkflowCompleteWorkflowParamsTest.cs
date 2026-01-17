using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Tests.Models.Client.BatchedGridWorkflow;

public class BatchedGridWorkflowCompleteWorkflowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchedGridWorkflowCompleteWorkflowParams
        {
            AgentCompletions =
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
            Imgs = ["string"],
            MaxLoops = 0,
            Name = "name",
            Tasks = ["string"],
        };

        List<AgentSpec> expectedAgentCompletions =
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
        List<string> expectedImgs = ["string"];
        long expectedMaxLoops = 0;
        string expectedName = "name";
        List<string> expectedTasks = ["string"];

        Assert.NotNull(parameters.AgentCompletions);
        Assert.Equal(expectedAgentCompletions.Count, parameters.AgentCompletions.Count);
        for (int i = 0; i < expectedAgentCompletions.Count; i++)
        {
            Assert.Equal(expectedAgentCompletions[i], parameters.AgentCompletions[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Imgs);
        Assert.Equal(expectedImgs.Count, parameters.Imgs.Count);
        for (int i = 0; i < expectedImgs.Count; i++)
        {
            Assert.Equal(expectedImgs[i], parameters.Imgs[i]);
        }
        Assert.Equal(expectedMaxLoops, parameters.MaxLoops);
        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new BatchedGridWorkflowCompleteWorkflowParams { };

        Assert.Null(parameters.AgentCompletions);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_completions"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Imgs);
        Assert.False(parameters.RawBodyData.ContainsKey("imgs"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Tasks);
        Assert.False(parameters.RawBodyData.ContainsKey("tasks"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BatchedGridWorkflowCompleteWorkflowParams
        {
            AgentCompletions = null,
            Description = null,
            Imgs = null,
            MaxLoops = null,
            Name = null,
            Tasks = null,
        };

        Assert.Null(parameters.AgentCompletions);
        Assert.True(parameters.RawBodyData.ContainsKey("agent_completions"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Imgs);
        Assert.True(parameters.RawBodyData.ContainsKey("imgs"));
        Assert.Null(parameters.MaxLoops);
        Assert.True(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Tasks);
        Assert.True(parameters.RawBodyData.ContainsKey("tasks"));
    }

    [Fact]
    public void Url_Works()
    {
        BatchedGridWorkflowCompleteWorkflowParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/batched-grid-workflow/completions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchedGridWorkflowCompleteWorkflowParams
        {
            AgentCompletions =
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
            Imgs = ["string"],
            MaxLoops = 0,
            Name = "name",
            Tasks = ["string"],
        };

        BatchedGridWorkflowCompleteWorkflowParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
