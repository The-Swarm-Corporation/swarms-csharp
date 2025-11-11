using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.Marketplace;

/// <summary>
/// Response schema for marketplace prompts endpoint.
/// </summary>
[JsonConverter(typeof(ModelConverter<MarketplaceListAgentsResponse>))]
public sealed record class MarketplaceListAgentsResponse
    : ModelBase,
        IFromRaw<MarketplaceListAgentsResponse>
{
    /// <summary>
    /// List of marketplace prompts
    /// </summary>
    public required List<Prompt> Prompts
    {
        get
        {
            if (!this._properties.TryGetValue("prompts", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'prompts' cannot be null",
                    new ArgumentOutOfRangeException("prompts", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Prompt>>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'prompts' cannot be null",
                    new ArgumentNullException("prompts")
                );
        }
        init
        {
            this._properties["prompts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total number of prompts available
    /// </summary>
    public required long TotalCount
    {
        get
        {
            if (!this._properties.TryGetValue("total_count", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'total_count' cannot be null",
                    new ArgumentOutOfRangeException("total_count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["total_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The status of the marketplace prompts response.
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of the marketplace prompts response.
    /// </summary>
    public string? Timestamp
    {
        get
        {
            if (!this._properties.TryGetValue("timestamp", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Prompts)
        {
            item.Validate();
        }
        _ = this.TotalCount;
        _ = this.Status;
        _ = this.Timestamp;
    }

    public MarketplaceListAgentsResponse() { }

    public MarketplaceListAgentsResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketplaceListAgentsResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MarketplaceListAgentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Schema for marketplace prompts from the swarms_cloud_prompts table.
/// </summary>
[JsonConverter(typeof(ModelConverter<Prompt>))]
public sealed record class Prompt : ModelBase, IFromRaw<Prompt>
{
    /// <summary>
    /// Unique identifier for the prompt
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the prompt was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentNullException("created_at")
                );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ID of the user who created the prompt
    /// </summary>
    public required string UserID
    {
        get
        {
            if (!this._properties.TryGetValue("user_id", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'user_id' cannot be null",
                    new ArgumentOutOfRangeException("user_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'user_id' cannot be null",
                    new ArgumentNullException("user_id")
                );
        }
        init
        {
            this._properties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Category name(s) - can be string or list
    /// </summary>
    public Category? Category
    {
        get
        {
            if (!this._properties.TryGetValue("category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Category?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Description of the prompt
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Associated links - can be list of dicts or strings
    /// </summary>
    public Links? Links
    {
        get
        {
            if (!this._properties.TryGetValue("links", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Links?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["links"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the prompt
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The actual prompt text
    /// </summary>
    public string? Prompt1
    {
        get
        {
            if (!this._properties.TryGetValue("prompt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["prompt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the prompt
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tags associated with the prompt
    /// </summary>
    public string? Tags
    {
        get
        {
            if (!this._properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Use cases - can be dict or list of dicts
    /// </summary>
    public UseCases? UseCases
    {
        get
        {
            if (!this._properties.TryGetValue("use_cases", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UseCases?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["use_cases"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UserID;
        this.Category?.Validate();
        _ = this.Description;
        this.Links?.Validate();
        _ = this.Name;
        _ = this.Prompt1;
        _ = this.Status;
        _ = this.Tags;
        this.UseCases?.Validate();
    }

    public Prompt() { }

    public Prompt(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Prompt(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Prompt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Category name(s) - can be string or list
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public record class Category
{
    public object Value { get; private init; }

    public Category(string value)
    {
        Value = value;
    }

    public Category(IReadOnlyList<string> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Category(UnknownVariant value)
    {
        Value = value;
    }

    public static Category CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Category"
                );
        }
    }

    public T Match<T>(Func<string, T> @string, Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Category"
            ),
        };
    }

    public static implicit operator Category(string value) => new(value);

    public static implicit operator Category(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Category"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class CategoryConverter : JsonConverter<Category?>
{
    public override Category? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Category(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'string'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new Category(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<string>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Category? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Associated links - can be list of dicts or strings
/// </summary>
[JsonConverter(typeof(LinksConverter))]
public record class Links
{
    public object Value { get; private init; }

    public Links(IReadOnlyList<Dictionary<string, JsonElement>> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public Links(IReadOnlyList<string> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Links(UnknownVariant value)
    {
        Value = value;
    }

    public static Links CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, JsonElement>>;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    public void Switch(
        Action<IReadOnlyList<Dictionary<string, JsonElement>>> jsonElements,
        Action<IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case List<Dictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Links"
                );
        }
    }

    public T Match<T>(
        Func<IReadOnlyList<Dictionary<string, JsonElement>>, T> jsonElements,
        Func<IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            IReadOnlyList<Dictionary<string, JsonElement>> value => jsonElements(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Links"
            ),
        };
    }

    public static implicit operator Links(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<Dictionary<string, JsonElement>>)value);

    public static implicit operator Links(List<string> value) => new((IReadOnlyList<string>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException("Data did not match any variant of Links");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class LinksConverter : JsonConverter<Links?>
{
    public override Links? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Links(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<Dictionary<string, JsonElement>>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new Links(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<string>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Links? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Use cases - can be dict or list of dicts
/// </summary>
[JsonConverter(typeof(UseCasesConverter))]
public record class UseCases
{
    public object Value { get; private init; }

    public UseCases(IReadOnlyDictionary<string, JsonElement> value)
    {
        Value = FrozenDictionary.ToFrozenDictionary(value);
    }

    public UseCases(IReadOnlyList<Dictionary<string, JsonElement>> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    UseCases(UnknownVariant value)
    {
        Value = value;
    }

    public static UseCases CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, JsonElement>>;
        return value != null;
    }

    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<Dictionary<string, JsonElement>>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case Dictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case List<Dictionary<string, JsonElement>> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of UseCases"
                );
        }
    }

    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<Dictionary<string, JsonElement>>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<Dictionary<string, JsonElement>> value => jsonElements1(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of UseCases"
            ),
        };
    }

    public static implicit operator UseCases(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator UseCases(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<Dictionary<string, JsonElement>>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of UseCases"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class UseCasesConverter : JsonConverter<UseCases?>
{
    public override UseCases? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<SwarmsClientInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UseCases(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'Dictionary<string, JsonElement>'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UseCases(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            exceptions.Add(
                new SwarmsClientInvalidDataException(
                    "Data does not match union variant 'List<Dictionary<string, JsonElement>>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UseCases? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
