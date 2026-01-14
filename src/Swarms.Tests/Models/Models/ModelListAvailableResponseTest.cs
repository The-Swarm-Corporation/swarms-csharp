using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Models;

namespace Swarms.Tests.Models.Models;

public class ModelListAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
            Success = true,
        };

        JsonElement expectedModels = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedSuccess = true;

        Assert.NotNull(model.Models);
        Assert.True(JsonElement.DeepEquals(expectedModels, model.Models.Value));
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelListAvailableResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelListAvailableResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedModels = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedSuccess = true;

        Assert.NotNull(deserialized.Models);
        Assert.True(JsonElement.DeepEquals(expectedModels, deserialized.Models.Value));
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelListAvailableResponse { Success = true };

        Assert.Null(model.Models);
        Assert.False(model.RawData.ContainsKey("models"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelListAvailableResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Success = true,

            // Null should be interpreted as omitted for these properties
            Models = null,
        };

        Assert.Null(model.Models);
        Assert.False(model.RawData.ContainsKey("models"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Success = true,

            // Null should be interpreted as omitted for these properties
            Models = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),

            Success = null,
        };

        Assert.Null(model.Success);
        Assert.True(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelListAvailableResponse
        {
            Models = JsonSerializer.Deserialize<JsonElement>("{}"),

            Success = null,
        };

        model.Validate();
    }
}
