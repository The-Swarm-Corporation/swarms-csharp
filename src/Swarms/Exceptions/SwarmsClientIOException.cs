using System;
using System.Net.Http;

namespace Swarms.Exceptions;

public class SwarmsClientIOException : SwarmsClientException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public SwarmsClientIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
