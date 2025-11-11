using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class ToolServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Client.Tools.ListAvailable();
        response.Validate();
    }
}
