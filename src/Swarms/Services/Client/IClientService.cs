using Rate = Swarms.Services.Client.Rate;

namespace Swarms.Services.Client;

public interface IClientService
{
    Rate::IRateService Rate { get; }
}
