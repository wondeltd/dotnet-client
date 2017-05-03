namespace Wonde.EndPoints
{
    public class AttendanceCodes : BootstrapEndpoint
    {
        /// <summary>
        /// Internal Constructor so object can only be retrieved through Wonde.Endpoints.Schools object
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="url">Url to set</param>
        public AttendanceCodes(string token, string url = "") : base(token, url)
        {
            Uri = Uri + "attendance-codes/";
        }
    }
}
