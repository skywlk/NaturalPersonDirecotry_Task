using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Domain.Entities
{
    public class UnprocessedException : BaseEntity
    {
        protected UnprocessedException()
        {

        }

        public UnprocessedException(string exceptionType, string exceptionData, Guid uuid, int level)
        {
            ExceptionType = exceptionType;
            ExceptionData = exceptionData;
            ExceptionUuid = uuid;
        }

        public int Level { get; }
        public Guid ExceptionUuid { get; }
        public string ExceptionType { get; }
        public string ExceptionData { get; }

    }
}
