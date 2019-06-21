using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

    /// <summary>
    /// Rosters track the scores of each opposing group of participants. 
    /// Rosters can have one or many participants depending on the game mode.
    /// </summary>
    /// <remarks>
    /// Roster objects are only meaningful within the context of a match
    /// and are not exposed as a standalone resource.
    /// </remarks>
    public class Roster
    {
        /// <summary>
        /// A randomly generated ID assigned to this resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Indicates if this roster won the match.
        /// </summary>
        public bool Won { get; set; }

        /// <summary>
        /// Platform shard.
        /// </summary>
        public string Shard { get; set; }

        /// <summary>
        /// This roster's placement in the match.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// An arbitrary ID assigned to this roster.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// A list of Participant IDs.
        /// </summary>
        public List<string> ParticipantIds { get; set; }
    }

    public class TelemetryAsset
    {
        /// <summary>
        /// A randomly generated ID assigned to this resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Time of telemetry creation.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Link to the telemetry.json file.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// "Telemetry".
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }
    }

    /// <summary>
    /// Participant objects represent a player in the context of a match. 
    /// </summary>
    /// <remarks>
    /// Participant objects are only meaningful within the context of a match
    /// and are not exposed as a standalone resource.
    /// </remarks>
    public class Participant
    {
        /// <summary>
        /// A randomly generated ID assigned to this resource object.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// PUBG IGN of the player associated with this participant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Account ID of the player associated with this participant.
        /// </summary>
        public string PlayerId { get; set; }

        /// <summary>
        /// Platform shard.
        /// </summary>
        public string Shard { get; set; }

        public string Actor { get; set; }

        /// <summary>
        /// Number of enemy players knocked.
        /// </summary>
        public int DBNOs { get; set; }

        /// <summary>
        /// Number of enemy players this player damaged that were killed by teammates.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Number of boost items used.
        /// </summary>
        public int Boosts { get; set; }

        /// <summary>
        /// Total damage dealt. 
        /// Note: Self inflicted damage is subtracted.
        /// </summary>
        public double DamageDealt { get; set; }

        /// <summary>
        /// The way by which this player died, or alive if they didn't.
        /// </summary>
        /// <remarks>
        /// TODO: Enum [ alive, byplayer, suicide, logout ]
        /// </remarks>
        public string DeathType { get; set; }

        /// <summary>
        /// Number of enemy players killed with headshots.
        /// </summary>
        public int HeadshotKills { get; set; }

        /// <summary>
        /// Number of healing items used.
        /// </summary>
        public int Heals { get; set; }

        /// <summary>
        /// This player's rank in the match based on kills.
        /// </summary>
        public int KillPlace { get; set; }

        /// <summary>
        /// Total number of kill streaks.
        /// </summary>
        public int KillStreaks { get; set; }

        /// <summary>
        /// Number of enemy players killed.
        /// </summary>
        public int Kills { get; set; }

        public double LongestKill { get; set; }
        
        /// <summary>
        /// Number of times this player revived teammates.
        /// </summary>
        public int Revives { get; set; }

        /// <summary>
        /// Total distance traveled in vehicles measured in meters.
        /// </summary>
        public double RideDistance { get; set; }

        /// <summary>
        /// Number of kills while in a vehicle.
        /// </summary>
        public int RoadKills { get; set; }

        /// <summary>
        /// Total distance traveled while swimming measured in meters.
        /// </summary>
        public int SwimDistance { get; set; }
        
        /// <summary>
        /// Number of times this player killed a teammate.
        /// </summary>
        public int TeamKills { get; set; }

        /// <summary>
        /// Amount of time survived measured in seconds.
        /// </summary>
        public double TimeSurvived { get; set; }

        /// <summary>
        /// Number of vehicles destroyed.
        /// </summary>
        public int VehicleDestroys { get; set; }

        /// <summary>
        /// Total distance traveled on foot measured in meters.
        /// </summary>
        public double WalkDistance { get; set; }

        /// <summary>
        /// Number of weapons picked up.
        /// </summary>
        public int WeaponsAcquired { get; set; }

        /// <summary>
        /// This player's placement in the match.
        /// </summary>
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
