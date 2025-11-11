using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientBadRequestException : SwarmsClient4xxException
{
    public SwarmsClientBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
