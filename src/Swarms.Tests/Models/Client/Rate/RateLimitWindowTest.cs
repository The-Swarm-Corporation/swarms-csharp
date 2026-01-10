using System.Text.Json;
using Swarms.Models.Client.Rate;

namespace Swarms.Tests.Models.Client.Rate;

public class RateLimitWindowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateLimitWindow
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        long expectedCount = 0;
        bool expectedExceeded = true;
        long expectedLimit = 0;
        long expectedRemaining = 0;
        string expectedResetTime = "reset_time";

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedExceeded, model.Exceeded);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedRemaining, model.Remaining);
        Assert.Equal(expectedResetTime, model.ResetTime);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RateLimitWindow
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RateLimitWindow>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateLimitWindow
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RateLimitWindow>(element);
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        bool expectedExceeded = true;
        long expectedLimit = 0;
        long expectedRemaining = 0;
        string expectedResetTime = "reset_time";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedExceeded, deserialized.Exceeded);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedRemaining, deserialized.Remaining);
        Assert.Equal(expectedResetTime, deserialized.ResetTime);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RateLimitWindow
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        model.Validate();
    }
}
