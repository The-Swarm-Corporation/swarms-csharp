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
        Assert.True(JsonElement.DeepEquals(expectedLogs, model.Logs));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }
}
