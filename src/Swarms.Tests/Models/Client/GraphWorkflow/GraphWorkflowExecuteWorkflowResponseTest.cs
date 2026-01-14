using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Client.GraphWorkflow;

namespace Swarms.Tests.Models.Client.GraphWorkflow;

public class GraphWorkflowExecuteWorkflowResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
            Description = "description",
            Name = "name",
        };

        string expectedJobID = "job_id";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";
        Usage expectedUsage = new()
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedJobID, model.JobID);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
            Description = "description",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphWorkflowExecuteWorkflowResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
            Description = "description",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphWorkflowExecuteWorkflowResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedJobID = "job_id";
        JsonElement expectedOutputs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";
        Usage expectedUsage = new()
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, deserialized.Outputs));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
            Description = "description",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },

            Description = null,
            Name = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GraphWorkflowExecuteWorkflowResponse
        {
            JobID = "job_id",
            Outputs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
            Usage = new()
            {
                CostPerAgent = 0,
                InputTokens = 0,
                OutputTokens = 0,
                TokenCost = 0,
                TotalTokens = 0,
            },

            Description = null,
            Name = null,
        };

        model.Validate();
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };

        double expectedCostPerAgent = 0;
        long expectedInputTokens = 0;
        long expectedOutputTokens = 0;
        double expectedTokenCost = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCostPerAgent, model.CostPerAgent);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedTokenCost, model.TokenCost);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedCostPerAgent = 0;
        long expectedInputTokens = 0;
        long expectedOutputTokens = 0;
        double expectedTokenCost = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCostPerAgent, deserialized.CostPerAgent);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedTokenCost, deserialized.TokenCost);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            CostPerAgent = 0,
            InputTokens = 0,
            OutputTokens = 0,
            TokenCost = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }
}
