using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class HistoryTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
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
    public void StringsValidationWorks()
    {
        History value = new([new Dictionary<string, string>() { { "foo", "string" } }]);
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        History value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<History>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        History value = new([new Dictionary<string, string>() { { "foo", "string" } }]);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<History>(element);

        Assert.Equal(value, deserialized);
    }
}
