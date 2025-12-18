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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutoSwarmBuilderCreateCompletionResponse>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutoSwarmBuilderCreateCompletionResponse>(
            element
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        foreach (var item in expectedOutputs)
        {
            Assert.True(deserialized.Outputs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Outputs[item.Key]));
        }
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutoSwarmBuilderCreateCompletionResponse { Success = true };

        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutoSwarmBuilderCreateCompletionResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutoSwarmBuilderCreateCompletionResponse
        {
            Success = true,

            JobID = null,
            Outputs = null,
            Timestamp = null,
            Type = null,
            Usage = null,
        };

        Assert.Null(model.JobID);
        Assert.True(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Outputs);
        Assert.True(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutoSwarmBuilderCreateCompletionResponse
        {
            Success = true,

            JobID = null,
            Outputs = null,
            Timestamp = null,
            Type = null,
            Usage = null,
        };

        model.Validate();
    }
}
