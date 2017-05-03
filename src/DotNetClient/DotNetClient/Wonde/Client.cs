using Wonde.EndPoints;
using Wonde.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonde
{
    /// <summary>
    /// Wonde Client to access Wonde server
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Setting version for the client
        /// </summary>
        public const string VERSION = "1.0.2";

        /// <summary>
        /// Token for accessing the server
        /// </summary>
        private string _token = "";

        /// <summary>
        /// Gets or Sets object of AttendanceCodes
        /// </summary>
        public AttendanceCodes attendanceCodes { get; set; }

        /// <summary>
        /// Gets or Sets object of Schools
        /// </summary>
        public Schools schools { get; set; }

        
        /// <summary>
        /// Create object through constructor
        /// </summary>
        /// <param name="token">token to access school information</param>
        public Client(string token)
        {
            if (token.Length <= 0)
            {
                throw new InvalidTokenException("Token String is Required");
            }

            _token = token;
            schools = new Schools(token);
            attendanceCodes = new AttendanceCodes(token);
        }

        /// <summary>
        /// Returns single school referenced by its id
        /// </summary>
        /// <param name="id">School Id to return details</param>
        /// <returns>A single School information</returns>
        public Schools school(string id)
        {
            return new Schools(_token, id);
        }

        /// <summary>
        /// Request access to the current school
        /// </summary>
        /// <param name="schoolId">School id to add access request for the token</param>
        /// <returns>Object representation of json returned as Dictionary</returns>
        public Dictionary<string, object> requestAccess(string schoolId)
        {
            string uri = "schools/" + schoolId + "/request-access";

            return (new BootstrapEndpoint(_token, uri)).post("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolId">School id to delete/revoke access request for the token</param>
        /// <returns>Object representation of json returned as Dictionary</returns>
        public Dictionary<string, object> revokeAccess(string schoolId)
        {
            string uri = "schools/" + schoolId + "/revoke-access";

            return (new BootstrapEndpoint(_token, uri)).delete("");
        }

    }
}
