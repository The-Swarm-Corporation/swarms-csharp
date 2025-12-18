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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The execution time of the swarm.
    /// </summary>
    public required double? ExecutionTime
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "execution_time"); }
        init { JsonModel.Set(this._rawData, "execution_time", value); }
    }

    /// <summary>
    /// The unique identifier for the swarm completion.
    /// </summary>
    public required string? JobID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "job_id"); }
        init { JsonModel.Set(this._rawData, "job_id", value); }
    }

    /// <summary>
    /// The number of agents in the swarm.
    /// </summary>
    public required long? NumberOfAgents
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "number_of_agents"); }
        init { JsonModel.Set(this._rawData, "number_of_agents", value); }
    }

    /// <summary>
    /// The output of the swarm.
    /// </summary>
    public required JsonElement Output
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "output"); }
        init { JsonModel.Set(this._rawData, "output", value); }
    }

    /// <summary>
    /// The service tier of the swarm.
    /// </summary>
    public required string? ServiceTier
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "service_tier"); }
        init { JsonModel.Set(this._rawData, "service_tier", value); }
    }

    /// <summary>
    /// The status of the swarm completion.
    /// </summary>
    public required string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The name of the swarm.
    /// </summary>
    public required string? SwarmName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "swarm_name"); }
        init { JsonModel.Set(this._rawData, "swarm_name", value); }
    }

    /// <summary>
    /// The type of the swarm.
    /// </summary>
    public required string? SwarmType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "swarm_type"); }
        init { JsonModel.Set(this._rawData, "swarm_type", value); }
    }

    /// <summary>
    /// The usage of the swarm.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Usage
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "usage"
            );
        }
        init { JsonModel.Set(this._rawData, "usage", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SwarmRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
