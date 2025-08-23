using System.Threading.Tasks;
using Swarms.Models.Models;

namespace Swarms.Services.Models;

public interface IModelService
{
    /// <summary>
    /// Get all available models.
    /// </summary>
    Task<ModelListAvailableResponse> ListAvailable(ModelListAvailableParams? parameters = null);
}
