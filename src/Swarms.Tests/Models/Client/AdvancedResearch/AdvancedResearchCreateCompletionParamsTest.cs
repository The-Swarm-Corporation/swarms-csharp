using Swarms.Models.Client.AdvancedResearch;

namespace Swarms.Tests.Models.Client.AdvancedResearch;

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
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
        };

        string expectedDescription = "description";
        string expectedDirectorAgentName = "director_agent_name";
        long expectedDirectorMaxLoops = 0;
        long expectedDirectorMaxTokens = 0;
        string expectedDirectorModelName = "director_model_name";
        long expectedExaSearchMaxCharacters = 0;
        long expectedExaSearchNumResults = 0;
        long expectedMaxLoops = 0;
        string expectedName = "name";
        string expectedWorkerModelName = "worker_model_name";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirectorAgentName, model.DirectorAgentName);
        Assert.Equal(expectedDirectorMaxLoops, model.DirectorMaxLoops);
        Assert.Equal(expectedDirectorMaxTokens, model.DirectorMaxTokens);
        Assert.Equal(expectedDirectorModelName, model.DirectorModelName);
        Assert.Equal(expectedExaSearchMaxCharacters, model.ExaSearchMaxCharacters);
        Assert.Equal(expectedExaSearchNumResults, model.ExaSearchNumResults);
        Assert.Equal(expectedMaxLoops, model.MaxLoops);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedWorkerModelName, model.WorkerModelName);
    }
}
