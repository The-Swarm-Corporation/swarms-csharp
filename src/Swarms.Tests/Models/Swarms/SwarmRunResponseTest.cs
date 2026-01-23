using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwarmRunResponse
        {
            Description = "description",
            ExecutionTime = 0,
            JobID = "job_id",
            NumberOfAgents = 0,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            ServiceTier = "service_tier",
            Status = "status",
            SwarmName = "swarm_name",
            SwarmType = "swarm_type",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedDescription = "description";
        double expectedExecutionTime = 0;
        string expectedJobID = "job_id";
        long expectedNumberOfAgents = 0;
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedServiceTier = "service_tier";
        string expectedStatus = "status";
        string expectedSwarmName = "swarm_name";
        string expectedSwarmType = "swarm_type";
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExecutionTime, model.ExecutionTime);
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedNumberOfAgents, model.NumberOfAgents);
        Assert.True(JsonElement.DeepEquals(expectedOutput, model.Output));
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSwarmName, model.SwarmName);
        Assert.Equal(expectedSwarmType, model.SwarmType);
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
        var model = new SwarmRunResponse
        {
            Description = "description",
            ExecutionTime = 0,
            JobID = "job_id",
            NumberOfAgents = 0,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            ServiceTier = "service_tier",
            Status = "status",
            SwarmName = "swarm_name",
            SwarmType = "swarm_type",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwarmRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwarmRunResponse
        {
            Description = "description",
            ExecutionTime = 0,
            JobID = "job_id",
            NumberOfAgents = 0,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            ServiceTier = "service_tier",
            Status = "status",
            SwarmName = "swarm_name",
            SwarmType = "swarm_type",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwarmRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        double expectedExecutionTime = 0;
        string expectedJobID = "job_id";
        long expectedNumberOfAgents = 0;
        JsonElement expectedOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedServiceTier = "service_tier";
        string expectedStatus = "status";
        string expectedSwarmName = "swarm_name";
        string expectedSwarmType = "swarm_type";
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExecutionTime, deserialized.ExecutionTime);
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedNumberOfAgents, deserialized.NumberOfAgents);
        Assert.True(JsonElement.DeepEquals(expectedOutput, deserialized.Output));
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSwarmName, deserialized.SwarmName);
        Assert.Equal(expectedSwarmType, deserialized.SwarmType);
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
        var model = new SwarmRunResponse
        {
            Description = "description",
            ExecutionTime = 0,
            JobID = "job_id",
            NumberOfAgents = 0,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            ServiceTier = "service_tier",
            Status = "status",
            SwarmName = "swarm_name",
            SwarmType = "swarm_type",
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
        var model = new SwarmRunResponse
        {
            Description = "description",
            ExecutionTime = 0,
            JobID = "job_id",
            NumberOfAgents = 0,
            Output = JsonSerializer.Deserialize<JsonElement>("{}"),
            ServiceTier = "service_tier",
            Status = "status",
            SwarmName = "swarm_name",
            SwarmType = "swarm_type",
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        SwarmRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
