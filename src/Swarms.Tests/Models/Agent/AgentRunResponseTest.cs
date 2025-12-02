using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class AgentRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentRunResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Success = true,
            Temperature = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedDescription = "description";
        string expectedJobID = "job_id";
        string expectedName = "name";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedSuccess = true;
        double expectedTemperature = 0;
        string expectedTimestamp = "timestamp";
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs));
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Usage[item.Key]));
        }
    }
}
