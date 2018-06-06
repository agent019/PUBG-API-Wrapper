using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestProject.Models;
using TestProject.RestWrapper;

namespace TestProject
{
    /// <summary>
    /// Service for making requests to the PUBG API.
    /// Wraps all provided endpoints.
    /// </summary>
    /// <remarks>
    /// TODO: dynamically construct "/shards/{shard}"
    /// </remarks>
    public class RequestService
    {
        private const string BaseUri = "https://api.playbattlegrounds.com/";

        private string ApiKey { get; set; }
        private Client Client { get; set; }

        #region Constructors

        public RequestService(string key)
        {
            Client = new Client(BaseUri);
            this.ApiKey = key;
        }

        #endregion

        private Response MakeRequest(string queryString, bool compressResponse = false)
        {
            Request request = new Request(queryString);

            request.AddHeader("Authorization", "Bearer " + ApiKey);
            request.AddHeader("Accept", "application/vnd.api+json");

            if (compressResponse)
                request.AddHeader("Accept-Encoding", "gzip");


            Response response = Client.Execute(request);

            Console.WriteLine(response);

            return response;
        }

        #region Status

        /// <summary>
        /// Gets the status of the PUBG Api.
        /// </summary>
        public Status GetStatus()
        {
            string statusUri = "/status";
            Response response = MakeRequest(statusUri);

            Status status = Status.Deserialize(response.Content);
            return status;
        }

        #endregion

        #region Matches

        /// <summary>
        /// Gets a PUBG match by ID.
        /// </summary>
        public Match GetMatch(string matchId)
        {
            string matchUri = "/shards/pc-na/matches/" + matchId;
            Response response = MakeRequest(matchUri);

            Match match = Match.Deserialize(response.Content);
            return match;
        }

        public Sample GetSampleMatches(DateTime createdAtFilter)
        {
            string sampleUri = "/shards/pc-na/samples";
            Response response = MakeRequest(sampleUri);

            Sample sample = Sample.Deserialize(response.Content);
            return sample;
        }

        #endregion

        #region Players

        /// <summary>
        /// Given a players username, gets the Id associated for that account.
        /// </summary>
        public string GetPlayerId(string playerName)
        {
            string playerUri = "shards/pc-na/players?filter[playerNames]=" + playerName;
            Response response = MakeRequest(playerUri);

            JObject obj = JObject.Parse(response.Content);
            return (string)obj["data"][0]["id"];
        }

        /// <summary>
        /// Makes a request to the PUBG API for information about a player, by player id.
        /// </summary>
        public Player GetPlayer(string id)
        {
            string playerUri = "shards/pc-na/players/" + id;
            Response response = MakeRequest(playerUri);
            Player player = Player.Deserialize(response.Content);
            return player;
        }

        /// <summary>
        /// Given a list of player ids or player names, queries for those players
        /// </summary>
        /// <remarks>
        /// Cannot query by both names and ids. Prefers ids when provided.
        /// </remarks>
        public List<Player> GetPlayers(List<string> ids, List<string> names)
        {
            if ((ids == null || !ids.Any()) && (names == null || !names.Any()))
                return new List<Player>();

            string playerUri = "shards/pc-na/players";
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

            Response response = MakeRequest(playerUri);

            List<Player> players = Player.DeserializePlayerList(response.Content);
            return players;
        }

        public dynamic GetPlayerSeason(string id, string seasonId)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Makes a request to the PUBG Api for all of the seasons.
        /// </summary>
        public List<Season> GetSeasons()
        {
            string seasonUri = "/shards/pc-na/seasons";
            Response response = MakeRequest(seasonUri);
            List<Season> seasons = Season.Deserialize(response.Content);
            return seasons;
        }

        /// <summary>
        /// Given a telemetry URL from a match object,
        /// Makes a request to the PUBG API for that telemetry object.
        /// </summary>
        public Telemetry GetTelemetry(string url)
        {
            Response response = MakeRequest(url);
            Telemetry telemetry = Telemetry.Deserialize(response.Content);
            return telemetry;
        }

        /// <summary>
        /// Writes the given string to the given filename in the Data folder.
        /// </summary>
        public void WriteResponse(string filename, string body)
        {
            File.WriteAllText("../../../Data/" + filename, body);
        }
    }
}
