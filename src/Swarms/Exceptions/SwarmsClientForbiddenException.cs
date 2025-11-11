using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientForbiddenException : SwarmsClient4xxException
{
    public SwarmsClientForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
