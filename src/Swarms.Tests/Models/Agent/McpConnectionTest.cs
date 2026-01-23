using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class McpConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = "authorization_token",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Timeout = 0,
            ToolConfigurations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Transport = "transport",
            Type = "type",
            Url = "url",
        };

        string expectedAuthorizationToken = "authorization_token";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        long expectedTimeout = 0;
        Dictionary<string, JsonElement> expectedToolConfigurations = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTransport = "transport";
        string expectedType = "type";
        string expectedUrl = "url";

        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.NotNull(model.ToolConfigurations);
        Assert.Equal(expectedToolConfigurations.Count, model.ToolConfigurations.Count);
        foreach (var item in expectedToolConfigurations)
        {
            Assert.True(model.ToolConfigurations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ToolConfigurations[item.Key]));
        }
        Assert.Equal(expectedTransport, model.Transport);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = "authorization_token",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Timeout = 0,
            ToolConfigurations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Transport = "transport",
            Type = "type",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpConnection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = "authorization_token",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Timeout = 0,
            ToolConfigurations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Transport = "transport",
            Type = "type",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpConnection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthorizationToken = "authorization_token";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        long expectedTimeout = 0;
        Dictionary<string, JsonElement> expectedToolConfigurations = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTransport = "transport";
        string expectedType = "type";
        string expectedUrl = "url";

        Assert.Equal(expectedAuthorizationToken, deserialized.AuthorizationToken);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.NotNull(deserialized.ToolConfigurations);
        Assert.Equal(expectedToolConfigurations.Count, deserialized.ToolConfigurations.Count);
        foreach (var item in expectedToolConfigurations)
        {
            Assert.True(deserialized.ToolConfigurations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ToolConfigurations[item.Key]));
        }
        Assert.Equal(expectedTransport, deserialized.Transport);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = "authorization_token",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Timeout = 0,
            ToolConfigurations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Transport = "transport",
            Type = "type",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpConnection { };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.ToolConfigurations);
        Assert.False(model.RawData.ContainsKey("tool_configurations"));
        Assert.Null(model.Transport);
        Assert.False(model.RawData.ContainsKey("transport"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpConnection { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = null,
            Headers = null,
            Timeout = null,
            ToolConfigurations = null,
            Transport = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.AuthorizationToken);
        Assert.True(model.RawData.ContainsKey("authorization_token"));
        Assert.Null(model.Headers);
        Assert.True(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Timeout);
        Assert.True(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.ToolConfigurations);
        Assert.True(model.RawData.ContainsKey("tool_configurations"));
        Assert.Null(model.Transport);
        Assert.True(model.RawData.ContainsKey("transport"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = null,
            Headers = null,
            Timeout = null,
            ToolConfigurations = null,
            Transport = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpConnection
        {
            AuthorizationToken = "authorization_token",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Timeout = 0,
            ToolConfigurations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Transport = "transport",
            Type = "type",
            Url = "url",
        };

        McpConnection copied = new(model);

        Assert.Equal(model, copied);
    }
}
