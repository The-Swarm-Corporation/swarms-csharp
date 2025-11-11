using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClient5xxException : SwarmsClientApiException
{
    public SwarmsClient5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
