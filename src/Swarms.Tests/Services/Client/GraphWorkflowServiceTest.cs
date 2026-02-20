using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class GraphWorkflowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExecuteWorkflow_Works()
    {
        var response = await this.client.Client.GraphWorkflow.ExecuteWorkflow(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
