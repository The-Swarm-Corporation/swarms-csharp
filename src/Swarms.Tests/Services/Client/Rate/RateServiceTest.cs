using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client.Rate;

public class RateServiceTest : TestBase
{
    [Fact]
    public async Task GetLimits_Works()
    {
        var response = await this.client.Client.Rate.GetLimits(new());
        foreach (var item in response.Values)
        {
            _ = item;
        }
    }
}
