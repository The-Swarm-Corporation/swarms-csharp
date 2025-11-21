using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(ModelConverter<SwarmRunResponse>))]
public sealed record class SwarmRunResponse : ModelBase, IFromRaw<SwarmRunResponse>
{
    /// <summary>
    /// The description of the swarm.
    /// </summary>
    public required string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The execution time of the swarm.
    /// </summary>
    public required double? ExecutionTime
    {
        get
        {
            if (!this._rawData.TryGetValue("execution_time", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["execution_time"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier for the swarm completion.
    /// </summary>
    public required string? JobID
    {
        get
        {
            if (!this._rawData.TryGetValue("job_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["job_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of agents in the swarm.
    /// </summary>
    public required long? NumberOfAgents
    {
        get
        {
            if (!this._rawData.TryGetValue("number_of_agents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["number_of_agents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The output of the swarm.
    /// </summary>
    public required JsonElement Output
    {
        get
        {
            if (!this._rawData.TryGetValue("output", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'output' cannot be null",
                    new ArgumentOutOfRangeException("output", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["output"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The service tier of the swarm.
    /// </summary>
    public required string? ServiceTier
    {
        get
        {
            if (!this._rawData.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["service_tier"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The status of the swarm completion.
    /// </summary>
    public required string? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the swarm.
    /// </summary>
    public required string? SwarmName
    {
        get
        {
            if (!this._rawData.TryGetValue("swarm_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["swarm_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of the swarm.
    /// </summary>
    public required string? SwarmType
    {
        get
        {
            if (!this._rawData.TryGetValue("swarm_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["swarm_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The usage of the swarm.
    /// </summary>
    public required Dictionary<string, JsonElement>? Usage
    {
        get
        {
            if (!this._rawData.TryGetValue("usage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Description;
        _ = this.ExecutionTime;
        _ = this.JobID;
        _ = this.NumberOfAgents;
        _ = this.Output;
        _ = this.ServiceTier;
        _ = this.Status;
        _ = this.SwarmName;
        _ = this.SwarmType;
        _ = this.Usage;
    }

    public SwarmRunResponse() { }

    public SwarmRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SwarmRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
