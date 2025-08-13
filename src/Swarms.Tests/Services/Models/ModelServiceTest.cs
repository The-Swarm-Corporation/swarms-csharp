using System.Threading.Tasks;

namespace Swarms.Tests.Services.Models;

public class ModelServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Models.ListAvailable(new());
        response.Validate();
    }
}
