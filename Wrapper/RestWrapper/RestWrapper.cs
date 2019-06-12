using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace PUBGAPIWrapper.RestWrapper
{
    public class Client
    {
        private IRestClient _client { get; set; }

        /// <summary>
        /// Amount of requests left before being rate limited
        /// </summary>
        public int? RateLimitRemaining { get; set; }

        /// <summary>
        /// Time when rate limit resets, in seconds from the unix utc epoch
        /// </summary>
        public int RateLimitReset { get; set; }

        private const string RateLimitRemainingHeaderName = "X-Ratelimit-Remaining";
        private const string RateLimitResetHeaderName = "X-Ratelimit-Reset";

        public Client(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Executes rest request with the given request.
        /// </summary> 
        /// <remarks>
        /// Using the rate limit information from the response headers,
        /// sleeps until the rate limit reset when out of requests.
        /// TODO: Async this to not stop the main thread?
        /// </remarks>
        public Response Execute(Request request)
        {
            var innerResponse = _client.Execute(request.ToRestRequest());
            if (innerResponse.StatusCode == (HttpStatusCode)429) throw new Exception("Rate limited!");
            Response response = new Response(innerResponse);

            try
            {
                RateLimitRemaining = Convert.ToInt32(response.Headers.Where(h => h.Name == RateLimitRemainingHeaderName).Select(h => h.Value).Single());
                RateLimitReset = Convert.ToInt32(response.Headers.Where(h => h.Name == RateLimitResetHeaderName).Select(h => h.Value).Single());
                Console.WriteLine("Requests remaining: " + RateLimitRemaining + "\nRequest reset time: " + RateLimitReset);
            }
            catch (InvalidOperationException e)
            {
                RateLimitRemaining = null;
                Console.WriteLine("Rate limit header was missing.");
            }

            if (RateLimitRemaining.HasValue && RateLimitRemaining == 0)
            {
                Console.WriteLine("Rate limited. Sleeping.");
                int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int secondsUntilReset = RateLimitReset - now;
                Thread.Sleep(secondsUntilReset);
            }

            return response;
        }
    }

    public class Request
    {
        #region Private Properties

        private IRestRequest _request { get; set; }

        #endregion

        /// <summary>
        /// Exposes the inner RestRequest
        /// </summary>
        /// <remarks>
        /// TODO: anything better
        /// </remarks>
        public IRestRequest ToRestRequest()
        {
            return _request;
        }

        public Request()
        {
            _request = new RestRequest();
        }

        public Request(string resource)
        {
            _request = new RestRequest(resource);
        }

        public void AddHeader(string name, string value)
        {
            _request.AddHeader(name, value);
        }

        public override string ToString()
        {
            string toString = "Method: " + _request.Method + "\n"
                + "Resource: " + _request.Resource + "\n";
            foreach (Parameter prm in _request.Parameters)
            {
                toString += "Parameter:\n"
                    + "Name: " + prm.Name + "\n"
                    + "Type: " + prm.Type + "\n"
                    + "Value: " + prm.Value + "\n"
                    + "ContentType: " + prm.ContentType + "\n";
            }
            return toString;
        }
    }

    public class Response
    {
        #region Private Properties

        private IRestResponse _response { get; set; }

        #endregion

        #region Public Properties

        public IRestRequest Request { get { return _response.Request; } set { _response.Request = value; }  }
        public string ContentType { get { return _response.ContentType; } set { _response.ContentType = value; } }
        public long ContentLength { get { return _response.ContentLength; } set { _response.ContentLength = value; } }
        public string ContentEncoding { get { return _response.ContentEncoding; } set { _response.ContentEncoding = value; } }
        public string Content { get { return _response.Content; } set { _response.Content = value; } }
        public HttpStatusCode StatusCode { get { return _response.StatusCode; } set { _response.StatusCode = value; } }

        public bool IsSuccessful { get { return _response.IsSuccessful; } }

        public string StatusDescription { get { return _response.StatusDescription; } set { _response.StatusDescription = value; } }
        public byte[] RawBytes { get { return _response.RawBytes; } set { _response.RawBytes = value; } }
        public Uri ResponseUri { get { return _response.ResponseUri; } set { _response.ResponseUri = value; } }
        public string Server { get { return _response.Server; } set { _response.Server = value; } }

        public IList<RestResponseCookie> Cookies { get { return _response.Cookies; } }

        public IList<Parameter> Headers { get { return _response.Headers; } }

        public ResponseStatus ResponseStatus { get { return _response.ResponseStatus; } set { _response.ResponseStatus = value; } }
        public string ErrorMessage { get { return _response.ErrorMessage; } set { _response.ErrorMessage = value; } }
        public Exception ErrorException { get { return _response.ErrorException; } set { _response.ErrorException = value; } }
        public Version ProtocolVersion { get { return _response.ProtocolVersion; } set { _response.ProtocolVersion = value; } }

        #endregion

        #region Constructors

        public Response()
        {
            _response = new RestResponse();
        }

        public Response(IRestResponse response)
        {
            this._response = response;
        }

        #endregion

        public override string ToString()
        {
            string toString = "Success: " + _response.IsSuccessful + "\n"
                + "Status Code: " + _response.StatusCode + "\n"
                + "Status Description: " + _response.StatusDescription + "\n"
                + "ContentType: " + _response.ContentType + "\n"
                + "ContentEncoding: " + _response.ContentEncoding + "\n";

            foreach (Parameter head in _response.Headers)
            {
                toString += "Header:\n"
                    + " Name: " + head.Name + "\n"
                    + " Type: " + head.Type + "\n"
                    + " Value: " + head.Value + "\n"
                    + " ContentType: " + head.ContentType + "\n";
            }

            foreach (RestResponseCookie cook in _response.Cookies)
            {
                toString += "Cookie:\n"
                    + " Value: " + cook.Value + "\n";
            }

            if (_response.IsSuccessful)
                toString += "Content: " + _response.Content + "\n";
            else
                toString += "Error Exception: " + _response.ErrorException + "\n"
                + "Error Message: " + _response.ErrorMessage + "\n";
            return toString;
        }
    }
}
