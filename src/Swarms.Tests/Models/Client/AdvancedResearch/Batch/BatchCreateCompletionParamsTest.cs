using System;
using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Client.AdvancedResearch.Batch;

namespace Swarms.Tests.Models.Client.AdvancedResearch.Batch;

public class BatchCreateCompletionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchCreateCompletionParams
        {
            InputSchemas =
            [
                new()
                {
                    Config = new()
                    {
                        Description = "description",
                        DirectorAgentName = "director_agent_name",
                        DirectorMaxLoops = 0,
                        DirectorMaxTokens = 0,
                        DirectorModelName = "director_model_name",
                        ExaSearchMaxCharacters = 0,
                        ExaSearchNumResults = 0,
                        MaxLoops = 0,
                        Name = "name",
                        WorkerModelName = "worker_model_name",
                    },
                    Task = "task",
                    Img = "img",
                },
            ],
        };

        List<InputSchema> expectedInputSchemas =
        [
            new()
            {
                Config = new()
                {
                    Description = "description",
                    DirectorAgentName = "director_agent_name",
                    DirectorMaxLoops = 0,
                    DirectorMaxTokens = 0,
                    DirectorModelName = "director_model_name",
                    ExaSearchMaxCharacters = 0,
                    ExaSearchNumResults = 0,
                    MaxLoops = 0,
                    Name = "name",
                    WorkerModelName = "worker_model_name",
                },
                Task = "task",
                Img = "img",
            },
        ];

        Assert.NotNull(parameters.InputSchemas);
        Assert.Equal(expectedInputSchemas.Count, parameters.InputSchemas.Count);
        for (int i = 0; i < expectedInputSchemas.Count; i++)
        {
            Assert.Equal(expectedInputSchemas[i], parameters.InputSchemas[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        BatchCreateCompletionParams parameters = new()
        {
            InputSchemas =
            [
                new()
                {
                    Config = new()
                    {
                        Description = "description",
                        DirectorAgentName = "director_agent_name",
                        DirectorMaxLoops = 0,
                        DirectorMaxTokens = 0,
                        DirectorModelName = "director_model_name",
                        ExaSearchMaxCharacters = 0,
                        ExaSearchNumResults = 0,
                        MaxLoops = 0,
                        Name = "name",
                        WorkerModelName = "worker_model_name",
                    },
                    Task = "task",
                    Img = "img",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.swarms.world/v1/advanced-research/batch/completions"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchCreateCompletionParams
        {
            InputSchemas =
            [
                new()
                {
                    Config = new()
                    {
                        Description = "description",
                        DirectorAgentName = "director_agent_name",
                        DirectorMaxLoops = 0,
                        DirectorMaxTokens = 0,
                        DirectorModelName = "director_model_name",
                        ExaSearchMaxCharacters = 0,
                        ExaSearchNumResults = 0,
                        MaxLoops = 0,
                        Name = "name",
                        WorkerModelName = "worker_model_name",
                    },
                    Task = "task",
                    Img = "img",
                },
            ],
        };

        BatchCreateCompletionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InputSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
            Img = "img",
        };

        Config expectedConfig = new()
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };
        string expectedTask = "task";
        string expectedImg = "img";

        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedTask, model.Task);
        Assert.Equal(expectedImg, model.Img);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
            Img = "img",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
            Img = "img",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Config expectedConfig = new()
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };
        string expectedTask = "task";
        string expectedImg = "img";

        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedTask, deserialized.Task);
        Assert.Equal(expectedImg, deserialized.Img);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
            Img = "img",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
        };

        Assert.Null(model.Img);
        Assert.False(model.RawData.ContainsKey("img"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",

            Img = null,
        };

        Assert.Null(model.Img);
        Assert.True(model.RawData.ContainsKey("img"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",

            Img = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InputSchema
        {
            Config = new()
            {
                Description = "description",
                DirectorAgentName = "director_agent_name",
                DirectorMaxLoops = 0,
                DirectorMaxTokens = 0,
                DirectorModelName = "director_model_name",
                ExaSearchMaxCharacters = 0,
                ExaSearchNumResults = 0,
                MaxLoops = 0,
                Name = "name",
                WorkerModelName = "worker_model_name",
            },
            Task = "task",
            Img = "img",
        };

        InputSchema copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };

        string expectedDescription = "description";
        string expectedDirectorAgentName = "director_agent_name";
        long expectedDirectorMaxLoops = 0;
        long expectedDirectorMaxTokens = 0;
        string expectedDirectorModelName = "director_model_name";
        long expectedExaSearchMaxCharacters = 0;
        long expectedExaSearchNumResults = 0;
        long expectedMaxLoops = 0;
        string expectedName = "name";
        string expectedWorkerModelName = "worker_model_name";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirectorAgentName, model.DirectorAgentName);
        Assert.Equal(expectedDirectorMaxLoops, model.DirectorMaxLoops);
        Assert.Equal(expectedDirectorMaxTokens, model.DirectorMaxTokens);
        Assert.Equal(expectedDirectorModelName, model.DirectorModelName);
        Assert.Equal(expectedExaSearchMaxCharacters, model.ExaSearchMaxCharacters);
        Assert.Equal(expectedExaSearchNumResults, model.ExaSearchNumResults);
        Assert.Equal(expectedMaxLoops, model.MaxLoops);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedWorkerModelName, model.WorkerModelName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Config
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Config
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedDirectorAgentName = "director_agent_name";
        long expectedDirectorMaxLoops = 0;
        long expectedDirectorMaxTokens = 0;
        string expectedDirectorModelName = "director_model_name";
        long expectedExaSearchMaxCharacters = 0;
        long expectedExaSearchNumResults = 0;
        long expectedMaxLoops = 0;
        string expectedName = "name";
        string expectedWorkerModelName = "worker_model_name";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDirectorAgentName, deserialized.DirectorAgentName);
        Assert.Equal(expectedDirectorMaxLoops, deserialized.DirectorMaxLoops);
        Assert.Equal(expectedDirectorMaxTokens, deserialized.DirectorMaxTokens);
        Assert.Equal(expectedDirectorModelName, deserialized.DirectorModelName);
        Assert.Equal(expectedExaSearchMaxCharacters, deserialized.ExaSearchMaxCharacters);
        Assert.Equal(expectedExaSearchNumResults, deserialized.ExaSearchNumResults);
        Assert.Equal(expectedMaxLoops, deserialized.MaxLoops);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedWorkerModelName, deserialized.WorkerModelName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Config
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Config { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DirectorAgentName);
        Assert.False(model.RawData.ContainsKey("director_agent_name"));
        Assert.Null(model.DirectorMaxLoops);
        Assert.False(model.RawData.ContainsKey("director_max_loops"));
        Assert.Null(model.DirectorMaxTokens);
        Assert.False(model.RawData.ContainsKey("director_max_tokens"));
        Assert.Null(model.DirectorModelName);
        Assert.False(model.RawData.ContainsKey("director_model_name"));
        Assert.Null(model.ExaSearchMaxCharacters);
        Assert.False(model.RawData.ContainsKey("exa_search_max_characters"));
        Assert.Null(model.ExaSearchNumResults);
        Assert.False(model.RawData.ContainsKey("exa_search_num_results"));
        Assert.Null(model.MaxLoops);
        Assert.False(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.WorkerModelName);
        Assert.False(model.RawData.ContainsKey("worker_model_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Config { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Config
        {
            Description = null,
            DirectorAgentName = null,
            DirectorMaxLoops = null,
            DirectorMaxTokens = null,
            DirectorModelName = null,
            ExaSearchMaxCharacters = null,
            ExaSearchNumResults = null,
            MaxLoops = null,
            Name = null,
            WorkerModelName = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DirectorAgentName);
        Assert.True(model.RawData.ContainsKey("director_agent_name"));
        Assert.Null(model.DirectorMaxLoops);
        Assert.True(model.RawData.ContainsKey("director_max_loops"));
        Assert.Null(model.DirectorMaxTokens);
        Assert.True(model.RawData.ContainsKey("director_max_tokens"));
        Assert.Null(model.DirectorModelName);
        Assert.True(model.RawData.ContainsKey("director_model_name"));
        Assert.Null(model.ExaSearchMaxCharacters);
        Assert.True(model.RawData.ContainsKey("exa_search_max_characters"));
        Assert.Null(model.ExaSearchNumResults);
        Assert.True(model.RawData.ContainsKey("exa_search_num_results"));
        Assert.Null(model.MaxLoops);
        Assert.True(model.RawData.ContainsKey("max_loops"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.WorkerModelName);
        Assert.True(model.RawData.ContainsKey("worker_model_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Config
        {
            Description = null,
            DirectorAgentName = null,
            DirectorMaxLoops = null,
            DirectorMaxTokens = null,
            DirectorModelName = null,
            ExaSearchMaxCharacters = null,
            ExaSearchNumResults = null,
            MaxLoops = null,
            Name = null,
            WorkerModelName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Config
        {
            Description = "description",
            DirectorAgentName = "director_agent_name",
            DirectorMaxLoops = 0,
            DirectorMaxTokens = 0,
            DirectorModelName = "director_model_name",
            ExaSearchMaxCharacters = 0,
            ExaSearchNumResults = 0,
            MaxLoops = 0,
            Name = "name",
            WorkerModelName = "worker_model_name",
        };

        Config copied = new(model);

        Assert.Equal(model, copied);
    }
}
