using RestSharp;

namespace PUBGAPIWrapper.Service
{
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
}
