using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class HistoryTest : TestBase
{
    [Fact]
    public void JsonElementsValidation_Works()
    {
        History value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void stringsValidation_Works()
    {
        History value = new([new Dictionary<string, string>() { { "foo", "string" } }]);
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works()
    {
        History value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<History>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stringsSerializationRoundtrip_Works()
    {
        History value = new([new Dictionary<string, string>() { { "foo", "string" } }]);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<History>(json);

        Assert.Equal(value, deserialized);
    }
}
