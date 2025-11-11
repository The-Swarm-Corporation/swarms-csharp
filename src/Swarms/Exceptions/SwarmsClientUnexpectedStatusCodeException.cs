using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientUnexpectedStatusCodeException : SwarmsClientApiException
{
    public SwarmsClientUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
