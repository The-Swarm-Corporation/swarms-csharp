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
        Assert.True(JsonElement.DeepEquals(expectedResults, model.Results));
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedTotalRequests, model.TotalRequests);
    }
}
