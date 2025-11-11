using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.AutoSwarmBuilder;

/// <summary>
/// Schema for the Auto Swarm Builder API response.
///
/// <para>Attributes:     success (bool): Whether the swarm was built successfully.
///     job_id (Optional[str]): The job ID of the swarm.     outputs (Optional[dict]):
/// The outputs of the auto swarms builder.     type (Optional[str]): The type of
/// the swarm execution.     timestamp (Optional[str]): The timestamp of the swarm
/// execution.     usage (Optional[dict]): The usage statistics of the swarm execution.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<AutoSwarmBuilderCreateCompletionResponse>))]
public sealed record class AutoSwarmBuilderCreateCompletionResponse
    : ModelBase,
        IFromRaw<AutoSwarmBuilderCreateCompletionResponse>
{
    /// <summary>
    /// Whether the swarm was built successfully.
    /// </summary>
    public required bool Success
    {
        get
        {
            if (!this._properties.TryGetValue("success", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'success' cannot be null",
                    new ArgumentOutOfRangeException("success", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["success"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The job ID of the swarm.
    /// </summary>
    public string? JobID
    {
        get
        {
            if (!this._properties.TryGetValue("job_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["job_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The outputs of the auto swarms builder.
    /// </summary>
    public Dictionary<string, JsonElement>? Outputs
    {
        get
        {
            if (!this._properties.TryGetValue("outputs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["outputs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp of the swarm execution.
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

    /// <summary>
    /// The type of the swarm execution.
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The usage of the swarm execution.
    /// </summary>
    public Dictionary<string, JsonElement>? Usage
    {
        get
        {
            if (!this._properties.TryGetValue("usage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Success;
        _ = this.JobID;
        _ = this.Outputs;
        _ = this.Timestamp;
        _ = this.Type;
        _ = this.Usage;
    }

    public AutoSwarmBuilderCreateCompletionResponse() { }

    public AutoSwarmBuilderCreateCompletionResponse(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoSwarmBuilderCreateCompletionResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutoSwarmBuilderCreateCompletionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AutoSwarmBuilderCreateCompletionResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}
