using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class AgentSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentSpec
        {
            AgentName = "agent_name",
            AutoGeneratePrompt = true,
            Description = "description",
            DynamicTemperatureEnabled = true,
            LlmArgs = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MaxLoops = 0,
            MaxTokens = 0,
            McpConfig = new()
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
                URL = "url",
            },
            McpConfigs = new(
                [
                    new()
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
                        URL = "url",
                    },
                ]
            ),
            McpURL = "mcp_url",
            ModelName = "model_name",
            ReasoningEffort = "reasoning_effort",
            ReasoningEnabled = true,
            Role = "role",
            StreamingOn = true,
            SystemPrompt = "system_prompt",
            Temperature = 0,
            ThinkingTokens = 0,
            ToolCallSummary = true,
            ToolsListDictionary =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string expectedAgentName = "agent_name";
        bool expectedAutoGeneratePrompt = true;
        string expectedDescription = "description";
        bool expectedDynamicTemperatureEnabled = true;
        Dictionary<string, JsonElement> expectedLlmArgs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedMaxLoops = 0;
        long expectedMaxTokens = 0;
        McpConfig expectedMcpConfig = new()
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
            URL = "url",
        };
        McpConfigs expectedMcpConfigs = new(
            [
                new()
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
                    URL = "url",
                },
            ]
        );
        string expectedMcpURL = "mcp_url";
        string expectedModelName = "model_name";
        string expectedReasoningEffort = "reasoning_effort";
        bool expectedReasoningEnabled = true;
        string expectedRole = "role";
        bool expectedStreamingOn = true;
        string expectedSystemPrompt = "system_prompt";
        double expectedTemperature = 0;
        long expectedThinkingTokens = 0;
        bool expectedToolCallSummary = true;
        List<Dictionary<string, JsonElement>> expectedToolsListDictionary =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedAutoGeneratePrompt, model.AutoGeneratePrompt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDynamicTemperatureEnabled, model.DynamicTemperatureEnabled);
        Assert.Equal(expectedLlmArgs.Count, model.LlmArgs.Count);
        foreach (var item in expectedLlmArgs)
        {
            Assert.True(model.LlmArgs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.LlmArgs[item.Key]));
        }
        Assert.Equal(expectedMaxLoops, model.MaxLoops);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMcpConfig, model.McpConfig);
        Assert.Equal(expectedMcpConfigs, model.McpConfigs);
        Assert.Equal(expectedMcpURL, model.McpURL);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedReasoningEffort, model.ReasoningEffort);
        Assert.Equal(expectedReasoningEnabled, model.ReasoningEnabled);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedStreamingOn, model.StreamingOn);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinkingTokens, model.ThinkingTokens);
        Assert.Equal(expectedToolCallSummary, model.ToolCallSummary);
        Assert.Equal(expectedToolsListDictionary.Count, model.ToolsListDictionary.Count);
        for (int i = 0; i < expectedToolsListDictionary.Count; i++)
        {
            Assert.Equal(expectedToolsListDictionary[i].Count, model.ToolsListDictionary[i].Count);
            foreach (var item in expectedToolsListDictionary[i])
            {
                Assert.True(model.ToolsListDictionary[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.ToolsListDictionary[i][item.Key]));
            }
        }
    }
}

public class McpConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpConfig
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
            URL = "url",
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
        string expectedURL = "url";

        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.Equal(expectedToolConfigurations.Count, model.ToolConfigurations.Count);
        foreach (var item in expectedToolConfigurations)
        {
            Assert.True(model.ToolConfigurations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ToolConfigurations[item.Key]));
        }
        Assert.Equal(expectedTransport, model.Transport);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
    }
}

public class McpConfigsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpConfigs
        {
            Connections =
            [
                new()
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
                    URL = "url",
                },
            ],
        };

        List<Connection> expectedConnections =
        [
            new()
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
                URL = "url",
            },
        ];

        Assert.Equal(expectedConnections.Count, model.Connections.Count);
        for (int i = 0; i < expectedConnections.Count; i++)
        {
            Assert.Equal(expectedConnections[i], model.Connections[i]);
        }
    }
}

public class ConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Connection
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
            URL = "url",
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
        string expectedURL = "url";

        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.Equal(expectedToolConfigurations.Count, model.ToolConfigurations.Count);
        foreach (var item in expectedToolConfigurations)
        {
            Assert.True(model.ToolConfigurations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ToolConfigurations[item.Key]));
        }
        Assert.Equal(expectedTransport, model.Transport);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
    }
}
