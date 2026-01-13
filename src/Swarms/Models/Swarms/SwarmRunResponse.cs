using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;

namespace Swarms.Models.Swarms;

[JsonConverter(typeof(JsonModelConverter<SwarmRunResponse, SwarmRunResponseFromRaw>))]
public sealed record class SwarmRunResponse : JsonModel
{
    /// <summary>
    /// The description of the swarm.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The execution time of the swarm.
    /// </summary>
    public required double? ExecutionTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("execution_time");
        }
        init { this._rawData.Set("execution_time", value); }
    }

    /// <summary>
    /// The unique identifier for the swarm completion.
    /// </summary>
    public required string? JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// The number of agents in the swarm.
    /// </summary>
    public required long? NumberOfAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("number_of_agents");
        }
        init { this._rawData.Set("number_of_agents", value); }
    }

    /// <summary>
    /// The output of the swarm.
    /// </summary>
    public required JsonElement Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("output");
        }
        init { this._rawData.Set("output", value); }
    }

    /// <summary>
    /// The service tier of the swarm.
    /// </summary>
    public required string? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_tier");
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// The status of the swarm completion.
    /// </summary>
    public required string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The name of the swarm.
    /// </summary>
    public required string? SwarmName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("swarm_name");
        }
        init { this._rawData.Set("swarm_name", value); }
    }

    /// <summary>
    /// The type of the swarm.
    /// </summary>
    public required string? SwarmType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("swarm_type");
        }
        init { this._rawData.Set("swarm_type", value); }
    }

    /// <summary>
    /// The usage of the swarm.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("usage");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "usage",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
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

    public SwarmRunResponse(SwarmRunResponse swarmRunResponse)
        : base(swarmRunResponse) { }

    public SwarmRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SwarmRunResponseFromRaw.FromRawUnchecked"/>
    public static SwarmRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SwarmRunResponseFromRaw : IFromRawJson<SwarmRunResponse>
{
    /// <inheritdoc/>
    public SwarmRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SwarmRunResponse.FromRawUnchecked(rawData);
}
