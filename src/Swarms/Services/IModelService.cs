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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IModelServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IModelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IModelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/models/available`, but is otherwise the
    /// same as <see cref="IModelService.ListAvailable(ModelListAvailableParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModelListAvailableResponse>> ListAvailable(
        ModelListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
