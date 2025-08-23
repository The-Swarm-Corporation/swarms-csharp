using Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public interface IClientService
{
    IRateService Rate { get; }
}
