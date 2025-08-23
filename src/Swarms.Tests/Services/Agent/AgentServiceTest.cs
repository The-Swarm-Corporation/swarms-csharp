using System.Threading.Tasks;

namespace Swarms.Tests.Services.Agent;

public class AgentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Agent.Run();
        response.Validate();
    }
}
