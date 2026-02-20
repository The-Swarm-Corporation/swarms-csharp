using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class MarketplaceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateAgent_Works()
    {
        var response = await this.client.Client.Marketplace.CreateAgent(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
