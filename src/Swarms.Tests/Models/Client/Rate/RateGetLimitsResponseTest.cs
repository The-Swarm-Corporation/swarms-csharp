using System.Text.Json;
using Swarms.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateGetLimitsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateGetLimitsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedLimits, deserialized.Limits);
        Assert.Equal(expectedRateLimits, deserialized.RateLimits);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            Success = null,
        };

        Assert.Null(model.Success);
        Assert.True(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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

        RateGetLimitsResponse copied = new(model);

        Assert.Equal(model, copied);
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Limits
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Limits>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Limits
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Limits>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedMaximumRequestsPerDay = 0;
        long expectedMaximumRequestsPerHour = 0;
        long expectedMaximumRequestsPerMinute = 0;
        long expectedTokensPerAgent = 0;

        Assert.Equal(expectedMaximumRequestsPerDay, deserialized.MaximumRequestsPerDay);
        Assert.Equal(expectedMaximumRequestsPerHour, deserialized.MaximumRequestsPerHour);
        Assert.Equal(expectedMaximumRequestsPerMinute, deserialized.MaximumRequestsPerMinute);
        Assert.Equal(expectedTokensPerAgent, deserialized.TokensPerAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Limits
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Limits
        {
            MaximumRequestsPerDay = 0,
            MaximumRequestsPerHour = 0,
            MaximumRequestsPerMinute = 0,
            TokensPerAgent = 0,
        };

        Limits copied = new(model);

        Assert.Equal(model, copied);
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

        RateLimitWindow expectedDay = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        RateLimitWindow expectedHour = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        RateLimitWindow expectedMinute = new()
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateLimits>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateLimits>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RateLimitWindow expectedDay = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        RateLimitWindow expectedHour = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };
        RateLimitWindow expectedMinute = new()
        {
            Count = 0,
            Exceeded = true,
            Limit = 0,
            Remaining = 0,
            ResetTime = "reset_time",
        };

        Assert.Equal(expectedDay, deserialized.Day);
        Assert.Equal(expectedHour, deserialized.Hour);
        Assert.Equal(expectedMinute, deserialized.Minute);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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

        RateLimits copied = new(model);

        Assert.Equal(model, copied);
    }
}
