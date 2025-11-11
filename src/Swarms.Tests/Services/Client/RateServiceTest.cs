using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class RateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetLimits_Works()
    {
        var response = await this.client.Client.Rate.GetLimits();
        response.Validate();
    }
}
