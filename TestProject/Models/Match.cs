using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Models
{
    public class Match
    {
        public Match()
        {
            Participants = new List<Participant>();
            Rosters = new List<Roster>();
        }

        public string Id { get; set; }
        public DateTime MatchCompletion { get; set; }
        public long Duration { get; set; }
        public string GameMode { get; set; } 
        public string Map { get; set; }
        public string Shard { get; set; }
        public string Title { get; set; }
        public List<string> RosterIds { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Roster> Rosters { get; set; }
        public Telemetry Telemetry { get; set; }

        public override string ToString()
        {
            string matchString = "Id: " + Id + "\n";
            matchString += "Region: " + Shard + "\n";
            matchString += "Duration: " + Duration + "\n";
            matchString += "Match completion: " + MatchCompletion.ToString() + "\n";
            matchString += "Map: " + Map + "\n";
            matchString += "Mode: " + GameMode + "\n";

            return matchString;
        }



        public static Match DeserializeMatch(string matchJson)
        {
            MatchDTO dto = JsonConvert.DeserializeObject<MatchDTO>(matchJson);
            Match match = new Match()
            {
                Id = dto.Data.Id,
                MatchCompletion = DateTime.Parse(dto.Data.Attributes.CreatedAt),
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
    }

    public class Roster
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public int TeamId { get; set; }
        public bool Won { get; set; }
        public List<string> PlayerIds { get; set; }
    }

    public class Participant
    {
        public string Id { get; set; }
        public PlayerStats Stats { get; set; }
    }

    public class PlayerStats
    {
        public int DBNOs { get; set; }
        public int Assists { get; set; }
        public int Boosts { get; set; }
        public decimal DamageDealt { get; set; }
        public string DeathType { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        public int KillPlace { get; set; }
        public int KillPoints { get; set; }
        public decimal KillPointsDelta { get; set; }
        public int KillStreaks { get; set; }
        public int Kills { get; set; }
        public int LastKillPoints { get; set; }
        public int LastWinPoints { get; set; }
        public int LongestKill { get; set; }
        public int MostDamage { get; set; }
        public string Name { get; set; }
        public string PlayerId { get; set; }
        public int Revives { get; set; }
        public decimal RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int TeamKills { get; set; }
        public int TimeSurvived { get; set; }
        public int VehicleDestroys { get; set; }
        public decimal WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WinPlace { get; set; }
        public int WinPoints { get; set; }
        public decimal WinPointsDelta { get; set; }
    }

    public class Telemetry
    {
        public string Id { get; set; }
        public string URL { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    #region DTO

    public class MatchDTO
    {
        public Data Data { get; set; }
        //TODO: Better deserialization then dynamic and second pass
        public List<dynamic> Included { get; set; } 
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

	public class Data {
		public string Type { get; set; }
		public string Id { get; set; }
        public MatchAttributes Attributes { get; set; }
        public Relationships Relationships { get; set; }
        public Links Links { get; set; }
    }

    public class MatchAttributes
    {
        public string CreatedAt { get; set; }
        public long Duration { get; set; }
        public string GameMode { get; set; }
        public string MapName { get; set; }
        public string PatchVersion { get; set; }
        public string ShardId { get; set; }
        public dynamic Stats { get; set; }
        public dynamic Tags { get; set; }
        public string TitleId { get; set; }
    }

    public class Relationships {
        public Assets Assets { get; set; }
        public RosterDTO Rosters { get; set; }
        public Round Rounds { get; set; }
        public Spectator Spectator { get; set; }
    }

    public class Round
    {
        public List<RoundData> Data { get; set; }
    }

    public class RoundData
    { }

    public class Spectator
    {
        public List<SpectatorData> Data { get; set; }
    }

    public class SpectatorData
    { }

    public class RosterDTO
    {
        public List<RosterData> Data { get; set; }
    }

    public class RosterData
    {
        public string Type { get; set; }
        public string Id { get; set; }
    }

	public class Matches {
		public List<Data> Data { get; set; }
	}

	public class Assets {
		public List<Data> Data { get; set; }
	}

	public class PlayerAttributes {
		public string CreatedAt { get; set; }
		public string Name { get; set; }
		public string Actor { get; set; }
		public string ShardId { get; set; }
		public PlayerStats Stats { get; set; }
		public string UpdatedAt { get; set; }
	}

	public class Links
    {
        public string Next { get; set; }
        public string Self { get; set; }
		public string Schema { get; set; }
	}

    public class Meta
    { }

    #endregion
}
