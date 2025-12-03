using System.Text.Json;
using Swarms.Models.Agent.Batch;

namespace Swarms.Tests.Models.Agent.Batch;

public class BatchRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        string expectedBatchID = "batch_id";
        double expectedExecutionTime = 0;
        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTimestamp = "timestamp";
        long expectedTotalRequests = 0;

        Assert.Equal(expectedBatchID, model.BatchID);
        Assert.Equal(expectedExecutionTime, model.ExecutionTime);
        Assert.True(
            model.Results.HasValue && JsonElement.DeepEquals(expectedResults, model.Results.Value)
        );
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedTotalRequests, model.TotalRequests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchRunResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchRunResponse>(json);
        Assert.NotNull(deserialized);

        string expectedBatchID = "batch_id";
        double expectedExecutionTime = 0;
        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTimestamp = "timestamp";
        long expectedTotalRequests = 0;

        Assert.Equal(expectedBatchID, deserialized.BatchID);
        Assert.Equal(expectedExecutionTime, deserialized.ExecutionTime);
        Assert.True(
            deserialized.Results.HasValue
                && JsonElement.DeepEquals(expectedResults, deserialized.Results.Value)
        );
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedTotalRequests, deserialized.TotalRequests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Timestamp = "timestamp",
            TotalRequests = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Timestamp = "timestamp",
            TotalRequests = 0,

            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchRunResponse
        {
            BatchID = "batch_id",
            ExecutionTime = 0,
            Timestamp = "timestamp",
            TotalRequests = 0,

            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchRunResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.BatchID);
        Assert.False(model.RawData.ContainsKey("batch_id"));
        Assert.Null(model.ExecutionTime);
        Assert.False(model.RawData.ContainsKey("execution_time"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.TotalRequests);
        Assert.False(model.RawData.ContainsKey("total_requests"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchRunResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchRunResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),

            BatchID = null,
            ExecutionTime = null,
            Timestamp = null,
            TotalRequests = null,
        };

        Assert.Null(model.BatchID);
        Assert.True(model.RawData.ContainsKey("batch_id"));
        Assert.Null(model.ExecutionTime);
        Assert.True(model.RawData.ContainsKey("execution_time"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.TotalRequests);
        Assert.True(model.RawData.ContainsKey("total_requests"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchRunResponse
        {
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),

            BatchID = null,
            ExecutionTime = null,
            Timestamp = null,
            TotalRequests = null,
        };

        model.Validate();
    }
}
