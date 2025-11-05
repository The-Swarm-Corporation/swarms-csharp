using System;
using Swarms.Core;
using Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public sealed class ClientService : IClientService
{
    public IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClientService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public ClientService(ISwarmsClientClient client)
    {
        _client = client;
        _rate = new(() => new RateService(client));
    }

    readonly Lazy<IRateService> _rate;
    public IRateService Rate
    {
        get { return _rate.Value; }
    }
}
