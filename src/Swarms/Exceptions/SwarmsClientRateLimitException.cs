using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientRateLimitException : SwarmsClient4xxException
{
    public SwarmsClientRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
