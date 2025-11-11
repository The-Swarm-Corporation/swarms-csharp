using System.Threading.Tasks;

namespace Swarms.Tests.Services;

public class ModelServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Models.ListAvailable();
        response.Validate();
    }
}
