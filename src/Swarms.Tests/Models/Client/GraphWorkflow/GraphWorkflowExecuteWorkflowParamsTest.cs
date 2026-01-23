using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Agent;
using Swarms.Models.Client.GraphWorkflow;

namespace Swarms.Tests.Models.Client.GraphWorkflow;

public class GraphWorkflowExecuteWorkflowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GraphWorkflowExecuteWorkflowParams
        {
            Agents =
            [
                new()
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
            ],
            AutoCompile = true,
            Description = "description",
            Edges =
            [
                new EdgeSpec()
                {
                    Source = "source",
                    Target = "target",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            EndPoints = ["string"],
            EntryPoints = ["string"],
            Img = "img",
            MaxLoops = 0,
            Name = "name",
            Task = "task",
            Verbose = true,
        };

        List<AgentSpec> expectedAgents =
        [
            new()
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
        ];
        bool expectedAutoCompile = true;
        string expectedDescription = "description";
        List<Edge> expectedEdges =
        [
            new EdgeSpec()
            {
                Source = "source",
                Target = "target",
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        ];
        List<string> expectedEndPoints = ["string"];
        List<string> expectedEntryPoints = ["string"];
        string expectedImg = "img";
        long expectedMaxLoops = 0;
        string expectedName = "name";
        string expectedTask = "task";
        bool expectedVerbose = true;

        Assert.NotNull(parameters.Agents);
        Assert.Equal(expectedAgents.Count, parameters.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], parameters.Agents[i]);
        }
        Assert.Equal(expectedAutoCompile, parameters.AutoCompile);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Edges);
        Assert.Equal(expectedEdges.Count, parameters.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i], parameters.Edges[i]);
        }
        Assert.NotNull(parameters.EndPoints);
        Assert.Equal(expectedEndPoints.Count, parameters.EndPoints.Count);
        for (int i = 0; i < expectedEndPoints.Count; i++)
        {
            Assert.Equal(expectedEndPoints[i], parameters.EndPoints[i]);
        }
        Assert.NotNull(parameters.EntryPoints);
        Assert.Equal(expectedEntryPoints.Count, parameters.EntryPoints.Count);
        for (int i = 0; i < expectedEntryPoints.Count; i++)
        {
            Assert.Equal(expectedEntryPoints[i], parameters.EntryPoints[i]);
        }
        Assert.Equal(expectedImg, parameters.Img);
        Assert.Equal(expectedMaxLoops, parameters.MaxLoops);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedTask, parameters.Task);
        Assert.Equal(expectedVerbose, parameters.Verbose);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GraphWorkflowExecuteWorkflowParams { };

        Assert.Null(parameters.Agents);
        Assert.False(parameters.RawBodyData.ContainsKey("agents"));
        Assert.Null(parameters.AutoCompile);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_compile"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.EndPoints);
        Assert.False(parameters.RawBodyData.ContainsKey("end_points"));
        Assert.Null(parameters.EntryPoints);
        Assert.False(parameters.RawBodyData.ContainsKey("entry_points"));
        Assert.Null(parameters.Img);
        Assert.False(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.MaxLoops);
        Assert.False(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Task);
        Assert.False(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.Verbose);
        Assert.False(parameters.RawBodyData.ContainsKey("verbose"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GraphWorkflowExecuteWorkflowParams
        {
            Agents = null,
            AutoCompile = null,
            Description = null,
            Edges = null,
            EndPoints = null,
            EntryPoints = null,
            Img = null,
            MaxLoops = null,
            Name = null,
            Task = null,
            Verbose = null,
        };

        Assert.Null(parameters.Agents);
        Assert.True(parameters.RawBodyData.ContainsKey("agents"));
        Assert.Null(parameters.AutoCompile);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_compile"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.True(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.EndPoints);
        Assert.True(parameters.RawBodyData.ContainsKey("end_points"));
        Assert.Null(parameters.EntryPoints);
        Assert.True(parameters.RawBodyData.ContainsKey("entry_points"));
        Assert.Null(parameters.Img);
        Assert.True(parameters.RawBodyData.ContainsKey("img"));
        Assert.Null(parameters.MaxLoops);
        Assert.True(parameters.RawBodyData.ContainsKey("max_loops"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Task);
        Assert.True(parameters.RawBodyData.ContainsKey("task"));
        Assert.Null(parameters.Verbose);
        Assert.True(parameters.RawBodyData.ContainsKey("verbose"));
    }

    [Fact]
    public void Url_Works()
    {
        GraphWorkflowExecuteWorkflowParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.swarms.world/v1/graph-workflow/completions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GraphWorkflowExecuteWorkflowParams
        {
            Agents =
            [
                new()
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
            ],
            AutoCompile = true,
            Description = "description",
            Edges =
            [
                new EdgeSpec()
                {
                    Source = "source",
                    Target = "target",
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            EndPoints = ["string"],
            EntryPoints = ["string"],
            Img = "img",
            MaxLoops = 0,
            Name = "name",
            Task = "task",
            Verbose = true,
        };

        GraphWorkflowExecuteWorkflowParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EdgeTest : TestBase
{
    [Fact]
    public void SpecValidationWorks()
    {
        Edge value = new EdgeSpec()
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        Edge value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void SpecSerializationRoundtripWorks()
    {
        Edge value = new EdgeSpec()
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edge>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        Edge value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edge>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EdgeSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedSource = "source";
        string expectedTarget = "target";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTarget, model.Target);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EdgeSpec>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EdgeSpec>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSource = "source";
        string expectedTarget = "target";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EdgeSpec { Source = "source", Target = "target" };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EdgeSpec { Source = "source", Target = "target" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",

            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",

            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EdgeSpec
        {
            Source = "source",
            Target = "target",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        EdgeSpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
