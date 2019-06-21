using Newtonsoft.Json.Linq;
using PUBGAPIWrapper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace PUBGAPIWrapper
{
    /// <summary>
    /// Service for making requests to the PUBG API.
    /// Wraps all provided endpoints.
    /// </summary>
    /// <remarks>
    /// TODO: Tournaments resource
    /// </remarks>
    public class RequestService
    {
        private const string BaseUri = "https://api.playbattlegrounds.com/";

        private string ApiKey { get; set; }
        public IRestClient Client { get; set; }

        private const string RateLimitRemainingHeaderName = "X-Ratelimit-Remaining";
        private const string RateLimitResetHeaderName = "X-Ratelimit-Reset";

        #region Constructors

        public RequestService(string key)
        {
            Client = new RestClient(BaseUri);
            this.ApiKey = key;
        }

        #endregion

        #region Helpers

        private IRestResponse MakeRequest(string queryString/*, bool compressResponse = false*/)
        {
            IRestRequest request = new RestRequest(queryString);

            request.AddHeader("Authorization", "Bearer " + ApiKey);

            /*if (compressResponse)
                request.AddHeader("Accept-Encoding", "gzip");
            else*/
            request.AddHeader("Accept", "application/vnd.api+json");

            IRestResponse response = Client.Execute(request);

            return response;
        }

        /// <summary>
        /// Given a Shard enum, builds the shard portion of the Uri string for a request.
        /// </summary>
        /// <remarks>
        /// We must do this because C# doesn't allow enums with the '-' character,
        /// so we have to pull the uri-friendly string out of the description of the Shard value.s
        /// </remarks>
        private string BuildShardUri(PlatformRegionShard shard)
        {
            return "/shards/" + shard.GetDescription() + "/";
        }

        /// <summary>
        /// Writes the given string to the given filename in the Data folder.
        /// </summary>
        public void WriteResponse(string filename, string body)
        {
            File.WriteAllText("../../../Data/" + filename, body);
        }



        /// <summary>
        /// Executes rest request with the given request.
        /// </summary> 
        /// <remarks>
        /// Using the rate limit information from the response headers,
        /// sleeps until the rate limit reset when out of requests.
        /// TODO: Async this to not stop the main thread?
        /// TODO: Move this somewhere useful.
        /// </remarks>
        public IRestResponse Execute(IRestRequest request)
        {
            var response = Client.Execute(request);
            if (response.StatusCode == (HttpStatusCode)429) throw new Exception("Rate limited!");

            int? rateLimitRemaining = 0;
            int rateLimitReset = 0;

            try
            {
                rateLimitRemaining = Convert.ToInt32(response.Headers.Where(h => h.Name == RateLimitRemainingHeaderName).Select(h => h.Value).Single());
                rateLimitReset = Convert.ToInt32(response.Headers.Where(h => h.Name == RateLimitResetHeaderName).Select(h => h.Value).Single());
                Console.WriteLine("Requests remaining: " + rateLimitRemaining + "\nRequest reset time: " + rateLimitReset);
            }
            catch (InvalidOperationException)
            {
                rateLimitRemaining = null;
                Console.WriteLine("Rate limit header was missing.");
            }

            if (rateLimitRemaining.HasValue && rateLimitRemaining == 0)
            {
                Console.WriteLine("Rate limited. Sleeping.");
                int now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int secondsUntilReset = rateLimitReset - now;
                Thread.Sleep(secondsUntilReset); // TODO: not this
            }

            return response;
        }

        #endregion

        #region Status

        /// <summary>
        /// Gets the status of the PUBG Api.
        /// </summary>
        public Status GetStatus()
        {
            string statusUri = "/status";
            IRestResponse response = MakeRequest(statusUri);

            Status status = Status.Deserialize(response.Content);
            return status;
        }

        #endregion

        #region Matches

        /// <summary>
        /// Gets a PUBG match by ID.
        /// </summary>
        public Match GetMatch(PlatformRegionShard shard, string matchId)
        {
            string shardUri = BuildShardUri(shard);
            string matchUri = shardUri + "matches/" + matchId;
            IRestResponse response = MakeRequest(matchUri);

            Match match = Match.Deserialize(response.Content);
            return match;
        }

        /// <summary>
        /// Gets a set of sample matches
        /// </summary>
        /// <remarks>
        /// TODO: Implement createdAt filter
        /// </remarks>
        public Sample GetSampleMatches(PlatformRegionShard shard, DateTime? createdAtFilter = null)
        {
            string shardUri = BuildShardUri(shard);
            string sampleUri = shardUri + "samples";
            IRestResponse response = MakeRequest(sampleUri);

            Sample sample = Sample.Deserialize(response.Content);
            return sample;
        }

        #endregion

        #region Players

        /// <summary>
        /// Given a players username, gets the Id associated for that account.
        /// </summary>
        public string GetPlayerId(PlatformRegionShard shard, string playerName)
        {
            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players?filter[playerNames]=" + playerName;
            IRestResponse response = MakeRequest(playerUri);

            JObject obj = JObject.Parse(response.Content);
            return (string)obj["data"][0]["id"];
        }

        /// <summary>
        /// Makes a request to the PUBG API for information about a player, by player id.
        /// Get a single player.
        /// </summary>
        public Player GetPlayer(PlatformRegionShard shard, string id)
        {
            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players/" + id;
            IRestResponse response = MakeRequest(playerUri);
            Player player = Player.Deserialize(response.Content);
            return player;
        }

        /// <summary>
        /// Given a list of player ids or player names, queries for those players
        /// Get a collection of up to 10 players.
        /// </summary>
        /// <remarks>
        /// Cannot query by both names and ids. Prefers ids when provided.
        /// </remarks>
        public List<Player> GetPlayers(PlatformRegionShard shard, List<string> ids, List<string> names)
        {
            if ((ids == null || !ids.Any()) && (names == null || !names.Any()))
                return new List<Player>();

            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players";
            if (ids != null && ids.Any())
            {
                string concatenatedIds = string.Join(",", ids);
                playerUri = playerUri + "filters[playerIds]" + concatenatedIds;
            }
            else if (names != null && names.Any())
            {
                string concatenatedNames = string.Join(",", names);
                playerUri = playerUri + "filters[playerIds]" + concatenatedNames;
            }

            IRestResponse response = MakeRequest(playerUri);

            List<Player> players = Player.DeserializePlayerList(response.Content);
            return players;
        }

        public dynamic GetPlayerSeason(string id, string seasonId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Seasons

        /// <summary>
        /// Makes a request to the PUBG Api for all of the seasons.
        /// </summary>
        public List<Season> GetSeasons(PlatformRegionShard shard)
        {
            string shardUri = BuildShardUri(shard);
            string seasonUri = shardUri + "seasons";
            IRestResponse response = MakeRequest(seasonUri);
            List<Season> seasons = Season.Deserialize(response.Content);
            return seasons;
        }

        #endregion

        #region Telemetry

        /// <summary>
        /// Given a telemetry URL from a match object,
        /// Makes a request to the PUBG API for that telemetry object.
        /// </summary>
        public Telemetry GetTelemetry(string url)
        {
            IRestResponse response = MakeRequest(url);
            Telemetry telemetry = Telemetry.Deserialize(response.Content);
            return telemetry;
        }

        #endregion
    }
}
