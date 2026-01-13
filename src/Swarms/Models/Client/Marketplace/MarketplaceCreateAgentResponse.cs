using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.Marketplace;

/// <summary>
/// Response schema for marketplace prompts endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MarketplaceCreateAgentResponse,
        MarketplaceCreateAgentResponseFromRaw
    >)
)]
public sealed record class MarketplaceCreateAgentResponse : JsonModel
{
    /// <summary>
    /// List of marketplace prompts
    /// </summary>
    public required IReadOnlyList<Prompt> Prompts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Prompt>>("prompts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Prompt>>(
                "prompts",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    /// <summary>
    /// The status of the marketplace prompts response.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The timestamp of the marketplace prompts response.
    /// </summary>
    public string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
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

    public MarketplaceCreateAgentResponse() { }

    public MarketplaceCreateAgentResponse(
        MarketplaceCreateAgentResponse marketplaceCreateAgentResponse
    )
        : base(marketplaceCreateAgentResponse) { }

    public MarketplaceCreateAgentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketplaceCreateAgentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarketplaceCreateAgentResponseFromRaw.FromRawUnchecked"/>
    public static MarketplaceCreateAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarketplaceCreateAgentResponseFromRaw : IFromRawJson<MarketplaceCreateAgentResponse>
{
    /// <inheritdoc/>
    public MarketplaceCreateAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MarketplaceCreateAgentResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for marketplace prompts from the swarms_cloud_prompts table.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Prompt, PromptFromRaw>))]
public sealed record class Prompt : JsonModel
{
    /// <summary>
    /// Unique identifier for the prompt
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp when the prompt was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// ID of the user who created the prompt
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Category name(s) - can be string or list
    /// </summary>
    public Category? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Category>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Description of the prompt
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Associated links - can be list of dicts or strings
    /// </summary>
    public Links? Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Links>("links");
        }
        init { this._rawData.Set("links", value); }
    }

    /// <summary>
    /// Name of the prompt
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The actual prompt text
    /// </summary>
    public string? PromptValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prompt");
        }
        init { this._rawData.Set("prompt", value); }
    }

    /// <summary>
    /// Status of the prompt
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Tags associated with the prompt
    /// </summary>
    public string? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tags");
        }
        init { this._rawData.Set("tags", value); }
    }

    /// <summary>
    /// Use cases - can be dict or list of dicts
    /// </summary>
    public UseCases? UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UseCases>("use_cases");
        }
        init { this._rawData.Set("use_cases", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UserID;
        this.Category?.Validate();
        _ = this.Description;
        this.Links?.Validate();
        _ = this.Name;
        _ = this.PromptValue;
        _ = this.Status;
        _ = this.Tags;
        this.UseCases?.Validate();
    }

    public Prompt() { }

    public Prompt(Prompt prompt)
        : base(prompt) { }

    public Prompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Prompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromptFromRaw.FromRawUnchecked"/>
    public static Prompt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PromptFromRaw : IFromRawJson<Prompt>
{
    /// <inheritdoc/>
    public Prompt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Prompt.FromRawUnchecked(rawData);
}

/// <summary>
/// Category name(s) - can be string or list
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public record class Category : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Category(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Category(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Category(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<string>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<string>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Category"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Category"
            );
        }
    }

    public virtual bool Equals(Category? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class CategoryConverter : JsonConverter<Category?>
{
    public override Category? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ImmutableArray<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Category? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Associated links - can be list of dicts or strings
/// </summary>
[JsonConverter(typeof(LinksConverter))]
public record class Links : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Links(
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public Links(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Links(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<string>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<string>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>> jsonElements,
        Action<IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Links"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>, T> jsonElements,
        Func<IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value => jsonElements(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Links"
            ),
        };
    }

    public static implicit operator Links(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>)value);

    public static implicit operator Links(List<string> value) => new((IReadOnlyList<string>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException("Data did not match any variant of Links");
        }
    }

    public virtual bool Equals(Links? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class LinksConverter : JsonConverter<Links?>
{
    public override Links? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ImmutableArray<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Links? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Use cases - can be dict or list of dicts
/// </summary>
[JsonConverter(typeof(UseCasesConverter))]
public record class UseCases : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public UseCases(IReadOnlyDictionary<string, JsonElement> value, JsonElement? element = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public UseCases(
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public UseCases(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyDictionary<string, JsonElement>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary<string, JsonElement>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...},
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements1(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of UseCases"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...},
    ///     (IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> value => jsonElements1(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of UseCases"
            ),
        };
    }

    public static implicit operator UseCases(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator UseCases(List<Dictionary<string, JsonElement>> value) =>
        new((IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of UseCases"
            );
        }
    }

    public virtual bool Equals(UseCases? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class UseCasesConverter : JsonConverter<UseCases?>
{
    public override UseCases? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<FrozenDictionary<string, JsonElement>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UseCases? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
