using System.Text.Json;
using Swarms.Exceptions;
using Swarms.Models.Client.AutoSwarmBuilder;
using Swarms.Models.Swarms;
using ReasoningAgents = Swarms.Models.ReasoningAgents;

namespace Swarms.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, SwarmSpecSwarmType>(),
            new ApiEnumConverter<string, SwarmType>(),
            new ApiEnumConverter<string, ReasoningAgents::OutputType>(),
            new ApiEnumConverter<string, ReasoningAgents::SwarmType>(),
            new ApiEnumConverter<string, ExecutionType>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SwarmsClientInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
