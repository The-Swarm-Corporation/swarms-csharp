using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Models;

namespace Swarms.Services;

public interface IModelService
{
    IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get all available models.
    /// </summary>
    Task<ModelListAvailableResponse> ListAvailable(
        ModelListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
