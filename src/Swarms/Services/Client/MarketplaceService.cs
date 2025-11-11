using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Marketplace;

namespace Swarms.Services.Client;

public sealed class MarketplaceService : IMarketplaceService
{
    public IMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketplaceService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public MarketplaceService(ISwarmsClientClient client)
    {
        _client = client;
    }

    public async Task<MarketplaceListAgentsResponse> ListAgents(
        MarketplaceListAgentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MarketplaceListAgentsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MarketplaceListAgentsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
