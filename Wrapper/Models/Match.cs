using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Verify the Match objects deserialize correctly
namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Represents a PUBG match.
    /// Match objects contain information about a completed match such as the 
    /// game mode played, duration, and which players participated.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
    /// </remarks>
    public class Match
    {
        public Match()
        {
            Participants = new List<Participant>();
            Rosters = new List<Roster>();
        }

        /// <summary>
        /// Match ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Time this match object was stored in the API.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Length of the match measured in seconds.
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Game mode played.
        /// </summary>
        public string GameMode { get; set; }

        /// <summary>
        /// Map name.
        /// </summary>
        public string Map { get; set; }

        /// <summary>
        /// True if this match is a custom match.
        /// </summary>
        public bool IsCustomMatch { get; set; }

        /// <summary>
        /// The state of the season.
        /// </summary>
        public string SeasonState { get; set; }

        /// <summary>
        /// Platform shard.
        /// </summary>
        public string Shard { get; set; }

        /// <summary>
        /// Identifies the studio and game.
        /// </summary>
        public string Title { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Roster> Rosters { get; set; }
        public TelemetryAsset Telemetry { get; set; }

        public override string ToString()
        {
            string matchString = "Id: " + Id + "\n";
            matchString += "Region: " + Shard + "\n";
            matchString += "Duration: " + Duration + "\n";
            matchString += "Created: " + Created.ToString() + "\n";
            matchString += "Map: " + Map + "\n";
            matchString += "Mode: " + GameMode + "\n";

            return matchString;
        }

        public static Match Deserialize(string matchJson)
        {
            MatchDTO dto = JsonConvert.DeserializeObject<MatchDTO>(matchJson);
            Match match = new Match()
            {
                Id = dto.Data.Id,
                Created = dto.Data.Attributes.Created,
                Duration = dto.Data.Attributes.Duration,
                GameMode = dto.Data.Attributes.GameMode,
                Map = dto.Data.Attributes.MapName,
                IsCustomMatch = dto.Data.Attributes.IsCustomMatch,
                SeasonState = dto.Data.Attributes.SeasonState,
                Shard = dto.Data.Attributes.Shard,
                Title = dto.Data.Attributes.Title,
            };

            foreach (dynamic obj in dto.Included)
            {
                switch ((string)obj.type)
                {
                    case "roster":
                        MatchRoster matchRoster = obj.ToObject<MatchRoster>();
                        Roster r = new Roster()
                        {
                            Id = matchRoster.Id,
                            Shard = matchRoster.Attributes.Shard,
                            Won = matchRoster.Attributes.Won,
                            Rank = matchRoster.Attributes.Stats.Rank,
                            TeamId = matchRoster.Attributes.Stats.TeamId,
                            ParticipantIds = matchRoster.Relationships.Participants.Data.Select(x => x.Id).ToList()
                        };
                        match.Rosters.Add(r);
                        break;
                    case "participant":
                        MatchParticipant participant = obj.ToObject<MatchParticipant>();
                        Participant p = new Participant()
                        {
                            Id = participant.Id,
                            Shard = participant.Attributes.Shard,
                            Actor = participant.Attributes.Actor,
                            DBNOs = participant.Attributes.Stats.DBNOs,
                            Assists = participant.Attributes.Stats.Assists,
                            Boosts = participant.Attributes.Stats.Boosts,
                            DamageDealt = participant.Attributes.Stats.DamageDealt,
                            DeathType = participant.Attributes.Stats.DeathType,
                            HeadshotKills = participant.Attributes.Stats.HeadshotKills,
                            Heals = participant.Attributes.Stats.Heals,
                            KillPlace = participant.Attributes.Stats.KillPlace,
                            Kills = participant.Attributes.Stats.KillStreaks,
                            KillStreaks = participant.Attributes.Stats.Kills,
                            LongestKill = participant.Attributes.Stats.LongestKill,
                            Name = participant.Attributes.Stats.Name,
                            PlayerId = participant.Attributes.Stats.PlayerId,
                            Revives = participant.Attributes.Stats.Revives,
                            RideDistance = participant.Attributes.Stats.RideDistance,
                            RoadKills = participant.Attributes.Stats.RoadKills,
                            SwimDistance = participant.Attributes.Stats.SwimDistance,
                            TeamKills = participant.Attributes.Stats.TeamKills,
                            TimeSurvived = participant.Attributes.Stats.TimeSurvived,
                            VehicleDestroys = participant.Attributes.Stats.VehicleDestroys,
                            WalkDistance = participant.Attributes.Stats.WalkDistance,
                            WeaponsAcquired = participant.Attributes.Stats.WeaponsAcquired,
                            WinPlace = participant.Attributes.Stats.WinPlace
                        };
                        match.Participants.Add(p);
                        break;
                    case "asset":
                        MatchAsset matchAsset = obj.ToObject<MatchAsset>();
                        TelemetryAsset t = new TelemetryAsset()
                        {
                            Id = matchAsset.Id,
                            Created = matchAsset.Attributes.Created,
                            URL = matchAsset.Attributes.URL,
                            Name = matchAsset.Attributes.Name,
                            Description = matchAsset.Attributes.Description
                        };
                        match.Telemetry = t;
                        break;
                    default:
                        throw new NotImplementedException("match.included contained object of type " + obj.type);
                }
            }

            match.Rosters.OrderBy(x => x.Rank);

            return match;
        }
    }

    public class Roster
    {
        public string Id { get; set; }
        public bool Won { get; set; }
        public string Shard { get; set; }
        public int Rank { get; set; }
        public int TeamId { get; set; }
        public List<string> ParticipantIds { get; set; }
    }

    public class TelemetryAsset
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Participant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlayerId { get; set; }
        public string Shard { get; set; }
        public string Actor { get; set; }
        public int DBNOs { get; set; }
        public int Assists { get; set; }
        public int Boosts { get; set; }
        public double DamageDealt { get; set; }
        public string DeathType { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        public int KillPlace { get; set; }
        public int KillStreaks { get; set; }
        public int Kills { get; set; }
        public double LongestKill { get; set; }
        public int Revives { get; set; }
        public double RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int SwimDistance { get; set; }
        public int TeamKills { get; set; }
        public double TimeSurvived { get; set; }
        public int VehicleDestroys { get; set; }
        public double WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WinPlace { get; set; }
    }

    #region DTO

    public class MatchDTO
    {
        public MatchData Data { get; set; }
        //TODO: Better deserialization then dynamic and second pass
        public List<dynamic> Included { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class MatchData {
        public string Type { get; set; }
        public string Id { get; set; }
        public MatchAttributes Attributes { get; set; }
        public MatchRelationships Relationships { get; set; }
        public Links Links { get; set; }
    }

    public class MatchAttributes
    {
        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }
        public long Duration { get; set; }
        public string GameMode { get; set; }
        public string MapName { get; set; }
        public bool IsCustomMatch { get; set; }
        public string SeasonState { get; set; }
        [JsonProperty("shardId")]
        public string Shard { get; set; }
        // Dynamic because api returns null in all cases, for now
        public dynamic Stats { get; set; }
        // Dynamic because api returns null in all cases, for now
        public dynamic Tags { get; set; }
        [JsonProperty("titleId")]
        public string Title { get; set; }
    }

    public class MatchRelationships {
        public MultiRelationship Assets { get; set; }
        public MultiRelationship Rosters { get; set; }
        public MultiRelationship Rounds { get; set; }
        public MultiRelationship Spectator { get; set; }
    }

    public class MatchParticipant
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public ParticipantAttributes Attributes { get; set; }
    }

    public class ParticipantAttributes
    {
        [JsonProperty("ShardId")]
        public string Shard { get; set; }
        public string Actor { get; set; }
        public ParticipantStats Stats { get; set; }
    }

    // TODO: some of these are probably not ints
    public class ParticipantStats
    {
        public int DBNOs { get; set; }
        public int Assists { get; set; }
        public int Boosts { get; set; }
        public double DamageDealt { get; set; }
        public string DeathType { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        public int KillPlace { get; set; }
        public int KillStreaks { get; set; }
        public int Kills { get; set; }
        public double LongestKill { get; set; }
        public string Name { get; set; }
        public string PlayerId { get; set; }
        public int Revives { get; set; }
        public double RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int SwimDistance { get; set; }
        public int TeamKills { get; set; }
        public double TimeSurvived { get; set; }
        public int VehicleDestroys { get; set; }
        public double WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WinPlace { get; set; }
    }

    public class MatchRoster
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public RosterAttributes Attributes { get; set; }
        public RosterRelationships Relationships { get; set; }
    }

    public class RosterAttributes
    {
        public bool Won { get; set; }
        [JsonProperty("ShardId")]
        public string Shard { get; set; }
        public RosterStats Stats { get; set; }
    }

    public class RosterStats
    {
        public int Rank { get; set; }
        public int TeamId { get; set; }
    }

    public class RosterRelationships
    {
        public RosterTeam Team { get; set; }
        public MultiRelationship Participants { get; set; }
    }

    public class RosterTeam
    {
        public dynamic Data { get; set; }
    }
    
    public class MatchAsset
    {
        /// <summary>
        /// ID for this asset
        /// </summary>
        public string Id { get; set; }
        public string Type { get; set; }
        public AssetAttributes Attributes { get; set; }
    }

    public class AssetAttributes
    {
        /// <summary>
        /// URL to an endpoint containing all the telemetry data for a match.
        /// </summary>
        public string URL { get; set; }
        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    #endregion
}
