using System;
using Wonde.Exceptions;

namespace Wonde.WriteBack
{
    public class StudentsAchievementRecord
    {
        /// <summary>
        /// Gets the student id
        /// </summary>
        public string student_id { get; private set; }

        /// <summary>
        /// Gets the achievement points
        /// </summary>
        public int points { get; private set; }

        /// <summary>
        /// Gets the award
        /// </summary>
        public object award { get; private set; }

        /// <summary>
        /// Gets the award date
        /// </summary>
        public object award_date { get; private set; }

        /// <summary>
        /// Create student achievement record object
        /// </summary>
        /// <param name="studentId">sting value for student id</param>
        /// <param name="points">numeric integer for points</param>
        /// <param name="award">string value for award as per Achievement attribute ACHIEVEMENT_OUTCOME</param>
        /// <param name="awardDate">string representation of date of award in yyyy-mm-dd format</param>
        /// <exception cref="InvalidStudentsAchievementsException" />
        public StudentsAchievementRecord(string studentId, int points, string award = "", string awardDate = "")
        {
            string message = "";
            if (studentId.Trim().Length <= 0)
                message += "Student Id is invalid\n";
            this.student_id = studentId;

            this.points = points;
            if(award.Trim().Length > 0)
                this.award = award.ToUpper();
            if (awardDate.Trim().Length > 0)
            {
                DateTime dt;
                if (DateTime.TryParseExact(awardDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                    this.award_date = dt.ToString("yyyy-MM-dd");
                else
                    message += "Award Date is Invalid\n";
            }
            if (message.Length > 0)
                throw new InvalidStudentsAchievementsException(message.Trim());
        }
    }
}
