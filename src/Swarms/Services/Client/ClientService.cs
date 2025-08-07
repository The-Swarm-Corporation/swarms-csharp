using System;
using Rate = Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public sealed class ClientService : IClientService
{
    public ClientService(ISwarmsClientClient client)
    {
        _rate = new(() => new Rate::RateService(client));
    }

    readonly Lazy<Rate::IRateService> _rate;
    public Rate::IRateService Rate
    {
        get { return _rate.Value; }
    }
}
