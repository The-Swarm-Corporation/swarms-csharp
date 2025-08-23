using System;
using Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public sealed class ClientService : IClientService
{
    public ClientService(ISwarmsClientClient client)
    {
        _rate = new(() => new RateService(client));
    }

    readonly Lazy<IRateService> _rate;
    public IRateService Rate
    {
        get { return _rate.Value; }
    }
}
