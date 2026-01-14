using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Client.Tools;

namespace Swarms.Tests.Models.Client.Tools;

public class ToolListAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolListAvailableResponse { Status = "status", Tools = ["string"] };

        string expectedStatus = "status";
        List<string> expectedTools = ["string"];

        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolListAvailableResponse { Status = "status", Tools = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolListAvailableResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolListAvailableResponse { Status = "status", Tools = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolListAvailableResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStatus = "status";
        List<string> expectedTools = ["string"];

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolListAvailableResponse { Status = "status", Tools = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolListAvailableResponse { };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolListAvailableResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolListAvailableResponse { Status = null, Tools = null };

        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tools);
        Assert.True(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolListAvailableResponse { Status = null, Tools = null };

        model.Validate();
    }
}
