using System;
using Rate = Swarms.Services.Client.Rate;
using Swarms = Swarms;

namespace Swarms.Services.Client;

public sealed class ClientService : IClientService
{
    public ClientService(Swarms::ISwarmsClientClient client)
    {
        _rate = new(() => new Rate::RateService(client));
    }

    readonly Lazy<Rate::IRateService> _rate;
    public Rate::IRateService Rate
    {
        get { return _rate.Value; }
    }
}
