using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Client.AutoSwarmBuilder;

namespace Swarms.Tests.Models.Client.AutoSwarmBuilder;

public class AutoSwarmBuilderCreateCompletionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutoSwarmBuilderCreateCompletionResponse
        {
            Success = true,
            JobID = "job_id",
            Outputs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timestamp = "timestamp",
            Type = "type",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        bool expectedSuccess = true;
        string expectedJobID = "job_id";
        Dictionary<string, JsonElement> expectedOutputs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTimestamp = "timestamp";
        string expectedType = "type";
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        foreach (var item in expectedOutputs)
        {
            Assert.True(model.Outputs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Outputs[item.Key]));
        }
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Usage[item.Key]));
        }
    }
}
