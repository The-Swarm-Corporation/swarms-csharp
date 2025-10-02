using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientUnprocessableEntityException : SwarmsClient4xxException
{
    public SwarmsClientUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
