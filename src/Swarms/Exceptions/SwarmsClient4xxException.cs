using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClient4xxException : SwarmsClientApiException
{
    public SwarmsClient4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
