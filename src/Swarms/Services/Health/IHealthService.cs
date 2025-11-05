using System;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Health;

namespace Swarms.Services.Health;

public interface IHealthService
{
    IHealthService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Health
    /// </summary>
    Task<HealthCheckResponse> Check(HealthCheckParams? parameters = null);
}
