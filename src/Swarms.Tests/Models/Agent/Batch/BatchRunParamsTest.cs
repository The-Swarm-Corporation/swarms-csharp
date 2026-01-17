using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;
using Swarms.Models.Agent.Batch;

namespace Swarms.Tests.Models.Agent.Batch;

public class BatchRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchRunParams
        {
            Body =
            [
                new()
                {
                    AgentConfig = new()
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
                                    Headers = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
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
                    History = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                    Img = "img",
                    Imgs = ["string"],
                    Task = "task",
                    ToolsEnabled = ["string"],
                },
            ],
        };

        List<AgentCompletion> expectedBody =
        [
            new()
            {
                AgentConfig = new()
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
                History = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Img = "img",
                Imgs = ["string"],
                Task = "task",
                ToolsEnabled = ["string"],
            },
        ];

        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        for (int i = 0; i < expectedBody.Count; i++)
        {
            Assert.Equal(expectedBody[i], parameters.Body[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        BatchRunParams parameters = new()
        {
            Body =
            [
                new()
                {
                    AgentConfig = new()
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
                                    Headers = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
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
                    History = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                    Img = "img",
                    Imgs = ["string"],
                    Task = "task",
                    ToolsEnabled = ["string"],
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/agent/batch/completions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchRunParams
        {
            Body =
            [
                new()
                {
                    AgentConfig = new()
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
                                    Headers = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
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
                    History = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                    Img = "img",
                    Imgs = ["string"],
                    Task = "task",
                    ToolsEnabled = ["string"],
                },
            ],
        };

        BatchRunParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
