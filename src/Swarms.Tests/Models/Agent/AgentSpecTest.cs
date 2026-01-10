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
                Url = "url",
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
                        Url = "url",
                    },
                ]
            ),
            McpUrl = "mcp_url",
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
        McpConnection expectedMcpConfig = new()
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
                    Url = "url",
                },
            ]
        );
        string expectedMcpUrl = "mcp_url";
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
        Assert.NotNull(model.LlmArgs);
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
        Assert.Equal(expectedMcpUrl, model.McpUrl);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedReasoningEffort, model.ReasoningEffort);
        Assert.Equal(expectedReasoningEnabled, model.ReasoningEnabled);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedStreamingOn, model.StreamingOn);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinkingTokens, model.ThinkingTokens);
        Assert.Equal(expectedToolCallSummary, model.ToolCallSummary);
        Assert.NotNull(model.ToolsListDictionary);
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

    [Fact]
    public void SerializationRoundtrip_Works()
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
                Url = "url",
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
                        Url = "url",
                    },
                ]
            ),
            McpUrl = "mcp_url",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentSpec>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                Url = "url",
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
                        Url = "url",
                    },
                ]
            ),
            McpUrl = "mcp_url",
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentSpec>(element);
        Assert.NotNull(deserialized);

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
        McpConnection expectedMcpConfig = new()
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
                    Url = "url",
                },
            ]
        );
        string expectedMcpUrl = "mcp_url";
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

        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedAutoGeneratePrompt, deserialized.AutoGeneratePrompt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDynamicTemperatureEnabled, deserialized.DynamicTemperatureEnabled);
        Assert.NotNull(deserialized.LlmArgs);
        Assert.Equal(expectedLlmArgs.Count, deserialized.LlmArgs.Count);
        foreach (var item in expectedLlmArgs)
        {
            Assert.True(deserialized.LlmArgs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.LlmArgs[item.Key]));
        }
        Assert.Equal(expectedMaxLoops, deserialized.MaxLoops);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMcpConfig, deserialized.McpConfig);
        Assert.Equal(expectedMcpConfigs, deserialized.McpConfigs);
        Assert.Equal(expectedMcpUrl, deserialized.McpUrl);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedReasoningEffort, deserialized.ReasoningEffort);
        Assert.Equal(expectedReasoningEnabled, deserialized.ReasoningEnabled);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedStreamingOn, deserialized.StreamingOn);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedThinkingTokens, deserialized.ThinkingTokens);
        Assert.Equal(expectedToolCallSummary, deserialized.ToolCallSummary);
        Assert.NotNull(deserialized.ToolsListDictionary);
        Assert.Equal(expectedToolsListDictionary.Count, deserialized.ToolsListDictionary.Count);
        for (int i = 0; i < expectedToolsListDictionary.Count; i++)
        {
            Assert.Equal(
                expectedToolsListDictionary[i].Count,
                deserialized.ToolsListDictionary[i].Count
            );
            foreach (var item in expectedToolsListDictionary[i])
            {
                Assert.True(
                    deserialized.ToolsListDictionary[i].TryGetValue(item.Key, out var value)
                );

                Assert.True(
                    JsonElement.DeepEquals(value, deserialized.ToolsListDictionary[i][item.Key])
                );
            }
        }
    }

    [Fact]
    public void Validation_Works()
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
                Url = "url",
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
                        Url = "url",
                    },
                ]
            ),
            McpUrl = "mcp_url",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentSpec { AgentName = "agent_name" };

        Assert.Null(model.AutoGeneratePrompt);
        Assert.False(model.RawData.ContainsKey("auto_generate_prompt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DynamicTemperatureEnabled);
        Assert.False(model.RawData.ContainsKey("dynamic_temperature_enabled"));
        Assert.Null(model.LlmArgs);
        Assert.False(model.RawData.ContainsKey("llm_args"));
        Assert.Null(model.MaxLoops);
        Assert.False(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.MaxTokens);
        Assert.False(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.McpConfig);
        Assert.False(model.RawData.ContainsKey("mcp_config"));
        Assert.Null(model.McpConfigs);
        Assert.False(model.RawData.ContainsKey("mcp_configs"));
        Assert.Null(model.McpUrl);
        Assert.False(model.RawData.ContainsKey("mcp_url"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.ReasoningEffort);
        Assert.False(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ReasoningEnabled);
        Assert.False(model.RawData.ContainsKey("reasoning_enabled"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.StreamingOn);
        Assert.False(model.RawData.ContainsKey("streaming_on"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.ThinkingTokens);
        Assert.False(model.RawData.ContainsKey("thinking_tokens"));
        Assert.Null(model.ToolCallSummary);
        Assert.False(model.RawData.ContainsKey("tool_call_summary"));
        Assert.Null(model.ToolsListDictionary);
        Assert.False(model.RawData.ContainsKey("tools_list_dictionary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentSpec { AgentName = "agent_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentSpec
        {
            AgentName = "agent_name",

            AutoGeneratePrompt = null,
            Description = null,
            DynamicTemperatureEnabled = null,
            LlmArgs = null,
            MaxLoops = null,
            MaxTokens = null,
            McpConfig = null,
            McpConfigs = null,
            McpUrl = null,
            ModelName = null,
            ReasoningEffort = null,
            ReasoningEnabled = null,
            Role = null,
            StreamingOn = null,
            SystemPrompt = null,
            Temperature = null,
            ThinkingTokens = null,
            ToolCallSummary = null,
            ToolsListDictionary = null,
        };

        Assert.Null(model.AutoGeneratePrompt);
        Assert.True(model.RawData.ContainsKey("auto_generate_prompt"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DynamicTemperatureEnabled);
        Assert.True(model.RawData.ContainsKey("dynamic_temperature_enabled"));
        Assert.Null(model.LlmArgs);
        Assert.True(model.RawData.ContainsKey("llm_args"));
        Assert.Null(model.MaxLoops);
        Assert.True(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.MaxTokens);
        Assert.True(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.McpConfig);
        Assert.True(model.RawData.ContainsKey("mcp_config"));
        Assert.Null(model.McpConfigs);
        Assert.True(model.RawData.ContainsKey("mcp_configs"));
        Assert.Null(model.McpUrl);
        Assert.True(model.RawData.ContainsKey("mcp_url"));
        Assert.Null(model.ModelName);
        Assert.True(model.RawData.ContainsKey("model_name"));
        Assert.Null(model.ReasoningEffort);
        Assert.True(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ReasoningEnabled);
        Assert.True(model.RawData.ContainsKey("reasoning_enabled"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
        Assert.Null(model.StreamingOn);
        Assert.True(model.RawData.ContainsKey("streaming_on"));
        Assert.Null(model.SystemPrompt);
        Assert.True(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.ThinkingTokens);
        Assert.True(model.RawData.ContainsKey("thinking_tokens"));
        Assert.Null(model.ToolCallSummary);
        Assert.True(model.RawData.ContainsKey("tool_call_summary"));
        Assert.Null(model.ToolsListDictionary);
        Assert.True(model.RawData.ContainsKey("tools_list_dictionary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentSpec
        {
            AgentName = "agent_name",

            AutoGeneratePrompt = null,
            Description = null,
            DynamicTemperatureEnabled = null,
            LlmArgs = null,
            MaxLoops = null,
            MaxTokens = null,
            McpConfig = null,
            McpConfigs = null,
            McpUrl = null,
            ModelName = null,
            ReasoningEffort = null,
            ReasoningEnabled = null,
            Role = null,
            StreamingOn = null,
            SystemPrompt = null,
            Temperature = null,
            ThinkingTokens = null,
            ToolCallSummary = null,
            ToolsListDictionary = null,
        };

        model.Validate();
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
                    Url = "url",
                },
            ],
        };

        List<McpConnection> expectedConnections =
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
                Url = "url",
            },
        ];

        Assert.Equal(expectedConnections.Count, model.Connections.Count);
        for (int i = 0; i < expectedConnections.Count; i++)
        {
            Assert.Equal(expectedConnections[i], model.Connections[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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
                    Url = "url",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<McpConfigs>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                    Url = "url",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<McpConfigs>(element);
        Assert.NotNull(deserialized);

        List<McpConnection> expectedConnections =
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
                Url = "url",
            },
        ];

        Assert.Equal(expectedConnections.Count, deserialized.Connections.Count);
        for (int i = 0; i < expectedConnections.Count; i++)
        {
            Assert.Equal(expectedConnections[i], deserialized.Connections[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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
                    Url = "url",
                },
            ],
        };

        model.Validate();
    }
}
