using System.Text.Json;
using Swarms.Models.Client.BatchedGridWorkflow;

namespace Swarms.Tests.Models.Client.BatchedGridWorkflow;

public class BatchedGridWorkflowCompleteWorkflowResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchedGridWorkflowCompleteWorkflowResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
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

        string expectedDescription = "description";
        string expectedJobID = "job_id";
        string expectedName = "name";
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

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, model.Outputs));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchedGridWorkflowCompleteWorkflowResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchedGridWorkflowCompleteWorkflowResponse>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchedGridWorkflowCompleteWorkflowResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchedGridWorkflowCompleteWorkflowResponse>(
            json
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedJobID = "job_id";
        string expectedName = "name";
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

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedOutputs, deserialized.Outputs));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchedGridWorkflowCompleteWorkflowResponse
        {
            Description = "description",
            JobID = "job_id",
            Name = "name",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);
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
