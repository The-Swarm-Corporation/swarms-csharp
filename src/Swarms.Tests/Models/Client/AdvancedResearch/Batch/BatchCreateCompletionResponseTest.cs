using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Client.AdvancedResearch.Batch;

namespace Swarms.Tests.Models.Client.AdvancedResearch.Batch;

public class BatchCreateCompletionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCreateCompletionResponse
        {
            ID = "id",
            CharactersPerSource = 0,
            Description = "description",
            Name = "name",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Sources = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "id";
        long expectedCharactersPerSource = 0;
        string expectedDescription = "description";
        string expectedName = "name";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedSources = 0;
        string expectedTimestamp = "timestamp";
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCharactersPerSource, model.CharactersPerSource);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs));
        Assert.Equal(expectedSources, model.Sources);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Usage[item.Key]));
        }
    }
}
