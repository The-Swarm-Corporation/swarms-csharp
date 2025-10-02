using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client.Rate;

public sealed class RateService : IRateService
{
    readonly ISwarmsClientClient _client;

    public RateService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<RateGetLimitsResponse> GetLimits(RateGetLimitsParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<RateGetLimitsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<RateGetLimitsResponse>().ConfigureAwait(false);
    }
}
