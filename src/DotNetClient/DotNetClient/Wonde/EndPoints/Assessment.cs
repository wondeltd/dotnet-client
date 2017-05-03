using Wonde.EndPoints.Assessments;

namespace Wonde.EndPoints
{
    public class Assessment : BootstrapEndpoint
    {

        /// <summary>
        /// Object of Templates
        /// </summary>
        private Templates templates;

        /// <summary>
        /// Object of Aspects
        /// </summary>
        private Aspects aspects;

        /// <summary>
        /// Object of MarkSheets
        /// </summary>
        private MarkSheets marksheets;

        /// <summary>
        /// Object of Results
        /// </summary>
        private Results results;

        /// <summary>
        /// Object of ResultSets
        /// </summary>
        private ResultSets resultsets;

        /// <summary>
        /// Gets the Templates object
        /// </summary>
        public Templates Templates { get { return templates; } }

        /// <summary>
        /// Gets the Aspects object
        /// </summary>
        public Aspects Aspects { get { return aspects; } }

        /// <summary>
        /// Gets the MarkSheets object
        /// </summary>
        public MarkSheets MarkSheets { get { return marksheets; } }

        /// <summary>
        /// Gets the Results object
        /// </summary>
        public Results Results { get { return results; } }

        /// <summary>
        /// Gets the ResultSets object
        /// </summary>
        public ResultSets ResultSets { get { return resultsets; } }

        /// <summary>
        /// Internal Constructor so object can only be retrieved through Wonde.Endpoints.Schools object
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="id">Assessment id to set</param>
        internal Assessment(string token, string id = "") : base(token, "")
        {
            _token = token;

            if(id.Trim().Length > 0)
            {
                Uri = Uri + id;
            }

            templates = new Templates(token, Uri);
            aspects = new Aspects(token, Uri);
            marksheets = new MarkSheets(token, Uri);
            results = new Results(token, Uri);
            resultsets = new ResultSets(token, Uri);
        }
    }
}