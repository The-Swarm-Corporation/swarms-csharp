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
        Assert.NotNull(model.Outputs);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs.Value));
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentRunResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentRunResponse>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Outputs);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, deserialized.Outputs.Value));
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentRunResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
            Success = true,
            Temperature = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentRunResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
            Success = true,
            Temperature = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentRunResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
            Success = true,
            Temperature = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            Outputs = null,
        };

        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentRunResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
            Success = true,
            Temperature = 0,
            Timestamp = "timestamp",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            Outputs = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentRunResponse
        {
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentRunResponse
        {
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentRunResponse
        {
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            JobID = null,
            Name = null,
            Success = null,
            Temperature = null,
            Timestamp = null,
            Usage = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.JobID);
        Assert.True(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Success);
        Assert.True(model.RawData.ContainsKey("success"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentRunResponse
        {
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            JobID = null,
            Name = null,
            Success = null,
            Temperature = null,
            Timestamp = null,
            Usage = null,
        };

        model.Validate();
    }
}
