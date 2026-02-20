using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class AgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Agent.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Agent.Run(new(), TestContext.Current.CancellationToken);
        response.Validate();
    }
}
