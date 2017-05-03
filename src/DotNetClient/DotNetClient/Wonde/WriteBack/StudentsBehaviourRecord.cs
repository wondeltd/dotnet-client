using System;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public class StudentsBehaviourRecord
    {
        /// <summary>
        /// Gets the student id
        /// </summary>
        public string student_id { get; private set; }

        /// <summary>
        /// Gets the role
        /// </summary>
        public object role { get; private set; }

        /// <summary>
        /// Gets the action taken
        /// </summary>
        public object action { get; private set; }

        /// <summary>
        /// Gets the action taken date
        /// </summary>
        public object action_date { get; private set; }

        /// <summary>
        /// Gets the behaviour points
        /// </summary>
        public int points { get; private set; }

        /// <summary>
        /// Create object of StudentsBehaviourRecord
        /// </summary>
        /// <param name="studentId">Student id string</param>
        /// <param name="points">Points in numbers</param>
        /// <param name="role">Role as per Behaviour attribute BEHAVIOUR_ROLE</param>
        /// <param name="action">Action as per Behaviour attribute BEHAVIOUR_OUTCOME</param>
        /// <param name="actionDate">Date of action in y-m-d format</param>
        /// <exception cref="InvalidStudentsBehavioursException" />
        public StudentsBehaviourRecord(string studentId, int points, string role = "", string action = "", string actionDate = "")
        {
            string message = "";
            if (studentId.Trim().Length <= 0)
                message += "Student Id is invalid\n";
            this.student_id = studentId;

            this.points = points;
            if (role.Trim().Length > 0)
                this.role = role.ToUpper();
            if(action.Trim().Length > 0)
                this.action = action.ToUpper();

            if (actionDate.Trim().Length > 0)
            {
                DateTime dt;
                if (DateTime.TryParseExact(actionDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                    this.action_date = dt.ToString("yyyy-MM-dd");
                else
                    message += "Action date is Invalid\n";
            }

            if (message.Length > 0)
                throw new InvalidStudentsBehavioursException(message.Trim());
        }
    }
}
