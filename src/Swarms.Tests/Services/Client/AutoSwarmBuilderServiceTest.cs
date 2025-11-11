using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class AutoSwarmBuilderServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.Client.AutoSwarmBuilder.CreateCompletion();
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListExecutionTypes_Works()
    {
        await this.client.Client.AutoSwarmBuilder.ListExecutionTypes();
    }
}
