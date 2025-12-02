using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Agent;

/// <summary>
/// Run an agent with the specified task. Supports streaming when stream=True.
/// </summary>
public sealed record class AgentRunParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The configuration of the agent to be completed.
    /// </summary>
    public AgentSpec? AgentConfig
    {
        get { return ModelBase.GetNullableClass<AgentSpec>(this.RawBodyData, "agent_config"); }
        init { ModelBase.Set(this._rawBodyData, "agent_config", value); }
    }

    /// <summary>
    /// The history of the agent's previous tasks and responses. Can be either a dictionary
    /// or a list of message objects.
    /// </summary>
    public History? History
    {
        get { return ModelBase.GetNullableClass<History>(this.RawBodyData, "history"); }
        init { ModelBase.Set(this._rawBodyData, "history", value); }
    }

    /// <summary>
    /// An optional image URL that may be associated with the agent's task or representation.
    /// </summary>
    public string? Img
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "img"); }
        init { ModelBase.Set(this._rawBodyData, "img", value); }
    }

    /// <summary>
    /// A list of image URLs that may be associated with the agent's task or representation.
    /// </summary>
    public IReadOnlyList<string>? Imgs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "imgs"); }
        init { ModelBase.Set(this._rawBodyData, "imgs", value); }
    }

    /// <summary>
    /// The task to be completed by the agent.
    /// </summary>
    public string? Task
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "task"); }
        init { ModelBase.Set(this._rawBodyData, "task", value); }
    }

    /// <summary>
    /// A list of tools that the agent should use to complete its task.
    /// </summary>
    public IReadOnlyList<string>? ToolsEnabled
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "tools_enabled"); }
        init { ModelBase.Set(this._rawBodyData, "tools_enabled", value); }
    }

    public AgentRunParams() { }

    public AgentRunParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentRunParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static AgentRunParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/agent/completions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// The history of the agent's previous tasks and responses. Can be either a dictionary
/// or a list of message objects.
/// </summary>
[JsonConverter(typeof(HistoryConverter))]
public record class History
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public History(IReadOnlyDictionary<string, JsonElement> value, JsonElement? json = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._json = json;
    }

    public History(IReadOnlyList<Dictionary<string, string>> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public History(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    public bool TryPickStrings(
        [NotNullWhen(true)] out IReadOnlyList<Dictionary<string, string>>? value
    )
    {
        value = this.Value as IReadOnlyList<Dictionary<string, string>>;
        return value != null;
    }

    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<Dictionary<string, string>>> strings
    )
    {
        switch (this.Value)
        {
            case Dictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case List<Dictionary<string, string>> value:
                strings(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of History"
                );
        }
    }

    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<Dictionary<string, string>>, T> strings
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<Dictionary<string, string>> value => strings(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of History"
            ),
        };
    }

    public static implicit operator History(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator History(List<Dictionary<string, string>> value) =>
        new((IReadOnlyList<Dictionary<string, string>>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new SwarmsClientInvalidDataException("Data did not match any variant of History");
        }
    }

    public virtual bool Equals(History? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class HistoryConverter : JsonConverter<History?>
{
    public override History? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, History? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
