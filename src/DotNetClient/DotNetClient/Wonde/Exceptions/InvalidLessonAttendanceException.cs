using System;
using System.Runtime.Serialization;

namespace Wonde.Exceptions
{
    [Serializable]
    public class InvalidLessonAttendanceException : Exception
    {
        public InvalidLessonAttendanceException()
        {
        }

        public InvalidLessonAttendanceException(string message) : base(message)
        {
        }

        public InvalidLessonAttendanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLessonAttendanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}