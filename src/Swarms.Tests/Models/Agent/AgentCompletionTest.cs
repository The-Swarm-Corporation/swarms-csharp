using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class AgentCompletionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentCompletion
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
        };

        AgentSpec expectedAgentConfig = new()
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
        };
        AgentCompletionHistory expectedHistory = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedImg = "img";
        List<string> expectedImgs = ["string"];
        string expectedTask = "task";
        List<string> expectedToolsEnabled = ["string"];

        Assert.Equal(expectedAgentConfig, model.AgentConfig);
        Assert.Equal(expectedHistory, model.History);
        Assert.Equal(expectedImg, model.Img);
        Assert.Equal(expectedImgs.Count, model.Imgs.Count);
        for (int i = 0; i < expectedImgs.Count; i++)
        {
            Assert.Equal(expectedImgs[i], model.Imgs[i]);
        }
        Assert.Equal(expectedTask, model.Task);
        Assert.Equal(expectedToolsEnabled.Count, model.ToolsEnabled.Count);
        for (int i = 0; i < expectedToolsEnabled.Count; i++)
        {
            Assert.Equal(expectedToolsEnabled[i], model.ToolsEnabled[i]);
        }
    }
}
