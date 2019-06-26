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
    /// TODO: 
    /// - Finish and test these methods
    /// - Event Vehicle, Victim, Assistant can be null. Test these
    /// </remarks>
    public class RequestService
    {
        private const string BaseUri = "https://api.pubg.com/";

        private string ApiKey { get; set; }
        private IRestClient Client { get; set; }

        private const string RateLimitRemainingHeaderName = "X-Ratelimit-Remaining";
        private const string RateLimitResetHeaderName = "X-Ratelimit-Reset";

        #region Constructors

        public RequestService(string key)
        {
            this.Client = new RestClient(BaseUri);
            this.ApiKey = key;
        }

        public RequestService(IRestClient client, string key)
        {
            this.Client = client;
            this.ApiKey = key;
        }

        #endregion

        #region Helpers
        
        /// <summary>
        /// Executes rest request with the given request.
        /// </summary> 
        /// <remarks>
        /// Using the rate limit information from the response headers,
        /// sleeps until the rate limit reset when out of requests.
        /// TODO: Async this to not stop the main thread?
        /// </remarks>
        public IRestResponse ExecuteRequest(IRestRequest request)
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

        private IRestResponse MakeRequest(string queryString/*, bool compressResponse = false*/)
        {
            IRestRequest request = new RestRequest(queryString);

            request.AddHeader("Authorization", "Bearer " + ApiKey);

            /*if (compressResponse)
                request.AddHeader("Accept-Encoding", "gzip");
            else*/
            request.AddHeader("Accept", "application/vnd.api+json");

            IRestResponse response = ExecuteRequest(request);

            return response;
        }

        /// <summary>
        /// Given a Shard enum, builds the shard portion of the Uri string for a request.
        /// </summary>
        /// <remarks>
        /// We must do this because C# doesn't allow enums with the '-' character,
        /// so we have to pull the uri-friendly string out of the description of the Shard value.s
        /// </remarks>
        private string BuildShardUri(PlatformShard shard)
        {
            return "/shards/" + shard.ToString().ToLower() + "/";
        }

        /// <summary>
        /// Writes the given string to the given filename in the Data folder.
        /// </summary>
        public void WriteResponse(string filename, string body)
        {
            File.WriteAllText("../../../Data/" + filename, body);
        }

        #endregion

        #region Players

        /// <summary>
        /// Given a players username, gets the Id associated for that account.
        /// </summary>
        public string GetPlayerId(PlatformShard shard, string playerName)
        {
            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players?filter[playerNames]=" + playerName;
            IRestResponse response = MakeRequest(playerUri);
            return Player.DeserializePlayerList(response.Content)[0].Id;
        }

        /// <summary>
        /// Get a single player.
        /// Makes a request to the PUBG API for information about a player, by player id.
        /// </summary>
        /// <param name="id">The account ID to search for</param>
        public Player GetPlayer(PlatformShard shard, string id)
        {
            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players/" + id;
            IRestResponse response = MakeRequest(playerUri);
            return Player.Deserialize(response.Content);
        }

        /// <summary>
        /// Get a collection of up to 10 players.
        /// Given a list of player ids or player names, queries for those players.
        /// </summary>
        /// <remarks>
        /// Cannot query by both names and ids. Prefers ids when provided.
        /// </remarks>
        /// <param name="ids">Filters by player IDs</param>
        /// <param name="names">Filters by player names</param>
        public List<Player> GetPlayers(PlatformShard shard, List<string> ids, List<string> names)
        {
            if ((ids == null || !ids.Any()) && (names == null || !names.Any()))
                return new List<Player>();

            string shardUri = BuildShardUri(shard);
            string playerUri = shardUri + "players";
            if (ids != null && ids.Any())
            {
                string concatenatedIds = string.Join(",", ids);
                playerUri = playerUri + "?filter[playerIds]=" + concatenatedIds;
            }
            else if (names != null && names.Any())
            {
                string concatenatedNames = string.Join(",", names);
                playerUri = playerUri + "?filter[playerNames]=" + concatenatedNames;
            }

            IRestResponse response = MakeRequest(playerUri);
            return Player.DeserializePlayerList(response.Content);
        }

        #endregion

        #region Seasons

        /// <summary>
        /// Get the list of available seasons.
        /// </summary>
        /// <remarks>
        /// Note: The list of seasons will only be changing about once every 
        /// two months when a new season is added. Applications should not be
        /// querying for the list of seasons more than once per month.
        /// </remarks>
        public List<Season> GetSeasons(PlatformShard shard)
        {
            string shardUri = BuildShardUri(shard);
            string seasonUri = shardUri + "seasons";
            IRestResponse response = MakeRequest(seasonUri);
            return Season.Deserialize(response.Content);
        }

        #endregion

        #region Stats

        /// <summary>
        /// Get season information for a single player.
        /// </summary>
        /// <param name="accountId">The account ID to search for.</param>
        /// <param name="seasonId">The season ID to search for.</param>
        public Stats GetSeasonStatsForPlayer(PlatformShard shard, string accountId, string seasonId)
        {
            string shardUri = BuildShardUri(shard);
            string statsUri = shardUri + "players/" + accountId + "/seasons/" + seasonId;
            IRestResponse response = MakeRequest(statsUri);
            return Stats.Deserialize(response.Content);
        }

        /// <summary>
        /// Get season information for up to 10 players.
        /// </summary>
        /// <param name="seasonId">The season ID to search for.</param>
        /// <param name="gameMode">The game mode to search for.</param>
        /// <param name="playerIds">Filters by player IDs.</param>
        public List<Stats> GetSeasonStatsForMultiplePlayers(PlatformShard shard, string seasonId, string gameMode, List<string> playerIds)
        {
            string shardUri = BuildShardUri(shard);
            string statsUri = shardUri + "seasons/" + seasonId + "/gamemode" + gameMode
                + "/players?filter[playerIds]=" + String.Join(",", playerIds);
            IRestResponse response = MakeRequest(statsUri);
            return Stats.DeserializeList(response.Content);
        }

        /// <summary>
        /// Get lifetime stats for a single player.
        /// </summary>
        /// <param name="accountId">The account ID to search for.</param>
        public Stats GetLifetimeStatsForPlayer(PlatformShard shard, string accountId)
        {
            return GetSeasonStatsForPlayer(shard, accountId, "lifetime");
        }

        /// <summary>
        /// Get lifetime stats for up to 10 players.
        /// </summary>
        /// <param name="gameMode">The game mode to search for.</param>
        /// <param name="playerIds">Filters by player IDs.</param>
        public List<Stats> GetLifetimeStatsForMultiplePlayers(PlatformShard shard, string gameMode, List<string> playerIds)
        {
            return GetSeasonStatsForMultiplePlayers(shard, "lifetime", gameMode, playerIds);
        }

        #endregion

        #region Matches

        /// <summary>
        /// Gets a PUBG match by ID.
        /// </summary>
        public Match GetMatch(PlatformShard shard, string matchId)
        {
            string shardUri = BuildShardUri(shard);
            string matchUri = shardUri + "matches/" + matchId;
            IRestResponse response = MakeRequest(matchUri);
            return Match.Deserialize(response.Content);
        }

        /// <summary>
        /// Gets a set of sample matches
        /// </summary>
        /// <remarks>
        /// The number of matches per shard may vary. Requests for samples 
        /// need to be at least 24hrs in the past UTC time using the 
        /// filter[createdAt-start] query parameter. The default if not 
        /// specified is the latest sample.
        /// </remarks>
        /// <param name="createdAtFilter">The starting search date in UTC. Null by default.</param>
        public Sample GetSampleMatches(PlatformShard shard, DateTime? createdAtFilter = null)
        {
            string shardUri = BuildShardUri(shard);
            string sampleUri = shardUri + "samples";

            if (createdAtFilter != null)
            {
                sampleUri += "?filter[createdAt-start]=" + createdAtFilter.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            IRestResponse response = MakeRequest(sampleUri);
            return Sample.Deserialize(response.Content);
        }

        #endregion

        #region Leaderboards

        /// <summary>
        /// Get the leaderboard for a game mode.
        /// </summary>
        /// <param name="gameMode">The game mode to search for.</param>
        /// <param name="page">The leaderboard page to search for.</param>
        public Leaderboard GetLeaderboard(PlatformShard shard, string gameMode, int page)
        {
            string shardUri = BuildShardUri(shard);
            string leaderboardUri = shardUri + "leaderboards/"
                + gameMode + "?page[number]=" + page;
            IRestResponse response = MakeRequest(leaderboardUri);
            return Leaderboard.Deserialize(response.Content);
        }

        #endregion

        #region Tournaments

        /// <summary>
        /// Get the list of available tournaments.
        /// </summary>
        public List<Tournament> GetTournamentsList()
        {
            string tournamentUri = "/tournaments";
            IRestResponse response = MakeRequest(tournamentUri);
            return Tournament.Deserialize(response.Content);
        }

        /// <summary>
        /// Get information for a single tournament.
        /// </summary>
        /// <remarks>
        /// Tournament matches can be retreived from the /matches endpoint
        /// using the pc-tournament shard
        /// </remarks>
        /// <param name="id">The ID to search for.</param>
        public TournamentMatches GetTournament(string id)
        {
            string tournamentMatchesUri = "/tournaments/" + id;
            IRestResponse response = MakeRequest(tournamentMatchesUri);
            return TournamentMatches.Deserialize(response.Content);
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
            return Telemetry.Deserialize(response.Content);
        }

        #endregion

        #region Status

        /// <summary>
        /// Check the status of the API.
        /// </summary>
        /// <remarks>
        /// The status endpoint can be called to verify that the API is up and running. 
        /// </remarks>
        public Status GetStatus()
        {
            string statusUri = "/status";
            IRestResponse response = MakeRequest(statusUri);
            return Status.Deserialize(response.Content);
        }

        #endregion
    }
}
