using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmCheckAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = true, SwarmTypes = ["string"] };

        bool expectedSuccess = true;
        List<string> expectedSwarmTypes = ["string"];

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedSwarmTypes.Count, model.SwarmTypes.Count);
        for (int i = 0; i < expectedSwarmTypes.Count; i++)
        {
            Assert.Equal(expectedSwarmTypes[i], model.SwarmTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = true, SwarmTypes = ["string"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmCheckAvailableResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = true, SwarmTypes = ["string"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SwarmCheckAvailableResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;
        List<string> expectedSwarmTypes = ["string"];

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedSwarmTypes.Count, deserialized.SwarmTypes.Count);
        for (int i = 0; i < expectedSwarmTypes.Count; i++)
        {
            Assert.Equal(expectedSwarmTypes[i], deserialized.SwarmTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = true, SwarmTypes = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SwarmCheckAvailableResponse { };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.SwarmTypes);
        Assert.False(model.RawData.ContainsKey("swarm_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SwarmCheckAvailableResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = null, SwarmTypes = null };

        Assert.Null(model.Success);
        Assert.True(model.RawData.ContainsKey("success"));
        Assert.Null(model.SwarmTypes);
        Assert.True(model.RawData.ContainsKey("swarm_types"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = null, SwarmTypes = null };

        model.Validate();
    }
}
