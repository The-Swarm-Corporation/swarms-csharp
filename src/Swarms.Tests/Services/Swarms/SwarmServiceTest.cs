using System.Threading.Tasks;

namespace Swarms.Tests.Services.Swarms;

public class SwarmServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CheckAvailable_Works()
    {
        var response = await this.client.Swarms.CheckAvailable(new());
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetLogs_Works()
    {
        var response = await this.client.Swarms.GetLogs(new());
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Swarms.Run(new());
        response.Validate();
    }
}
