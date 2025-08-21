using System.Threading.Tasks;
using Swarms.Models.Health;

namespace Swarms.Services.Health;

public interface IHealthService
{
    /// <summary>
    /// Health
    /// </summary>
    Task<HealthCheckResponse> Check(HealthCheckParams? parameters = null);
}
