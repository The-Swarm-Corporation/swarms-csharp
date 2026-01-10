using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Tools;

namespace Swarms.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IToolService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IToolServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve comprehensive information about all available tools and capabilities
    /// supported by the Swarms API.
    /// </summary>
    Task<ToolListAvailableResponse> ListAvailable(
        ToolListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IToolService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IToolServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/tools/available`, but is otherwise the
    /// same as <see cref="IToolService.ListAvailable(ToolListAvailableParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolListAvailableResponse>> ListAvailable(
        ToolListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
