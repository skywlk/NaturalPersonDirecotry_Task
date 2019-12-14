using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Domain.Exceptions
{
    public class NPDDomainException : Exception
    {
        public NPDDomainException()
        {
        }

        public NPDDomainException(string message) : base(message)
        {
        }

        public NPDDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
