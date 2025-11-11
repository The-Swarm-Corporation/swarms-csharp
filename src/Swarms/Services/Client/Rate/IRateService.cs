using System;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client.Rate;

public interface IRateService
{
    IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the rate limits and current usage for the user associated with the provided
    /// API key.
    /// </summary>
    Task<RateGetLimitsResponse> GetLimits(
        RateGetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
