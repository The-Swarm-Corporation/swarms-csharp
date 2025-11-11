using System;

namespace Swarms.Exceptions;

public class SwarmsClientInvalidDataException : SwarmsClientException
{
    public SwarmsClientInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
