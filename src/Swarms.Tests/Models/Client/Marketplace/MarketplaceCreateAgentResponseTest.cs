using System.Collections.Generic;
using System.Text.Json;
using Swarms.Core;
using Swarms.Models.Client.Marketplace;

namespace Swarms.Tests.Models.Client.Marketplace;

public class MarketplaceCreateAgentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        List<Prompt> expectedPrompts =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                UserID = "user_id",
                Category = "string",
                Description = "description",
                Links = new(
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ]
                ),
                Name = "name",
                PromptValue = "prompt",
                Status = "status",
                Tags = "tags",
                UseCases = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
            },
        ];
        long expectedTotalCount = 0;
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedPrompts.Count, model.Prompts.Count);
        for (int i = 0; i < expectedPrompts.Count; i++)
        {
            Assert.Equal(expectedPrompts[i], model.Prompts[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketplaceCreateAgentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MarketplaceCreateAgentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Prompt> expectedPrompts =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                UserID = "user_id",
                Category = "string",
                Description = "description",
                Links = new(
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ]
                ),
                Name = "name",
                PromptValue = "prompt",
                Status = "status",
                Tags = "tags",
                UseCases = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
            },
        ];
        long expectedTotalCount = 0;
        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedPrompts.Count, deserialized.Prompts.Count);
        for (int i = 0; i < expectedPrompts.Count; i++)
        {
            Assert.Equal(expectedPrompts[i], deserialized.Prompts[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
        };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,

            Status = null,
            Timestamp = null,
        };

        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.Timestamp);
        Assert.True(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,

            Status = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MarketplaceCreateAgentResponse
        {
            Prompts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    UserID = "user_id",
                    Category = "string",
                    Description = "description",
                    Links = new(
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ]
                    ),
                    Name = "name",
                    PromptValue = "prompt",
                    Status = "status",
                    Tags = "tags",
                    UseCases = new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    ),
                },
            ],
            TotalCount = 0,
            Status = "status",
            Timestamp = "timestamp",
        };

        MarketplaceCreateAgentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PromptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
            Category = "string",
            Description = "description",
            Links = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            PromptValue = "prompt",
            Status = "status",
            Tags = "tags",
            UseCases = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedUserID = "user_id";
        Category expectedCategory = "string";
        string expectedDescription = "description";
        Links expectedLinks = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string expectedName = "name";
        string expectedPromptValue = "prompt";
        string expectedStatus = "status";
        string expectedTags = "tags";
        UseCases expectedUseCases = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPromptValue, model.PromptValue);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedUseCases, model.UseCases);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
            Category = "string",
            Description = "description",
            Links = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            PromptValue = "prompt",
            Status = "status",
            Tags = "tags",
            UseCases = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Prompt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
            Category = "string",
            Description = "description",
            Links = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            PromptValue = "prompt",
            Status = "status",
            Tags = "tags",
            UseCases = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Prompt>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedUserID = "user_id";
        Category expectedCategory = "string";
        string expectedDescription = "description";
        Links expectedLinks = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string expectedName = "name";
        string expectedPromptValue = "prompt";
        string expectedStatus = "status";
        string expectedTags = "tags";
        UseCases expectedUseCases = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPromptValue, deserialized.PromptValue);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedUseCases, deserialized.UseCases);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
            Category = "string",
            Description = "description",
            Links = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            PromptValue = "prompt",
            Status = "status",
            Tags = "tags",
            UseCases = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
        };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Links);
        Assert.False(model.RawData.ContainsKey("links"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PromptValue);
        Assert.False(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UseCases);
        Assert.False(model.RawData.ContainsKey("use_cases"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",

            Category = null,
            Description = null,
            Links = null,
            Name = null,
            PromptValue = null,
            Status = null,
            Tags = null,
            UseCases = null,
        };

        Assert.Null(model.Category);
        Assert.True(model.RawData.ContainsKey("category"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Links);
        Assert.True(model.RawData.ContainsKey("links"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PromptValue);
        Assert.True(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.UseCases);
        Assert.True(model.RawData.ContainsKey("use_cases"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",

            Category = null,
            Description = null,
            Links = null,
            Name = null,
            PromptValue = null,
            Status = null,
            Tags = null,
            UseCases = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            CreatedAt = "created_at",
            UserID = "user_id",
            Category = "string",
            Description = "description",
            Links = new(
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ]
            ),
            Name = "name",
            PromptValue = "prompt",
            Status = "status",
            Tags = "tags",
            UseCases = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
        };

        Prompt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Category value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Category value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Category value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Category value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LinksTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        Links value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Links value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        Links value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Links>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Links value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Links>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UseCasesTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        UseCases value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        UseCases value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        UseCases value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCases>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        UseCases value = new(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCases>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
