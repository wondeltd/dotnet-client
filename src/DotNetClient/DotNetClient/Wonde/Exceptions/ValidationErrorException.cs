using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wonde.Exceptions
{
    [Serializable]
    public class ValidationErrorException : Exception
    {
        public Dictionary<string, object> ErrorDetails { get; set; }

        public ValidationErrorException()
        {
        }

        public ValidationErrorException(string message) : base(message)
        {
        }

        public ValidationErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}