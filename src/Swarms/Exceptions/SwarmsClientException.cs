using System;
using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientException : Exception
{
    public SwarmsClientException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected SwarmsClientException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
