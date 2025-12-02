using Swarms.Models.Client.Rate;

namespace Swarms.Tests.Models.Client.Rate;

public class RateGetLimitsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateGetLimitsResponse
        {
            Limits = new()
            {
                MaximumRequestsPerDay = 0,
                MaximumRequestsPerHour = 0,
                MaximumRequestsPerMinute = 0,
                TokensPerAgent = 0,
            },
            RateLimits = new()
            {
                Day = new()
                {
                    Count = 0,
                    Exceeded = true,
                    Limit = 0,
                    Remaining = 0,
                    ResetTime = "reset_time",
                },
                Hour = new()
                {
                    Count = 0,
                    Exceeded = true,
                    Limit = 0,
                    Remaining = 0,
                    ResetTime = "reset_time",
                },
                Minute = new()
                {
                    Count = 0,
                    Exceeded = true,
                    Limit = 0,
                    Remaining = 0,
                    ResetTime = "reset_time",
                },
            },
            Tier = "tier",
            Timestamp = "timestamp",
            Success = true,
        };

        Limits expectedLimits = new()
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };
        RateLimits expectedRateLimits = new()
        {
            Day = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
            Hour = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
            Minute = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
        };
        string expectedTier = "tier";
        string expectedTimestamp = "timestamp";
        bool expectedSuccess = true;

        Assert.Equal(expectedLimits, model.Limits);
        Assert.Equal(expectedRateLimits, model.RateLimits);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedSuccess, model.Success);
    }
}

public class LimitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Limits
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };

        long expectedMaximumRequestsPerDay = 0;
        long expectedMaximumRequestsPerHour = 0;
        long expectedMaximumRequestsPerMinute = 0;
        long expectedTokensPerAgent = 0;

        Assert.Equal(expectedMaximumRequestsPerDay, model.MaximumRequestsPerDay);
        Assert.Equal(expectedMaximumRequestsPerHour, model.MaximumRequestsPerHour);
        Assert.Equal(expectedMaximumRequestsPerMinute, model.MaximumRequestsPerMinute);
        Assert.Equal(expectedTokensPerAgent, model.TokensPerAgent);
    }
}

public class RateLimitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateLimits
        {
            Day = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
            Hour = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
            Minute = new()
            {
                Count = 0,
                Exceeded = true,
                Limit = 0,
                Remaining = 0,
                ResetTime = "reset_time",
            },
        };

        Day expectedDay = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        Hour expectedHour = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        Minute expectedMinute = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        Assert.Equal(expectedDay, model.Day);
        Assert.Equal(expectedHour, model.Hour);
        Assert.Equal(expectedMinute, model.Minute);
    }
}

public class DayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Day
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
}

public class HourTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Hour
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
}

public class MinuteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Minute
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
}
