using Swarms.Models.Health;

namespace Swarms.Tests.Models.Health;

public class HealthCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HealthCheckResponse { Status = "status" };

        string expectedStatus = "status";

        Assert.Equal(expectedStatus, model.Status);
    }
}
