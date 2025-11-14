using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Services.Swarms;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        await this.client.Swarms.Batch.Run(
            new()
            {
                Body =
                [
                    new()
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
                                            ToolConfigurations = new Dictionary<
                                                string,
                                                JsonElement
                                            >()
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
                    },
                ],
            }
        );
    }
}
