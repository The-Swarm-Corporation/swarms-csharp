using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swarms.Tests.Services.Agent;

public class AgentServiceTest : TestBase
{
    [Fact]
    public async Task Run_Works()
    {
        var response = await this.client.Agent.Run(
            new()
            {
                AgentConfig = new()
                {
                    AgentName = "agent_name",
                    AutoGeneratePrompt = true,
                    Description = "description",
                    DynamicTemperatureEnabled = true,
                    LlmArgs = new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
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
                History = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Img = "img",
                Imgs = ["string"],
                Stream = true,
                Task = "task",
            }
        );
        response.Validate();
    }
}
