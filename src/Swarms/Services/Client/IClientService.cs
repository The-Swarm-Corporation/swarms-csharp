using System;
using Swarms.Core;
using Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public interface IClientService
{
    IClientService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateService Rate { get; }
}
