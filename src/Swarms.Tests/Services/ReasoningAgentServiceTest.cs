using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class ReasoningAgentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        await this.client.ReasoningAgents.CreateCompletion();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTypes_Works()
    {
        await this.client.ReasoningAgents.ListTypes();
    }
}
