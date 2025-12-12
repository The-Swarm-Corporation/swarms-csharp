using System.Threading.Tasks;

namespace Swarms.Tests.Services.Client.AdvancedResearch;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateCompletion_Works()
    {
        var response = await this.client.Client.AdvancedResearch.Batch.CreateCompletion(
            new()
            {
                InputSchemas =
                [
                    new()
                    {
                        Config = new()
                        {
                            Description = "description",
                            DirectorAgentName = "director_agent_name",
                            DirectorMaxLoops = 0,
                            DirectorMaxTokens = 0,
                            DirectorModelName = "director_model_name",
                            ExaSearchMaxCharacters = 0,
                            ExaSearchNumResults = 0,
                            MaxLoops = 0,
                            Name = "name",
                            WorkerModelName = "worker_model_name",
                        },
                        Task = "task",
                        Img = "img",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }
}
