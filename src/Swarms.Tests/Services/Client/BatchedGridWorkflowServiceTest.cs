using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client;

public class BatchedGridWorkflowServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CompleteWorkflow_Works()
    {
        var response = await this.client.Client.BatchedGridWorkflow.CompleteWorkflow(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
