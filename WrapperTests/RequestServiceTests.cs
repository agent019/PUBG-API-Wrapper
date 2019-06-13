using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PUBGAPIWrapper;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace WrapperTests
{
    [TestClass]
    public class RequestServiceTests
    {
        public static string ApiKey = "A1B2C3D4";
        public static int HeaderCount = 2;

        public static List<KeyValuePair<string, string>> ExpectedHeaders = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Authorization", "Bearer " + ApiKey),
            new KeyValuePair<string, string>("Accept", "application/vnd.api+json")
        };

        [TestClass]
        public class Status
        {
            public static IRestResponse StatusResponse = new RestResponse()
            {
                Content = "{ Id: 1, Version: \"v3\" }"
            };

            [TestMethod, TestCategory("Unit")]
            public void GetStatus_ItMakesTheCorrectRequest()
            {
                Mock<IRestClient> mockClient = new Mock<IRestClient>();
                mockClient.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                    .Returns(StatusResponse);

                var instance = Arrangement.GetInstance(mockClient);

                instance.GetStatus();

                mockClient.Verify(x => x.Execute(It.Is<RestRequest>(r =>
                    AssertParameters(r) &&
                    r.Resource == "/status")));
            }

            [TestMethod, TestCategory("Unit")]
            public void GetStatus_ItDeserializesTheResponseCorrectly()
            {
                Mock<IRestClient> mockClient = new Mock<IRestClient>();
                mockClient.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                    .Returns(StatusResponse);

                var instance = Arrangement.GetInstance(mockClient);

                var result = instance.GetStatus();

                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("v3", result.Version);
            }
        }

        [TestClass]
        public class Matches
        {
            public static IRestResponse MatchResponse = new RestResponse()
            {
                Content = "{ Id: 1, GameMode: 123 }"
            };

            public static IRestResponse SampleMatchResponse = new RestResponse()
            {
                Content = "{ Ids: [ 1, 2, 3 ] }"
            };
        }

        [TestClass]
        public class Players
        {
            public static IRestResponse PlayerResponse = new RestResponse()
            {
                Content = "{ Id: 1, Name: Bob }"
            };

            public static IRestResponse ListPlayerResponse = new RestResponse()
            {
                Content = "{ }"
            };
        }

        [TestClass]
        public class Seasons
        {
            public static IRestResponse SeasonListResponse = new RestResponse()
            {
                Content = "[ { Id: 1, Type: type }"
            };
        }

        [TestClass]
        public class Telemetry
        {
            public static IRestResponse Response = new RestResponse()
            {
                Content = "{ }"
            };
        }

        public static bool AssertParameters(RestRequest request)
        {
            if (request.Parameters.Count != HeaderCount) return false;
            foreach (KeyValuePair<string, string> entry in ExpectedHeaders)
            {
                if(request.Parameters.SingleOrDefault(p => 
                    p.Name == entry.Key && 
                    (string)p.Value == entry.Value) == null)
                    return false;
            }
            return true;
        }

        public class Arrangement
        {
            public static RequestService GetInstance(Mock<IRestClient> client)
            {
                var svc = new RequestService(ApiKey)
                {
                    // Replace existing client with mocked one.
                    // TODO: Do this in a way that doesn't require exposing client.
                    Client = client.Object
                };
                return svc;
            }
        }
    }
}
