using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HealthCheckResponse { Status = "status" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HealthCheckResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HealthCheckResponse { Status = "status" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<HealthCheckResponse>(element);
        Assert.NotNull(deserialized);

        string expectedStatus = "status";

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HealthCheckResponse { Status = "status" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new HealthCheckResponse { };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new HealthCheckResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new HealthCheckResponse
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
        };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new HealthCheckResponse
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
        };

        model.Validate();
    }
}
