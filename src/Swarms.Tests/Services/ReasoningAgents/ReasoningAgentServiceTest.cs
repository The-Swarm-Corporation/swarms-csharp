using System.Threading.Tasks;

namespace Swarms.Tests.Services.ReasoningAgents;

public class ReasoningAgentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.ReasoningAgents.CreateCompletion();
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTypes_Works()
    {
        var response = await this.client.ReasoningAgents.ListTypes();
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }
}
