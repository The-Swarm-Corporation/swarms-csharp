using System.Threading.Tasks;

namespace Swarms.Tests.Services.Models;

public class ModelServiceTest : TestBase
{
    [Fact]
    public async Task ListAvailable_Works()
    {
        var response = await this.client.Models.ListAvailable(new());
        response.Validate();
    }
}
