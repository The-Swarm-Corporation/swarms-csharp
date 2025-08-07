using System.Threading.Tasks;
using Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

namespace Swarms.Tests.Services.ReasoningAgents;

public class ReasoningAgentServiceTest : TestBase
{
    [Fact]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.ReasoningAgents.CreateCompletion(
            new()
            {
                AgentName = "agent_name",
                Description = "description",
                MaxLoops = 0,
                MemoryCapacity = 0,
                ModelName = "model_name",
                NumKnowledgeItems = 0,
                NumSamples = 0,
                OutputType = OutputType.List,
                SwarmType = SwarmType.ReasoningDuo,
                SystemPrompt = "system_prompt",
                Task = "task",
            }
        );
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }

    [Fact]
    public async Task ListTypes_Works()
    {
        var response = await this.client.ReasoningAgents.ListTypes(new());
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }
}
