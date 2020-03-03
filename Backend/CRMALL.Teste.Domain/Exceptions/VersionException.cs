using System;
using System.Runtime.Serialization;

namespace CRMALL.Teste.Domain.Exceptions
{
    public class VersionException : Exception
    {
        public VersionException()
        {
        }

        public VersionException(string message) : base(message)
        {
        }

        public VersionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
