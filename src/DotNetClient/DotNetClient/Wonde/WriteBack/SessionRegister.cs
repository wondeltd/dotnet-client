using System;
using System.Collections.Generic;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public class SessionRegister
    {
        /// <summary>
        /// Attendance array list
        /// </summary>
        public List<SessionAttendanceRecord> attendance;

        /// <summary>
        /// SessionRegister constructor
        /// </summary>
        public SessionRegister()
        {
            attendance = new List<SessionAttendanceRecord>();
        }

        /// <summary>
        /// Add SessionAttendanceRecord to the attendance array list
        /// </summary>
        /// <param name="sessionAttendance">Object of SessionAttendanceRecord</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public void add(SessionAttendanceRecord sessionAttendance)
        {
            if(sessionAttendance == null)
                throw new InvalidSessionAttendanceException("Attendance is null or is not an instance of the SessionAttendanceRecord Class.");

            if (!sessionAttendance.isValid())
                throw new InvalidSessionAttendanceException("Attendance has empty fields.");

            attendance.Add(sessionAttendance);
        }
    }
}
