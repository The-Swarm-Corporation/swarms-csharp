using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class ModelServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Models.ListAvailable(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
