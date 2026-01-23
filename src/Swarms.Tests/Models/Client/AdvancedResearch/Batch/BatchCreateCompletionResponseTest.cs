using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
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
        Assert.NotNull(model.Usage);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Usage[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateCompletionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateCompletionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCharactersPerSource, deserialized.CharactersPerSource);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, deserialized.Outputs));
        Assert.Equal(expectedSources, deserialized.Sources);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.NotNull(deserialized.Usage);
        Assert.Equal(expectedUsage.Count, deserialized.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(deserialized.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Usage[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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

        BatchCreateCompletionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
