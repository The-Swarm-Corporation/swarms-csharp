using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class AutoSwarmBuilderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.Client.AutoSwarmBuilder.CreateCompletion(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListExecutionTypes_Works()
    {
        await this.client.Client.AutoSwarmBuilder.ListExecutionTypes(
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
