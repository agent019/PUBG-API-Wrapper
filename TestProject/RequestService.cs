using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using TestProject.Models;
using TestProject.RestWrapper;

namespace TestProject
{
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

        #region Status

        public void GetStatus()
        {
            string statusUri = "/status";
            Request request = new Request(statusUri);

            request.AddHeader("Authorization", ApiKey);
            request.AddHeader("Accept", "application/vnd.api+json");

            Response response = Client.Execute(request);

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            Console.WriteLine();
            Console.Write("Body: ");
            File.WriteAllText("../../../Data/status.json", response.Content);
            Console.WriteLine("written");

            Status status = BuildStatusFromResponse(response.Content);
            Console.WriteLine(status.ToString());
            Console.ReadLine();
        }

        public Status BuildStatusFromResponse(string statusJson)
        {
            StatusDTO dto = JsonConvert.DeserializeObject<StatusDTO>(statusJson);
            Status s = new Status()
            {
                Id = dto.Data.Id,
                Released = DateTime.Parse(dto.Data.Attributes.ReleasedAt),
                Version = dto.Data.Attributes.Version
            };
            return s;
        }

        #endregion

        #region Matches

        public void GetMatch(string matchId)
        {
            string matchUri = "/shards/pc-na/matches/" + matchId;
            Request request = new Request(matchUri);

            request.AddHeader("Authorization", ApiKey);
            request.AddHeader("Accept", "application/vnd.api+json");

            Response response = Client.Execute(request);

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            Console.WriteLine();
            Console.Write("Body: ");
            //File.WriteAllText("../../../Data/matchdata.json", response.Content);
            Console.WriteLine("written");

            Match match = BuildMatchFromResponse(response.Content);
            Console.WriteLine(match.ToString());
            Console.ReadLine();
        }

        public Match BuildMatchFromResponse(string matchJson)
        {
            MatchDTO dto = JsonConvert.DeserializeObject<MatchDTO>(matchJson);
            Match match = new Match()
            {
                Id = dto.Data.Id,
                MatchStart = DateTime.Parse(dto.Data.Attributes.CreatedAt),
                Duration = dto.Data.Attributes.Duration,
                GameMode = dto.Data.Attributes.GameMode,
                Map = dto.Data.Attributes.MapName,
                Shard = dto.Data.Attributes.ShardId,
                Title = dto.Data.Attributes.TitleId,
                RosterIds = dto.Data.Relationships.Rosters.Data.Select(x => x.Id).ToList()
            };

            foreach (dynamic obj in dto.Included)
            {
                switch ((string)obj.type)
                {
                    case "roster":
                        Roster r = new Roster()
                        {
                            Id = obj.id,
                            Rank = obj.attributes.stats.rank,
                            TeamId = obj.attributes.stats.teamId,
                            Won = obj.attributes.won,
                            //PlayerIds = obj.relationships.participants.data.Select(x => x.id)
                        };
                        match.Rosters.Add(r);
                        break;
                    case "participant":
                        Participant p = new Participant()
                        {
                            Id = obj.id,
                            Stats = new PlayerStats()
                            {
                                DBNOs = obj.attributes.stats.DBNOs,
                                Assists = obj.attributes.stats.assists,
                                Boosts = obj.attributes.stats.boosts,
                                DamageDealt = obj.attributes.stats.damageDealt,
                                DeathType = obj.attributes.stats.deathType,
                                HeadshotKills = obj.attributes.stats.headshotKills,
                                Heals = obj.attributes.stats.heals,
                                KillPlace = obj.attributes.stats.killPlace,
                                KillPoints = obj.attributes.stats.killPoints,
                                KillPointsDelta = obj.attributes.stats.killPointsDelta,
                                Kills = obj.attributes.stats.killStreaks,
                                KillStreaks = obj.attributes.stats.kills,
                                LastKillPoints = obj.attributes.stats.lastKillPoints,
                                LastWinPoints = obj.attributes.stats.lastWinPoints,
                                LongestKill = obj.attributes.stats.longestKill,
                                MostDamage = obj.attributes.stats.mostDamage,
                                Name = obj.attributes.stats.name,
                                PlayerId = obj.attributes.stats.playerId,
                                Revives = obj.attributes.stats.revives,
                                RideDistance = obj.attributes.stats.rideDistance,
                                RoadKills = obj.attributes.stats.roadKills,
                                TeamKills = obj.attributes.stats.teamKills,
                                TimeSurvived = obj.attributes.stats.timeSurvived,
                                VehicleDestroys = obj.attributes.stats.vehicleDestroys,
                                WalkDistance = obj.attributes.stats.walkDistance,
                                WeaponsAcquired = obj.attributes.stats.weaponsAcquired,
                                WinPlace = obj.attributes.stats.winPlace,
                                WinPoints = obj.attributes.stats.winPoints,
                                WinPointsDelta = obj.attributes.stats.winPointsDelta,

                            }
                        };
                        match.Participants.Add(p);
                        break;
                    case "asset": // Garbage. If more then one of these exists (which is possible), it will overwrite the old with the new
                        Telemetry t = new Telemetry()
                        {
                            Id = obj.id,
                            URL = obj.attributes.URL,
                            Description = obj.attributes.description,
                            Created = DateTime.Parse((string)obj.attributes.createdAt),
                            Name = obj.attributes.name
                        };
                        match.Telemetry = t;
                        break;
                    default:
                        throw new NotImplementedException("match.included contained object of type " + obj.type);
                }
            }

            return match;
        }

        #endregion

        #region Players

        /// <summary>
        /// Given a players username, gets the Id associated for that account.
        /// </summary>
        public string GetPlayerId(string playerName)
        {
            Console.WriteLine("Spinning up rest request...");
            string queryEndpoint = "shards/pc-na/players?filter[playerNames]=" + playerName;
            Request request = new Request(queryEndpoint);

            request.AddHeader("Authorization", ApiKey);
            request.AddHeader("Accept", "application/vnd.api+json");

            Console.WriteLine("Firing off rest request...");
            Response response = Client.Execute(request);
            Console.WriteLine();

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            JObject obj = JObject.Parse(response.Content);
            return (string)obj["data"][0]["id"];
        }

        /// <summary>
        /// Makes a request to the pubg API for information about a player, by player id.
        /// </summary>
        public void GetPlayer(string id)
        {
            Console.WriteLine("Spinning up rest request...");
            string queryEndpoint = "shards/pc-na/players/" + id;
            Request request = new Request(queryEndpoint);
			
			request.AddHeader("Authorization", ApiKey);
			request.AddHeader("Accept", "application/vnd.api+json");

            Console.WriteLine("Firing off rest request...");
            Response response = Client.Execute(request);
            Console.WriteLine();

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            Console.WriteLine();
            Console.Write("Body: ");
            File.WriteAllText("../../../Data/playerdata.json", response.Content);
            Console.WriteLine("written");

            Player player = BuildPlayerFromResponse(response.Content);
            Console.WriteLine(player.ToString());
            Console.ReadLine();
        }

        public Player BuildPlayerFromResponse(string playerJson)
        {
            PlayerDTO dto = JsonConvert.DeserializeObject<PlayerDTO>(playerJson);
            Player player = new Player()
            {
                Id = dto.Data.Id,
                Created = DateTime.Parse(dto.Data.Attributes.Created),
                Name = dto.Data.Attributes.Name,
                Version = dto.Data.Attributes.Version,
                Shard = dto.Data.Attributes.Shard,
                Title = dto.Data.Attributes.Title,
                Updated = DateTime.Parse(dto.Data.Attributes.Updated),
                MatchIds = dto.Data.Relationships.Matches.Data.Select(x => x.Id).ToList()
            };

            return player;
        }

        #endregion
    }
}
