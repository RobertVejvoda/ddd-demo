using System;
using System.Runtime.Serialization;

namespace Inf.Core.Exceptions
{
    [Serializable]
    public class DomainObjectNotFoundException : Exception
    {
        public DomainObjectNotFoundException()
        {
        }

        public DomainObjectNotFoundException(string message) : base(message)
        {
        }

        public DomainObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}