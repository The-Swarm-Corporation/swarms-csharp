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
using Swarms.Models.Agent;

namespace Swarms.Models.Client.GraphWorkflow;

/// <summary>
/// Execute a graph workflow with directed agent nodes and edges. Enables complex
/// multi-agent collaboration with parallel execution, automatic compilation, and
/// comprehensive workflow orchestration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GraphWorkflowExecuteWorkflowParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of agent specifications to be used as nodes in the workflow graph.
    /// </summary>
    public IReadOnlyList<AgentSpec>? Agents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AgentSpec>>("agents");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AgentSpec>?>(
                "agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to automatically compile the workflow for optimization.
    /// </summary>
    public bool? AutoCompile
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("auto_compile");
        }
        init { this._rawBodyData.Set("auto_compile", value); }
    }

    /// <summary>
    /// The description of the graph workflow.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// List of edges connecting nodes. Can be EdgeSpec objects or dictionaries with
    /// 'source' and 'target' keys.
    /// </summary>
    public IReadOnlyList<Edge>? Edges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Edge>>("edges");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Edge>?>(
                "edges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of node IDs that serve as ending points for the workflow.
    /// </summary>
    public IReadOnlyList<string>? EndPoints
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("end_points");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "end_points",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of node IDs that serve as starting points for the workflow.
    /// </summary>
    public IReadOnlyList<string>? EntryPoints
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("entry_points");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "entry_points",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional image path for vision-enabled agents.
    /// </summary>
    public string? Img
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("img");
        }
        init { this._rawBodyData.Set("img", value); }
    }

    /// <summary>
    /// The maximum number of execution loops for the workflow.
    /// </summary>
    public long? MaxLoops
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_loops");
        }
        init { this._rawBodyData.Set("max_loops", value); }
    }

    /// <summary>
    /// The name of the graph workflow.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The task to be executed by the workflow.
    /// </summary>
    public string? Task
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("task");
        }
        init { this._rawBodyData.Set("task", value); }
    }

    /// <summary>
    /// Whether to enable detailed logging.
    /// </summary>
    public bool? Verbose
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("verbose");
        }
        init { this._rawBodyData.Set("verbose", value); }
    }

    public GraphWorkflowExecuteWorkflowParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GraphWorkflowExecuteWorkflowParams(
        GraphWorkflowExecuteWorkflowParams graphWorkflowExecuteWorkflowParams
    )
        : base(graphWorkflowExecuteWorkflowParams)
    {
        this._rawBodyData = new(graphWorkflowExecuteWorkflowParams._rawBodyData);
    }
#pragma warning restore CS8618

    public GraphWorkflowExecuteWorkflowParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphWorkflowExecuteWorkflowParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static GraphWorkflowExecuteWorkflowParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(GraphWorkflowExecuteWorkflowParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/graph-workflow/completions"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Schema for defining an edge between nodes in the workflow graph.
/// </summary>
[JsonConverter(typeof(EdgeConverter))]
public record class Edge : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Edge(EdgeSpec value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Edge(IReadOnlyDictionary<string, JsonElement> value, JsonElement? element = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Edge(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EdgeSpec"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpec(out var value)) {
    ///     // `value` is of type `EdgeSpec`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpec([NotNullWhen(true)] out EdgeSpec? value)
    {
        value = this.Value as EdgeSpec;
        return value != null;
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
    ///     (EdgeSpec value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<EdgeSpec> spec,
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements
    )
    {
        switch (this.Value)
        {
            case EdgeSpec value:
                spec(value);
                break;
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            default:
                throw new SwarmsClientInvalidDataException(
                    "Data did not match any variant of Edge"
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
    ///     (EdgeSpec value) => {...},
    ///     (IReadOnlyDictionary<string, JsonElement> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<EdgeSpec, T> spec,
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements
    )
    {
        return this.Value switch
        {
            EdgeSpec value => spec(value),
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            _ => throw new SwarmsClientInvalidDataException(
                "Data did not match any variant of Edge"
            ),
        };
    }

    public static implicit operator Edge(EdgeSpec value) => new(value);

    public static implicit operator Edge(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

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
            throw new SwarmsClientInvalidDataException("Data did not match any variant of Edge");
        }
        this.Switch((spec) => spec.Validate(), (_) => { });
    }

    public virtual bool Equals(Edge? other)
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

sealed class EdgeConverter : JsonConverter<Edge>
{
    public override Edge? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<EdgeSpec>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is SwarmsClientInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Edge value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Schema for defining an edge between nodes in the workflow graph.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EdgeSpec, EdgeSpecFromRaw>))]
public sealed record class EdgeSpec : JsonModel
{
    /// <summary>
    /// The source node ID.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The target node ID.
    /// </summary>
    public required string Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Optional metadata for the edge.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Source;
        _ = this.Target;
        _ = this.Metadata;
    }

    public EdgeSpec() { }

    public EdgeSpec(EdgeSpec edgeSpec)
        : base(edgeSpec) { }

    public EdgeSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EdgeSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EdgeSpecFromRaw.FromRawUnchecked"/>
    public static EdgeSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EdgeSpecFromRaw : IFromRawJson<EdgeSpec>
{
    /// <inheritdoc/>
    public EdgeSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EdgeSpec.FromRawUnchecked(rawData);
}
