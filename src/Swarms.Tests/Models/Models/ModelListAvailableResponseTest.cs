using System.Text.Json;
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

        Assert.True(JsonElement.DeepEquals(expectedModels, model.Models));
        Assert.Equal(expectedSuccess, model.Success);
    }
}
