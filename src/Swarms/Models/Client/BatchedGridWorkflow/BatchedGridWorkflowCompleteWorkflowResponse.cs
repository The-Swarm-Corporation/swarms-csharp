using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swarms.Core;
using Swarms.Exceptions;

namespace Swarms.Models.Client.BatchedGridWorkflow;

[JsonConverter(typeof(ModelConverter<BatchedGridWorkflowCompleteWorkflowResponse>))]
public sealed record class BatchedGridWorkflowCompleteWorkflowResponse
    : ModelBase,
        IFromRaw<BatchedGridWorkflowCompleteWorkflowResponse>
{
    /// <summary>
    /// The description of the batched grid workflow.
    /// </summary>
    public required string Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentOutOfRangeException("description", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentNullException("description")
                );
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
    /// The job ID of the batched grid workflow.
    /// </summary>
    public required string JobID
    {
        get
        {
            if (!this._properties.TryGetValue("job_id", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'job_id' cannot be null",
                    new ArgumentOutOfRangeException("job_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'job_id' cannot be null",
                    new ArgumentNullException("job_id")
                );
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
    /// The name of the batched grid workflow.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
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
    /// The outputs of the batched grid workflow.
    /// </summary>
    public required JsonElement Outputs
    {
        get
        {
            if (!this._properties.TryGetValue("outputs", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'outputs' cannot be null",
                    new ArgumentOutOfRangeException("outputs", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
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
    /// The status of the batched grid workflow.
    /// </summary>
    public required string Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentNullException("status")
                );
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
    /// The timestamp of the batched grid workflow.
    /// </summary>
    public required string Timestamp
    {
        get
        {
            if (!this._properties.TryGetValue("timestamp", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'timestamp' cannot be null",
                    new ArgumentOutOfRangeException("timestamp", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'timestamp' cannot be null",
                    new ArgumentNullException("timestamp")
                );
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
    /// The usage of the batched grid workflow.
    /// </summary>
    public required Usage Usage
    {
        get
        {
            if (!this._properties.TryGetValue("usage", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'usage' cannot be null",
                    new ArgumentOutOfRangeException("usage", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions)
                ?? throw new SwarmsClientInvalidDataException(
                    "'usage' cannot be null",
                    new ArgumentNullException("usage")
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
        _ = this.Description;
        _ = this.JobID;
        _ = this.Name;
        _ = this.Outputs;
        _ = this.Status;
        _ = this.Timestamp;
        this.Usage.Validate();
    }

    public BatchedGridWorkflowCompleteWorkflowResponse() { }

    public BatchedGridWorkflowCompleteWorkflowResponse(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchedGridWorkflowCompleteWorkflowResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BatchedGridWorkflowCompleteWorkflowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The usage of the batched grid workflow.
/// </summary>
[JsonConverter(typeof(ModelConverter<Usage>))]
public sealed record class Usage : ModelBase, IFromRaw<Usage>
{
    /// <summary>
    /// The cost in credits for the agents.
    /// </summary>
    public required double CostPerAgent
    {
        get
        {
            if (!this._properties.TryGetValue("cost_per_agent", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'cost_per_agent' cannot be null",
                    new ArgumentOutOfRangeException("cost_per_agent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cost_per_agent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("input_tokens", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'input_tokens' cannot be null",
                    new ArgumentOutOfRangeException("input_tokens", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of output tokens.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("output_tokens", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'output_tokens' cannot be null",
                    new ArgumentOutOfRangeException("output_tokens", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["output_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cost in credits for the tokens.
    /// </summary>
    public required double TokenCost
    {
        get
        {
            if (!this._properties.TryGetValue("token_cost", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'token_cost' cannot be null",
                    new ArgumentOutOfRangeException("token_cost", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["token_cost"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total number of tokens.
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            if (!this._properties.TryGetValue("total_tokens", out JsonElement element))
                throw new SwarmsClientInvalidDataException(
                    "'total_tokens' cannot be null",
                    new ArgumentOutOfRangeException("total_tokens", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["total_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CostPerAgent;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.TokenCost;
        _ = this.TotalTokens;
    }

    public Usage() { }

    public Usage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
