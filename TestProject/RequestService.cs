using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using TestProject.Models;
using Newtonsoft.Json;
using System.Configuration;

namespace TestProject
{
    public class RequestService
    {
        private string ApiKey { get; set; }

        public RequestService()
        {
            ApiKey = ConfigurationManager.AppSettings["apiKey"];
        }

        /// <summary>
        /// Loads fake match data from a file into a string for testing purposes
        /// </summary>
        /// <remarks>
        /// Temporary
        /// </remarks>
        public string LoadFakeMatchData()
        {
            using (StreamReader r = new StreamReader("../../../SampleData/pc-match.json"))
            {
                return r.ReadToEnd();
            }
        }

        /// <summary>
        /// Instantiates a mock RestClient that returns a response with test content
        /// </summary>
        public IRestClient InstantiateMockRestClient()
        {
            string sampleResponseContent = LoadFakeMatchData();
            IRestResponse sampleResponse = new RestResponse();
            sampleResponse.StatusCode = HttpStatusCode.OK;
            sampleResponse.StatusDescription = HttpStatusCode.OK.ToString();
            sampleResponse.Content = sampleResponseContent;
            sampleResponse.ContentType = "application/json";

            Mock<IRestClient> mockClient = new Mock<IRestClient>();
            mockClient.Setup(x => x.Execute(It.IsAny<RestRequest>())).Returns(sampleResponse);
            return mockClient.Object;
        }

        /// <summary>
        /// Makes a request to the pubg API.
        /// </summary>
        /// <remarks>
        /// For now, this mocks out a client and a request, which returns
        /// the sample data provided by the developers on the pubg data
        /// </remarks>
		/// 
        public void MakePlayerRequest(string[] playerNames)
        {
			

            Console.WriteLine("Spinning up rest request...");
			RestClient client = new RestClient("https://api.playbattlegrounds.com/");
			//IRestClient client = InstantiateMockRestClient();

			string queryEndpoint = "shards/pc-na/players?filter[playerNames]=";
			foreach (string name in playerNames) {
				queryEndpoint += name+",";
			}
			RestRequest request = new RestRequest(queryEndpoint);
			
			request.AddHeader("Authorization", ApiKey);
			request.AddHeader("Accept", "application/vnd.api+json");

			Console.WriteLine("Firing off rest request...");
            IRestResponse response = client.Execute(request);
			Console.WriteLine();

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            Console.WriteLine();
            Console.WriteLine("Body:");
            Console.WriteLine(response.Content);

			ResponseObject body = JsonConvert.DeserializeObject<ResponseObject>(response.Content);
			Console.WriteLine();
			foreach (Data player in body.Data) {
				Console.WriteLine(player.Id);
				foreach (Data match in player.Relationships.Matches.Data) {
					Console.WriteLine(match.Id);
				}
				Console.WriteLine();
			}
			
			Console.ReadLine();
        }
    }
}
