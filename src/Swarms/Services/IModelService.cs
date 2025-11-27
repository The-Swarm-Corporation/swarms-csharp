using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Models;

namespace Swarms.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IModelService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get all available models.
    /// </summary>
    Task<ModelListAvailableResponse> ListAvailable(
        ModelListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
