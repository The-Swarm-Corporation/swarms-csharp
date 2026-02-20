using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class ReasoningAgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        await this.client.ReasoningAgents.CreateCompletion(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTypes_Works()
    {
        await this.client.ReasoningAgents.ListTypes(new(), TestContext.Current.CancellationToken);
    }
}
