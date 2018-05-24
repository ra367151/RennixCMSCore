using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RennixCMS.Infrastructure.Exceptions
{
    public class RennixException : Exception
    {
        public RennixException() : base()
        {

        }

        public RennixException(string message) : base(message)
        {

        }

        public RennixException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected RennixException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
