using System;
using System.Runtime.Serialization;

namespace Wonde.Exceptions
{
    [Serializable]
    public class InvalidSessionAttendanceException : Exception
    {
        public InvalidSessionAttendanceException()
        {
        }

        public InvalidSessionAttendanceException(string message) : base(message)
        {
        }

        public InvalidSessionAttendanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSessionAttendanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}