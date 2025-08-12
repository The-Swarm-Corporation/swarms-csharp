using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms.SwarmSpecProperties;

namespace Swarms.Tests.Services.Swarms.Batch;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Swarms.Batch.Run(
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
                                LlmArgs = new()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                MaxLoops = 0,
                                MaxTokens = 0,
                                McpURL = "mcp_url",
                                ModelName = "model_name",
                                Role = "role",
                                StreamingOn = true,
                                SystemPrompt = "system_prompt",
                                Temperature = 0,
                                ToolsListDictionary =
                                [
                                    new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
                                ],
                            },
                        ],
                        Description = "description",
                        HeavySwarmLoopsPerAgent = 0,
                        HeavySwarmQuestionAgentModelName = "heavy_swarm_question_agent_model_name",
                        HeavySwarmWorkerModelName = "heavy_swarm_worker_model_name",
                        Img = "img",
                        MaxLoops = 0,
                        Messages = new List<Dictionary<string, JsonElement>>()
                        {
                            new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
                        },
                        Name = "name",
                        RearrangeFlow = "rearrange_flow",
                        Rules = "rules",
                        ServiceTier = "service_tier",
                        Stream = true,
                        SwarmType = SwarmType.AgentRearrange,
                        Task = "task",
                        Tasks = ["string"],
                    },
                ],
            }
        );
        foreach (var item in response)
        {
            foreach (var item1 in item.Values)
            {
                _ = item1;
            }
        }
    }
}
