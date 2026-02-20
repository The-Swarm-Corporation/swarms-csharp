using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class HealthServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        var response = await this.client.Health.Check(new(), TestContext.Current.CancellationToken);
        response.Validate();
    }
}
