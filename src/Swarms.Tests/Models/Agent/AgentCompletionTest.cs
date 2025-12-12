using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class AgentCompletionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = new()
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
            },
            History = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Img = "img",
            Imgs = ["string"],
            Task = "task",
            ToolsEnabled = ["string"],
        };

        AgentSpec expectedAgentConfig = new()
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
        AgentCompletionHistory expectedHistory = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedImg = "img";
        List<string> expectedImgs = ["string"];
        string expectedTask = "task";
        List<string> expectedToolsEnabled = ["string"];

        Assert.Equal(expectedAgentConfig, model.AgentConfig);
        Assert.Equal(expectedHistory, model.History);
        Assert.Equal(expectedImg, model.Img);
        Assert.NotNull(model.Imgs);
        Assert.Equal(expectedImgs.Count, model.Imgs.Count);
        for (int i = 0; i < expectedImgs.Count; i++)
        {
            Assert.Equal(expectedImgs[i], model.Imgs[i]);
        }
        Assert.Equal(expectedTask, model.Task);
        Assert.NotNull(model.ToolsEnabled);
        Assert.Equal(expectedToolsEnabled.Count, model.ToolsEnabled.Count);
        for (int i = 0; i < expectedToolsEnabled.Count; i++)
        {
            Assert.Equal(expectedToolsEnabled[i], model.ToolsEnabled[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = new()
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
            },
            History = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Img = "img",
            Imgs = ["string"],
            Task = "task",
            ToolsEnabled = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentCompletion>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = new()
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
            },
            History = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Img = "img",
            Imgs = ["string"],
            Task = "task",
            ToolsEnabled = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AgentCompletion>(json);
        Assert.NotNull(deserialized);

        AgentSpec expectedAgentConfig = new()
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
        AgentCompletionHistory expectedHistory = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedImg = "img";
        List<string> expectedImgs = ["string"];
        string expectedTask = "task";
        List<string> expectedToolsEnabled = ["string"];

        Assert.Equal(expectedAgentConfig, deserialized.AgentConfig);
        Assert.Equal(expectedHistory, deserialized.History);
        Assert.Equal(expectedImg, deserialized.Img);
        Assert.NotNull(deserialized.Imgs);
        Assert.Equal(expectedImgs.Count, deserialized.Imgs.Count);
        for (int i = 0; i < expectedImgs.Count; i++)
        {
            Assert.Equal(expectedImgs[i], deserialized.Imgs[i]);
        }
        Assert.Equal(expectedTask, deserialized.Task);
        Assert.NotNull(deserialized.ToolsEnabled);
        Assert.Equal(expectedToolsEnabled.Count, deserialized.ToolsEnabled.Count);
        for (int i = 0; i < expectedToolsEnabled.Count; i++)
        {
            Assert.Equal(expectedToolsEnabled[i], deserialized.ToolsEnabled[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = new()
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
            },
            History = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Img = "img",
            Imgs = ["string"],
            Task = "task",
            ToolsEnabled = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentCompletion { };

        Assert.Null(model.AgentConfig);
        Assert.False(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.History);
        Assert.False(model.RawData.ContainsKey("history"));
        Assert.Null(model.Img);
        Assert.False(model.RawData.ContainsKey("img"));
        Assert.Null(model.Imgs);
        Assert.False(model.RawData.ContainsKey("imgs"));
        Assert.Null(model.Task);
        Assert.False(model.RawData.ContainsKey("task"));
        Assert.Null(model.ToolsEnabled);
        Assert.False(model.RawData.ContainsKey("tools_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentCompletion { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = null,
            History = null,
            Img = null,
            Imgs = null,
            Task = null,
            ToolsEnabled = null,
        };

        Assert.Null(model.AgentConfig);
        Assert.True(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.History);
        Assert.True(model.RawData.ContainsKey("history"));
        Assert.Null(model.Img);
        Assert.True(model.RawData.ContainsKey("img"));
        Assert.Null(model.Imgs);
        Assert.True(model.RawData.ContainsKey("imgs"));
        Assert.Null(model.Task);
        Assert.True(model.RawData.ContainsKey("task"));
        Assert.Null(model.ToolsEnabled);
        Assert.True(model.RawData.ContainsKey("tools_enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentCompletion
        {
            AgentConfig = null,
            History = null,
            Img = null,
            Imgs = null,
            Task = null,
            ToolsEnabled = null,
        };

        model.Validate();
    }
}

public class AgentCompletionHistoryTest : TestBase
{
    [Fact]
    public void JsonElementsValidation_Works()
    {
        AgentCompletionHistory value = new(
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
        AgentCompletionHistory value = new(
            [new Dictionary<string, string>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtrip_Works()
    {
        AgentCompletionHistory value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<AgentCompletionHistory>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stringsSerializationRoundtrip_Works()
    {
        AgentCompletionHistory value = new(
            [new Dictionary<string, string>() { { "foo", "string" } }]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<AgentCompletionHistory>(json);

        Assert.Equal(value, deserialized);
    }
}
