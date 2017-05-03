using Wonde.WriteBack;
using System.Collections.Generic;

namespace Wonde.EndPoints
{
    public class Behaviours : BootstrapEndpoint
    {
        /// <summary>
        /// Internal Constructor so object can only be retrieved through Wonde.Endpoints.Schools object
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="url">Url to set</param>
        internal Behaviours(string token, string url) : base(token, url)
        {
            Uri = Uri + "behaviours/";
        }

        /// <summary>
        /// Posts the students behaviours
        /// </summary>
        /// <param name="studentsBehaviours">Object of Type Wonde.WriteBack.StudentsAchievements</param>
        /// <returns>Response returned in Dictionary object</returns>
        public Dictionary<string, object> postBehaviours(StudentsBehaviours studentsBehaviours)
        {
            return this.post(Helpers.StringHelper.formatObjectAsJson(studentsBehaviours));
        }

        /// <summary>
        /// Deletes the behaviours record
        /// </summary>
        /// <param name="behaviourId">Achievement id</param>
        /// <returns>Return status as Dictionary</returns>
        public string deleteBehaviours(string behaviourId)
        {
            return this.deleteRequest(Uri + "/" + behaviourId, "", true);
        }
    }
}