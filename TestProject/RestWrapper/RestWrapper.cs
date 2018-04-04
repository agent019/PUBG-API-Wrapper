using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace TestProject.RestWrapper
{
    public class Client
    {
        private IRestClient _client { get; set; }
        public DateTime LastRequestTime { get; set; }
        public int RecentRequestCount { get; set; }


        public Client(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Executes rest request with the given request.
        /// </summary>
        /// <remarks>
        /// Throws on Too Many Requests response.
        /// </remarks>
        public Response Execute(Request request)
        {
            var response = _client.Execute(request.ToRestRequest());
            if (response.StatusCode == (HttpStatusCode)429) throw new Exception("Rate limited!");
            return new Response(response);
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
    }
}
