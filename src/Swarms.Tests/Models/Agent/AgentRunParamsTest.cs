using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Models.Agent;

namespace Swarms.Tests.Models.Agent;

public class AgentRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentRunParams
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
        History expectedHistory = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedImg = "img";
        List<string> expectedImgs = ["string"];
        string expectedTask = "task";
        List<string> expectedToolsEnabled = ["string"];

        Assert.Equal(expectedAgentConfig, parameters.AgentConfig);
        Assert.Equal(expectedHistory, parameters.History);
        Assert.Equal(expectedImg, parameters.Img);
        Assert.NotNull(parameters.Imgs);
        Assert.Equal(expectedImgs.Count, parameters.Imgs.Count);
        for (int i = 0; i < expectedImgs.Count; i++)
        {
            Assert.Equal(expectedImgs[i], parameters.Imgs[i]);
        }
        Assert.Equal(expectedTask, parameters.Task);
        Assert.NotNull(parameters.ToolsEnabled);
        Assert.Equal(expectedToolsEnabled.Count, parameters.ToolsEnabled.Count);
        for (int i = 0; i < expectedToolsEnabled.Count; i++)
        {
            Assert.Equal(expectedToolsEnabled[i], parameters.ToolsEnabled[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentRunParams { };

        Assert.Null(parameters.AgentConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_config"));
        Assert.Null(parameters.History);
        Assert.False(parameters.RawBodyData.ContainsKey("history"));
        Assert.Null(parameters.Img);
        Assert.False(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.Imgs);
        Assert.False(parameters.RawBodyData.ContainsKey("imgs"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.ToolsEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("tools_enabled"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentRunParams
        {
            AgentConfig = null,
            History = null,
            Img = null,
            Imgs = null,
            Task = null,
            ToolsEnabled = null,
        };

        Assert.Null(parameters.AgentConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("agent_config"));
        Assert.Null(parameters.History);
        Assert.True(parameters.RawBodyData.ContainsKey("history"));
        Assert.Null(parameters.Img);
        Assert.True(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.Imgs);
        Assert.True(parameters.RawBodyData.ContainsKey("imgs"));
        Assert.Null(parameters.Task);
        Assert.True(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.ToolsEnabled);
        Assert.True(parameters.RawBodyData.ContainsKey("tools_enabled"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentRunParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/agent/completions"), url);
    }
}

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
