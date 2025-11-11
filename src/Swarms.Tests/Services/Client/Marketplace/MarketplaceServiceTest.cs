using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client.Marketplace;

public class MarketplaceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAgents_Works()
    {
        var response = await this.client.Client.Marketplace.ListAgents();
        response.Validate();
    }
}
