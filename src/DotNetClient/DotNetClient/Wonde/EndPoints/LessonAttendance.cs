using System.Collections.Generic;
using Wonde.WriteBack;

namespace Wonde.EndPoints
{
    public class LessonAttendance : BootstrapEndpoint
    {
        /// <summary>
        /// Internal Constructor so object can only be retrieved through Wonde.Endpoints.Schools object
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="url">Url to set</param>
        internal LessonAttendance(string token, string url) : base(token, url)
        {
            Uri = Uri + "attendance/lesson";
        }

        /// <summary>
        /// Registers a attendances lessons to the school
        /// </summary>
        /// <param name="lessonRegister">Object of LessonRegister class</param>
        /// <returns>Return value in Dictionary object</returns>
        public Dictionary<string, object> lessonRegister(LessonRegister lessonRegister)
        {

            return post(Helpers.StringHelper.formatObjectAsJson(lessonRegister));

        }
    }
}