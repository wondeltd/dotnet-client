using System;
using System.Collections.Generic;
using Wonde.Exceptions;


namespace Wonde.WriteBack
{
    public class StudentsAchievements
    {
        /// <summary>
        /// List Array of StudentAchievementRecord objects
        /// </summary>
        public List<StudentsAchievementRecord> students;

        /// <summary>
        /// Gets the Employee id
        /// </summary>
        public string employee_id { get; private set; }

        /// <summary>
        /// Gets the Date string in yyyy-mm-dd format
        /// </summary>
        public string date { get; private set; }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public string type { get; private set; }

        /// <summary>
        /// Gets the employee comment
        /// </summary>
        public string comment { get; private set; }

        /// <summary>
        /// Gets the activity type
        /// </summary>
        public object activity_type { get; private set; }

        /// <summary>
        /// Creates the StudentsAchievements object
        /// </summary>
        /// <param name="employeeId">Employee id of employee</param>
        /// <param name="date">Date in yyyy-mm-dd format</param>
        /// <param name="type">Sets the Type as Achievement attributes of ACHIEVEMENT_TYPE</param>
        /// <param name="activityType">Sets the Activity Type of Achievement attributes EVENT_SUBJECT</param>
        /// <param name="comment">Comment if any</param>
        /// <exception cref="InvalidStudentsAchievementsException" />
        public StudentsAchievements(string employeeId, string date, string type, string activityType = "", string comment = "")
        {
            students = new List<StudentsAchievementRecord>();
            
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
            
            if(activityType.Trim().Length > 0)
                activity_type = activityType.ToUpper();
            this.comment = comment.Trim();

            if (message.Length > 0)
                throw new InvalidStudentsAchievementsException(message.Trim());
        }

        /// <summary>
        /// Adds the StudentsAchievement record
        /// </summary>
        /// <param name="studentAchievementRecord">Object of type StudentsAchievementRecord</param>
        public void addStudentsAchievementRecord(StudentsAchievementRecord studentAchievementRecord)
        {
            students.Add(studentAchievementRecord);
        }
    }
}
