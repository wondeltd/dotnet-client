using System;
using System.Collections.Generic;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public class StudentsBehaviours
    {
        /// <summary>
        /// Gets the List array of type StudentsBehaviourRecord
        /// </summary>
        public List<StudentsBehaviourRecord> students;

        /// <summary>
        /// Gets the employee id
        /// </summary>
        public string employee_id { get; private set; }

        /// <summary>
        /// Gets the date
        /// </summary>
        public string date { get; private set; }

        /// <summary>
        /// Gets the status
        /// </summary>
        public string status { get; private set; }

        /// <summary>
        /// Gets the type
        /// </summary>
        public string type { get; private set; }

        /// <summary>
        /// Gets the bullying type
        /// </summary>
        public object bullying_type { get; private set; }

        /// <summary>
        /// Gets the comment
        /// </summary>
        public string comment { get; private set; }

        /// <summary>
        /// Gets the activity type
        /// </summary>
        public object activity_type { get; private set; }

        /// <summary>
        /// Gets the Location tme zone
        /// </summary>
        public object location { get; private set; }

        /// <summary>
        /// Gets the Time 
        /// </summary>
        public object time { get; private set; }

        

        /// <summary>
        /// Creates object of StudentsBehaviour
        /// </summary>
        /// <param name="employeeId">Sets the employee id</param>
        /// <param name="date">Sets the date in y-m-d format</param>
        /// <param name="status">Sets the status as per Behaviour attribute EVENT_STATUS</param>
        /// <param name="type">Sets the Type as per Behaviour attribute BEHAVIOUR_TYPE</param>
        /// <param name="bullyingType">Sets the bullying type as per Behaviour attribute BULLYING_MODE</param>
        /// <param name="activityType">Sets the activity type as per Behaviour attribute BEHAVIOUR_ACTIVITY</param>
        /// <param name="location">Sets the location as per Behaviour attribute EVENT_TIME</param>
        /// <param name="time">Sets the time as per Behaviour attribute EVENT_LOCATION</param>
        /// <param name="comment">Comment if any</param>
        /// <exception cref="InvalidStudentsBehavioursException" />
        public StudentsBehaviours(string employeeId, string date, string status, string type, string bullyingType = "", string activityType = "", string location = "", string time = "", string comment = "")
        {
            students = new List<StudentsBehaviourRecord>();

            string message = "";
            if (employeeId.Trim().Length <= 0)
                message += "Employee Id is invalid\n";
            this.employee_id = employeeId;
            if (date.Trim().Length <= 0)
                message += "Date is Invalid\n";
            DateTime dt;
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                this.date = dt.ToString("yyyy-MM-dd");
            else
                message += "Date is Invalid\n";
            type = type.Trim();
            if (type.Length <= 0)
                message += "Type is Invalid\n";
            this.type = type.ToUpper();

            if (status.Length <= 0)
                message += "Status is Invalid\n";
            this.status = status.ToUpper();

            if (message.Length > 0)
                throw new InvalidStudentsBehavioursException(message.Trim());

            if(bullyingType.Trim().Length > 0)
                bullying_type = bullyingType.ToUpper();
            if(activityType.Trim().Length > 0)
                activity_type = activityType.ToUpper();
            if(location.Trim().Length > 0)
                this.location = location.ToUpper();
            if(time.Trim().Length > 0)
                this.time = time.ToUpper();
            this.comment = comment;
        }

        public void addStudentsBehaviourRecord(StudentsBehaviourRecord studentsBehaviourRecord)
        {
            students.Add(studentsBehaviourRecord);
        }
    }
}
