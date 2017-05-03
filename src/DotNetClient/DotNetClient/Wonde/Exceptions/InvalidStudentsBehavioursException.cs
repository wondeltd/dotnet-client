using System;
using System.Runtime.Serialization;

namespace Wonde.Exceptions
{
    [Serializable]
    public class InvalidStudentsBehavioursException : Exception
    {
        public InvalidStudentsBehavioursException()
        {
        }

        public InvalidStudentsBehavioursException(string message) : base(message)
        {
        }

        public InvalidStudentsBehavioursException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStudentsBehavioursException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}