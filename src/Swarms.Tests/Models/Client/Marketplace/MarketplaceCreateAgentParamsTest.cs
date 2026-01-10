using System;
using Swarms.Models.Client.Marketplace;

namespace Swarms.Tests.Models.Client.Marketplace;

public class MarketplaceCreateAgentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MarketplaceCreateAgentParams { NumberOfItems = 0 };

        long expectedNumberOfItems = 0;

        Assert.Equal(expectedNumberOfItems, parameters.NumberOfItems);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MarketplaceCreateAgentParams { };

        Assert.Null(parameters.NumberOfItems);
        Assert.False(parameters.RawBodyData.ContainsKey("number_of_items"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MarketplaceCreateAgentParams { NumberOfItems = null };

        Assert.Null(parameters.NumberOfItems);
        Assert.True(parameters.RawBodyData.ContainsKey("number_of_items"));
    }

    [Fact]
    public void Url_Works()
    {
        MarketplaceCreateAgentParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/marketplace/agents"), url);
    }
}
