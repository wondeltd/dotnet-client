using System;
using System.Runtime.Serialization;

namespace Wonde.Exceptions
{
    [Serializable]
    public class InvalidStudentsAchievementsException : Exception
    {
        public InvalidStudentsAchievementsException()
        {
        }

        public InvalidStudentsAchievementsException(string message) : base(message)
        {
        }

        public InvalidStudentsAchievementsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStudentsAchievementsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}