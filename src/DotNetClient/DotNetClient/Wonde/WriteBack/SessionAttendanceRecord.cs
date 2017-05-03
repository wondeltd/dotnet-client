using System;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public enum Session
    {
        AM,
        PM
    }

    public class SessionAttendanceRecord
    {
        /// <summary>
        /// Gets the student id string
        /// </summary>
        public string student_id { get; private set; }

        /// <summary>
        /// Gets the date string
        /// </summary>
        public string date { get; private set; }

        /// <summary>
        /// Gets the session string
        /// </summary>
        public string session { get; private set; }

        /// <summary>
        /// Gets the attendance code id string
        /// </summary>
        public string attendance_code_id { get; private set; }

        /// <summary>
        /// Gets the comment string
        /// </summary>
        public string comment { get; private set; }

        /// <summary>
        /// Gets the minutes_late string
        /// </summary>
        public object minutes_late { get; private set; }

        /// <summary>
        /// Sets the student id
        /// </summary>
        /// <param name="studentId">String student id</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public void setStudentId(string studentId)
        {
            if (studentId.Trim().Length <= 0)
            {
                throw new InvalidSessionAttendanceException("Student id can not be set to null.");
            }

            student_id = studentId;
        }

        /// <summary>
        /// Create object 
        /// </summary>
        public SessionAttendanceRecord() { }

        /// <summary>
        /// Create object with initialization of data
        /// </summary>
        /// <param name="studentId">String student id</param>
        /// <param name="date">string date in y-m-d format</param>
        /// <param name="session">Session AM or PM</param>
        /// <param name="attendanceCodeId">Attendance Code id string</param>
        /// <param name="comment">Comment string</param>
        /// <param name="minutesLate">minutes late to register as int</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public SessionAttendanceRecord(string studentId, string date, Session session, string attendanceCodeId, string comment = null, int minutesLate = -1)
        {
            var message = "";
            if (studentId.Trim().Length > 0)
                student_id = student_id;
            else
                message += "Invalid Student ID\n";

            if (date.Trim().Length <= 0)
                message += "Date is Invalid\n";
            DateTime dt;
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                this.date = dt.ToString("yyyy-MM-dd");
            else
                message += "Date is Invalid\n";

            this.session = session.ToString();

            if (attendanceCodeId.Trim().Length <= 0)
                message += "Attendance Code ID is invalid\n";
            if (message.Length > 0)
                throw new InvalidSessionAttendanceException(message);

            attendance_code_id = attendanceCodeId;

            this.comment = comment;
            if (minutesLate >= 0)
                minutes_late = minutesLate;
        }

        /// <summary>
        /// Sets the date
        /// </summary>
        /// <param name="date">date in string</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public void setDate(string dateString)
        {
            if (dateString.Trim().Length <= 0)
            {
                throw new InvalidSessionAttendanceException("Date can not be set to null.");
            }

            DateTime time;
            if(DateTime.TryParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out time))
            {
                this.date = time.ToString("yyyy-MM-dd");
            }
            else 
            {
                throw new InvalidSessionAttendanceException("Date provided is invalid");
            }
        }

        /// <summary>
        /// Sets the session
        /// </summary>
        /// <param name="sessionString">Session String AM or PM</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public void setSession(Session session)
        {
            if(session == Session.AM || session == Session.PM)
            { 
                this.session = session.ToString();
            } 
            else 
            {
                throw new InvalidSessionAttendanceException("The session is invalid");
            }
        }


        /// <summary>
        /// Set attendance code id
        /// 
        /// Attendance codes can be fetched from the attendance-code endpoint
        /// </summary>
        /// <param name="attendanceCodeId">Attendance Code Id string</param>
        /// <exception cref="InvalidSessionAttendanceException" />
        public void setAttendanceCodeId(string attendanceCodeId)
        {
            if (attendanceCodeId.Trim().Length <= 0)
            {
                throw new InvalidSessionAttendanceException("Attendance code id can not be set to null.");
            }

            attendance_code_id = attendanceCodeId;
        }

        /// <summary>
        /// Sets the comment
        /// </summary>
        /// <param name="comment">comment string</param>
        public void setComment(string comment)
        {
            this.comment = comment.Trim();
        }

        /// <summary>
        /// Sets the minutes_late
        /// </summary>
        /// <param name="minutesLate">int value of minutes late for registration</param>
        public void setMinutesLate(int minutesLate = -1)
        {
            if (minutesLate >= 0)
                minutes_late = minutesLate;
        }

        /// <summary>
        /// Check if all values are set
        /// </summary>
        /// <returns>Check result in boolean</returns>
        public bool isValid()
        {
            return date.Trim().Length > 0 && student_id.Trim().Length > 0 && session.Trim().Length > 0 && attendance_code_id.Trim().Length > 0;
        }
        
    }
}
