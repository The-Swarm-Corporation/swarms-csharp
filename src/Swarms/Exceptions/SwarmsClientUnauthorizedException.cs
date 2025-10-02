using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientUnauthorizedException : SwarmsClient4xxException
{
    public SwarmsClientUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
