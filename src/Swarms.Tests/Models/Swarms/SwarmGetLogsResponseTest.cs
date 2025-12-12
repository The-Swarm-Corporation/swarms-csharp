using System.Text.Json;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmGetLogsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
        };

        long expectedCount = 0;
        JsonElement expectedLogs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedCount, model.Count);
        Assert.NotNull(model.Logs);
        Assert.True(JsonElement.DeepEquals(expectedLogs, model.Logs.Value));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmGetLogsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmGetLogsResponse>(json);
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        JsonElement expectedLogs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.NotNull(deserialized.Logs);
        Assert.True(JsonElement.DeepEquals(expectedLogs, deserialized.Logs.Value));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Timestamp = "timestamp",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Status = "status",
            Timestamp = "timestamp",

            // Null should be interpreted as omitted for these properties
            Logs = null,
        };

        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Count = 0,
            Status = "status",
            Timestamp = "timestamp",

            // Null should be interpreted as omitted for these properties
            Logs = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),

            Count = null,
            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Count);
        Assert.True(model.RawData.ContainsKey("count"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SwarmGetLogsResponse
        {
            Logs = JsonSerializer.Deserialize<JsonElement>("{}"),

            Count = null,
            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }
}
