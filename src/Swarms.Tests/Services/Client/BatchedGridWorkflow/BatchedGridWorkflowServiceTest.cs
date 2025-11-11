using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client.BatchedGridWorkflow;

public class BatchedGridWorkflowServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CompleteWorkflow_Works()
    {
        var response = await this.client.Client.BatchedGridWorkflow.CompleteWorkflow();
        response.Validate();
    }
}
