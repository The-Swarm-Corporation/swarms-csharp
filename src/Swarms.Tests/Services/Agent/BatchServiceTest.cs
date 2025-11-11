using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swarms.Tests.Services.Agent;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Agent.Batch.Run(
            new()
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
                                URL = "url",
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
                    },
                ],
            }
        );
        response.Validate();
    }
}
