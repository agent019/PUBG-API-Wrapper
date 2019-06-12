using PUBGAPIWrapper.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace PUBGAPIWrapper.Service
{
    public class Response
    {
        #region Private Properties

        private IRestResponse _response { get; set; }

        #endregion

        #region Public Properties

        public IRestRequest Request { get { return _response.Request; } set { _response.Request = value; } }
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
