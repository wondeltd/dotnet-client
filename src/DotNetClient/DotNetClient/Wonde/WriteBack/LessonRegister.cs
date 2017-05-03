using System;
using System.Collections.Generic;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public class LessonRegister
    {
        /// <summary>
        /// Attendance array list
        /// </summary>
        public List<LessionAttendanceRecord> attendances;

        /// <summary>
        /// LessionRegister constructor
        /// </summary>
        public LessonRegister()
        {
            attendances = new List<LessionAttendanceRecord>();
        }

        /// <summary>
        /// Add LessionAttendanceRecord to the attendance array list
        /// </summary>
        /// <param name="lessionAttendance">Object of LessionAttendanceRecord</param>
        /// <exception cref="InvalidLessonAttendanceException" />
        public void add(LessionAttendanceRecord lessionAttendance)
        {
            if (lessionAttendance == null)
                throw new InvalidLessonAttendanceException("Attendance is null or is not an instance of the LessonAttendanceRedord Class.");

            if (!lessionAttendance.isValid())
                throw new InvalidLessonAttendanceException("Attendance has empty fields.");

            attendances.Add(lessionAttendance);
        }
    }
}
