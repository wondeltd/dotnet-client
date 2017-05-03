using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Wonde.Helpers.Exceptions
{
    /// <summary>
    /// Exception received from REST calls to servers. It is thrown whenever a response code is not 200
    /// </summary>
    [Serializable]
    public class RestClientException : Exception
    {
        public RestClientException()
        {
        }

        public RestClientException(string message) : base(message)
        {
        }

        public RestClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RestClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpWebResponse Response { get; internal set; }

        public Dictionary<string, object> ErrorDetails { get; set; }
    }
}