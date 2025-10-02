using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Models;

namespace Swarms.Services.Models;

public sealed class ModelService : IModelService
{
    readonly ISwarmsClientClient _client;

    public ModelService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<ModelListAvailableResponse> ListAvailable(
        ModelListAvailableParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<ModelListAvailableParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ModelListAvailableResponse>().ConfigureAwait(false);
    }
}
