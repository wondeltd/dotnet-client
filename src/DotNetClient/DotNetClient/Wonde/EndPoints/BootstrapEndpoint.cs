using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Wonde.Exceptions;
using Wonde.Helpers;
using Wonde.Helpers.Exceptions;

namespace Wonde.EndPoints
{
    /// <summary>
    /// Class to access the Wonde API endpoints for all tasks
    /// </summary>
    public class BootstrapEndpoint
    {
        /// <summary>
        /// The endpoint uri for accessing the wonde api
        /// </summary>
        const string ENDPOINT = "https://api.wonde.com/v1.0/";

        //TODO:Write the body
        /// <summary>
        /// Part uri to access
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the Extended Uri so base Uri does not change for the case.
        /// </summary>
        /// <example>base Uri can be "schools/" and extended could be "pending/" or "all/", etc</example>
        internal string ExtendedUri { get; set; }

        /// <summary>
        /// Token used to access the wonde api
        /// </summary>
        protected string _token;

        public string Token
        {
            get { return _token; }
        }

        /// <summary>
        /// Constructor to create object of BootstrapEndpoint
        /// </summary>
        /// <param name="_token"></param>
        /// <param name="uri"></param>
        public BootstrapEndpoint(string token, string uri = "")
        {
            _token = token;
            if (uri.Length > 0)
            {
                Uri = uri;
            }
        }

        /// <summary>
        /// Returns the object of the WebRequest class to handle request to Wonde API
        /// </summary>
        /// <returns>RestClient object</returns>
        private RestClient getClient(string url)
        {
            RestClient client = new RestClient(url);

            client.AddHeaders(HttpRequestHeader.Authorization, "bearer " + _token);
            client.AddHeaders(HttpRequestHeader.UserAgent, "wonde-php-client-" + Client.VERSION);

            return client;
        }

        private void throwError(RestClientException clientException)
        {
            if (clientException.Response.StatusCode == (HttpStatusCode)422)
            {
                var validationError = new ValidationErrorException("Validation has failed", clientException);
                validationError.ErrorDetails = StringHelper.getJsonAsDictionary((new StreamReader(clientException.Response.GetResponseStream())).ReadToEnd());
                throw validationError;
            }
            else
                throw clientException;
        }

        /// <summary>
        /// Make an endpoint request to wonde api
        /// </summary>
        /// <param name="endpoint">the endpoint request to the wonde api</param>
        /// <returns>A response returned for the requested endpint on wonde api</returns>
        private string getRequest(string endpoint)
        {
            return getUrl(ENDPOINT + endpoint);
        }

        /// <summary>
        /// Just a get request to the url using token.
        /// </summary>
        /// <param name="url">The full url to make the request</param>
        /// <returns>A response returned for the requested URL</returns>
        public string getUrl(string url)
        {
            RestClient client = getClient(url);
            client.Method = HttpVerb.GET;
            return client.MakeRequest();
        }



        /// <summary>
        /// Get all of the resources
        /// </summary>
        /// <param name="includes">Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources</param>
        /// <returns>ResultIterator object to iterate through the results</returns>
        public ResultIterator all(string[] includes = null, Dictionary<string, string> parameters = null)
        {
            return new ResultIterator(getAll(includes, parameters), Token);
        }

        /// <summary>
        /// Gets the Dictionary object instead of the ResultIterator object 
        /// and marked as protected, so only its derived class can have access to it.
        /// </summary>
        /// <param name="includes">Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources</param>
        /// <returns>Dictionary&ltstring, object&gt; object to iterate through the results</returns>
        protected Dictionary<string, object> getAll(string[] includes, Dictionary<string, string> parameters)
        {
            if (parameters == null)
                parameters = new Dictionary<string, string>();
            if (includes != null && includes.Length > 0)
            {
                parameters.Add("include", string.Join(",", includes));
            }

            return StringHelper.getJsonAsDictionary(getRequest(createUri("", parameters)));
        }

        /// <summary>
        /// Get single resource
        /// </summary>
        /// <param name="id">id of the resource</param>
        /// <param name="includes"Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources</param>
        /// <returns>Object data of the single resource. Return as an ArrayList object</returns>
        public object get(string id, string[] includes = null, Dictionary<string, string> parameters = null)
        {
            if (parameters == null)
                parameters = new Dictionary<string, string>();
            if (includes != null && includes.Length > 0)
            {
                parameters.Add("include", string.Join(",", includes));
            }

            return StringHelper.getJsonAsDictionary(getRequest(createUri(id, parameters)))["data"];
        }

        /// <summary>
        /// Creates Uri to be called using the ExtendedUri property if it is set.
        /// </summary>
        /// <param name="id">ID used to be called</param>
        /// <param name="parameters">Parameters including the includes parameter</param>
        /// <returns>String URL to be used for calling</returns>
        private string createUri(string id = "", Dictionary<string, string> parameters = null)
        {
            var uri = Uri + ExtendedUri;
            uri = (parameters != null && parameters.Count > 0) ? uri + id.ToString() + '?' + StringHelper.buildHttpQueryString(parameters) : uri + id;
            return uri;
        }

        /// <summary>
        /// Make a POST request to the Rest Api
        /// </summary>
        /// <param name="endpoint">End point to call on the api</param>
        /// <param name="body">Body to send as POST data</param>
        /// <param name="isJson">If data is in Json format</param>
        /// <returns>Returns String represented data</returns>
        public string postRequest(string endpoint, string body, bool isJson)
        {
            return postUrl(ENDPOINT + endpoint, body, isJson);
        }

        /// <summary>
        /// Make a POST request to Rest Api
        /// </summary>
        /// <param name="url">actual Url to be posted to</param>
        /// <param name="body">the body to send as POST data</param>
        /// <param name="isJson">If data is in Json format</param>
        /// <returns>Response string</returns>
        private string postUrl(string url, string body, bool isJson)
        {
            RestClient client = getClient(url);
            client.Method = HttpVerb.POST;
            client.PostData = body;
            if (isJson)
                client.ContentType = "application/json";
            return client.MakeRequest();

        }

        /// <summary>
        /// Make a POST request to the Rest Api
        /// </summary>
        /// <param name="body">Body to be posted and should be in Json format</param>
        /// <returns>Response from the Api decoded as Key/Value pair of Dictionary object</returns>
        public Dictionary<string, object> post(string body)
        {
            var postData = "";
            try
            {
                postData = postRequest(Uri, body, true);
            }
            catch (RestClientException ex)
            {
                throwError(ex);
            }

            return StringHelper.getJsonAsDictionary(postData);
        }


        /// <summary>
        /// Make a DELETE request to the Rest Api
        /// </summary>
        /// <param name="endpoint">End point to call on the Api</param>
        /// <param name="body">Body to be sent for DELETE request</param>
        /// <param name="isJson">If data is in Json format</param>
        /// <returns>Response from the api</returns>
        public string deleteRequest(string endpoint, string body, bool isJson)
        {
            return deleteUrl(ENDPOINT + endpoint, body, isJson);
        }



        /// <summary>
        /// Make a DELETE request to the Rest Api
        /// </summary>
        /// <param name="url">Actual url to call for DELETE request</param>
        /// <param name="body">Body to be sent for DELETE request</param>
        /// <param name="isJson">If data is in Json format</param>
        /// <returns>Response from the Api</returns>
        private string deleteUrl(string url, string body, bool isJson)
        {
            RestClient client = getClient(url);
            client.Method = HttpVerb.DELETE;
            client.PostData = body;
            if (isJson)
                client.ContentType = "application/json";
            return client.MakeRequest();
        }

        /// <summary>
        /// Make a DELETE request to the Rest Api
        /// </summary>
        /// <param name="body">Body to be sent for DELETE request</param>
        /// <returns>Response from the Api decoded as Key/Value pair of Dictionary object</returns>
        public Dictionary<string, object> delete(string body)
        {
            string delData = "";
            try
            {
                delData = deleteRequest(Uri, body, true);
            }
            catch (RestClientException ex)
            {
                throwError(ex);
            }

            return StringHelper.getJsonAsDictionary(delData);
        }
    }
}
