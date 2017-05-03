using System.Collections.Generic;
using Wonde.WriteBack;

namespace Wonde.EndPoints
{
    public class Attendance : BootstrapEndpoint
    {
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token">API Token</param>
        /// <param name="url">Url to add</param>
        internal Attendance(string token, string url) : base(token, url)
        {
            Uri = Uri + "attendance/session";
        }

        /// <summary>
        /// Registers a attendances sessions to the school
        /// </summary>
        /// <param name="sessionRegister">Object of Wonde.WriteBack.SessionRegister</param>
        /// <returns>Returned data in Dictionary object</returns>
        public Dictionary<string, object> sessionRegister(SessionRegister sessionRegister)
        {
            return post(Helpers.StringHelper.formatObjectAsJson(sessionRegister));
        }
    }
}
