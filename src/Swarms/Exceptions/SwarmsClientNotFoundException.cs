using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientNotFoundException : SwarmsClient4xxException
{
    public SwarmsClientNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
