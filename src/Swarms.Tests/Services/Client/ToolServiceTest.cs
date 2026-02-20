using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class ToolServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Client.Tools.ListAvailable(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
