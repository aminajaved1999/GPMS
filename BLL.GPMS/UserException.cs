using System;
using System.Runtime.Serialization;

namespace BLL.GPMS
{
    [Serializable]
    internal class UserException : Exception
    {
        private object p;

        public UserException()
        {
        }

        public UserException(object p)
        {
            this.p = p;
        }

        public UserException(string message) : base(message)
        {
        }

        public UserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}