using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wonde.Helpers.Exceptions;

namespace Wonde.Helpers
{

    internal enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    /// <summary>
    /// Class RestClient to make REST calls to servers
    /// </summary>
    internal class RestClient
    {

        private Dictionary<HttpRequestHeader, string> headers = null;
        /// <summary>
        /// Get or Set EndPoint URI for REST calls to API
        /// </summary>
        internal string EndPoint { get; set; }
        /// <summary>
        /// Get or Set HTTP Verb to make rest calls
        /// </summary>
        internal HttpVerb Method { get; set; }
        /// <summary>
        /// Get or Set the ContentType to send/receive data from api.
        /// </summary>
        /// <default>Application/json</default>
        internal string ContentType { get; set; }

        /// <summary>
        /// Get or Set the data to post to the api when making rest calls. This data is different from URI data sent. It can include the Json data to sent to the server.
        /// </summary>
        internal string PostData { get; set; }

        /// <summary>
        /// Default contructor for creating the object with default values
        /// </summary>
        internal RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "Application/json";
            PostData = "";
            headers = new Dictionary<HttpRequestHeader, string>();
        }

        /// <summary>
        /// Constructor allowing to set the EndPoint URI to the object
        /// </summary>
        /// <param name="endpoint">API EndPoint URI</param>
        internal RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
            headers = new Dictionary<HttpRequestHeader, string>();
        }

        /// <summary>
        /// Create object with api URI endpoint and HttpVerb to call with
        /// </summary>
        /// <param name="endpoint">API EndPoint URI</param>
        /// <param name="method">HTTP Verb like GET, POST, PUT or DELETE</param>
        internal RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = "";
            headers = new Dictionary<HttpRequestHeader, string>();
        }

        /// <summary>
        /// Create object with endpoint uri, the Http Verb and postdata to send to the api
        /// </summary>
        /// <param name="endpoint">API EndPoint URI</param>
        /// <param name="method">HTTP Verb like GET, POST, PUT or DELETE</param>
        /// <param name="postData">The data to be posted. Can contain Json string</param>
        internal RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = postData;
            headers = new Dictionary<HttpRequestHeader, string>();
        }

        /// <summary>
        /// Add headers to the current request
        /// </summary>
        /// <param name="header">The header type of enum HttpRequestHeader</param>
        /// <param name="value">The value as string to set for the header</param>
        internal void AddHeaders(HttpRequestHeader header, string value)
        {
            headers.Add(header, value);
        }

        /// <summary>
        /// Method to make the request without parameter query string Uri
        /// </summary>
        /// <returns>Response String</returns>
        /// <exception cref="RestClientException"></exception>
        internal string MakeRequest()
        {
            return MakeRequest("");
        }

        /// <summary>
        /// Method to make the request with Query String URI
        /// </summary>
        /// <param name="uri">The Uri with query string if any</param>
        /// <returns>Response String</returns>
        /// <exception cref="RestClientException"></exception>
        internal string MakeRequest(string uri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(EndPoint + uri);

                foreach (KeyValuePair<HttpRequestHeader, string> keyval in headers)
                {
                    if (keyval.Key == HttpRequestHeader.UserAgent)
                        request.UserAgent = keyval.Value;
                    else
                        request.Headers.Add(keyval.Key, keyval.Value);
                }

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
                {
                    var encoding = new UTF8Encoding();
<<<<<<< HEAD
                    var bytes = Encoding.UTF8.GetBytes(PostData);
=======
                    var bytes = Encoding.GetEncoding("utf8").GetBytes(PostData);
>>>>>>> origin/development
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw getRestClientException(response, null);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }
            catch (WebException webex)
            {
                throw getRestClientException(null, webex);
            }
        }

        private RestClientException getRestClientException(HttpWebResponse res, WebException webex)
        {
            string message = "";
            
            if (res == null && webex != null)
                res = (HttpWebResponse)webex.Response;
            if (res == null)
                message = "Request Failed. Error: " + webex.Message;
            else
                message = string.Format("Request Failed. Received HTTP {0}", (int)res.StatusCode);
            RestClientException ex = null;
            if (webex != null)
                ex = new RestClientException(message, webex);
            else
                ex = new RestClientException(message);
            if (res != null)
            {
                ex.Response = res;
                ex.ErrorDetails = StringHelper.getJsonAsDictionary((new StreamReader(res.GetResponseStream())).ReadToEnd());
            }
            return ex;
        }

    } 
}
