using Wonde.WriteBack;
using System.Collections.Generic;

namespace Wonde.EndPoints
{
    public class Achievements : BootstrapEndpoint
    {
        /// <summary>
        /// Internal Constructor so object can only be retrieved through Wonde.Endpoints.Schools object
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="url">Url to set</param>
        internal Achievements(string token, string url) : base(token, url)
        {
            Uri += "achievements";
        }

        /// <summary>
        /// Posts the students achievements
        /// </summary>
        /// <param name="studentsAchievements">Object of Type Wonde.WriteBack.StudentsAchievements</param>
        /// <returns>Responce returned in Dictionary object</returns>
        public Dictionary<string, object> postAchievements(StudentsAchievements studentsAchievements)
        {
            return this.post(Helpers.StringHelper.formatObjectAsJson(studentsAchievements));
        }

        /// <summary>
        /// Deletes the achievements record
        /// </summary>
        /// <param name="achievementId">Achievement id</param>
        /// <returns>Return status as Dictionary</returns>
        public string deleteAchievements(string achievementId)
        {
            return this.deleteRequest(Uri + "/" + achievementId, "", true);
        }
    }
}