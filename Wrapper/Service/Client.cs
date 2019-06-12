using PUBGAPIWrapper.Interfaces;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace PUBGAPIWrapper.Service
{
    public class Client : IClient
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
            catch (InvalidOperationException)
            {
                RateLimitRemaining = null;
                Console.WriteLine("Rate limit header was missing.");
            }

            if (RateLimitRemaining.HasValue && RateLimitRemaining == 0)
            {
                Console.WriteLine("Rate limited. Sleeping.");
                int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int secondsUntilReset = RateLimitReset - now;
                Thread.Sleep(secondsUntilReset); // TODO: not this
            }

            return response;
        }
    }
}
