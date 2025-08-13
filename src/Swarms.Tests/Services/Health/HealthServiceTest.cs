using System.Threading.Tasks;

namespace Swarms.Tests.Services.Health;

public class HealthServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        var response = await this.client.Health.Check(new());
        response.Validate();
    }
}
