using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a players stats.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
    /// </remarks>
    public class Stats
    {
        /// <summary>
        /// Account Id of the player whose stats these are.
        /// Of the form "account.<ID>"
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of the season represented by these stats.
        /// </summary>
        /// <remarks>
        /// If representing overall stats, will be "lifetime".
        /// </remarks>
        public string SeasonId { get; set; }

        /// <summary>
        /// Stats from solo third-person perspective games in the given season.
        /// </summary>
        public GameModeStats SoloTPP { get; set; }

        /// <summary>
        /// Stats from duo third-person perspective games in the given season.
        /// </summary>
        public GameModeStats DuoTPP { get; set; }

        /// <summary>
        /// Stats from squad third-person perspective games in the given season.
        /// </summary>
        public GameModeStats SquadTPP { get; set; }

        /// <summary>
        /// Stats from solo first-person perspective games in the given season.
        /// </summary>
        public GameModeStats SoloFPP { get; set; }

        /// <summary>
        /// Stats from duo first-person perspective games in the given season.
        /// </summary>
        public GameModeStats DuoFPP { get; set; }

        /// <summary>
        /// Stats from squad first-person perspective games in the given season.
        /// </summary>
        public GameModeStats SquadFPP { get; set; }

        /// <summary>
        /// List of match Ids from solo third-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> SoloTPPMatchIds { get; set; }

        /// <summary>
        /// List of match Ids from duo third-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> DuoTPPMatchIds { get; set; }

        /// <summary>
        /// List of match Ids from squad third-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> SquadTPPMatchIds { get; set; }

        /// <summary>
        /// List of match Ids from solo first-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> SoloFPPMatchIds { get; set; }

        /// <summary>
        /// List of match Ids from duo first-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> DuoFPPMatchIds { get; set; }

        /// <summary>
        /// List of match Ids from squad first-person perspective matches
        /// participated in in the current season
        /// </summary>
        /// <remarks>
        /// Used to lookup the full match object on the /matches endpoint
        /// </remarks>
        public List<string> SquadFPPMatchIds { get; set; }

        public static Stats Deserialize(string serialized)
        {
            StatsDTO dto = JsonConvert.DeserializeObject<StatsDTO>(serialized);
            Stats stats = new Stats()
            {
                AccountId = dto.Data.Relationships.Player.Data.Id,
                SeasonId = dto.Data.Relationships.Season.Data.Id,
                SoloTPP = dto.Data.Attributes.GameModeStats.Solo,
                SoloFPP = dto.Data.Attributes.GameModeStats.SoloFPP,
                DuoTPP = dto.Data.Attributes.GameModeStats.Duo,
                DuoFPP = dto.Data.Attributes.GameModeStats.DuoFPP,
                SquadTPP = dto.Data.Attributes.GameModeStats.Squad,
                SquadFPP = dto.Data.Attributes.GameModeStats.SquadFPP,
                SoloTPPMatchIds = dto.Data.Relationships.MatchesSolo.Data
                                        .Select(x => x.Id).ToList(),
                SoloFPPMatchIds = dto.Data.Relationships.MatchesSoloFPP.Data
                                        .Select(x => x.Id).ToList(),
                DuoTPPMatchIds = dto.Data.Relationships.MatchesDuo.Data
                                        .Select(x => x.Id).ToList(),
                DuoFPPMatchIds = dto.Data.Relationships.MatchesDuoFPP.Data
                                        .Select(x => x.Id).ToList(),
                SquadTPPMatchIds = dto.Data.Relationships.MatchesSquad.Data
                                        .Select(x => x.Id).ToList(),
                SquadFPPMatchIds = dto.Data.Relationships.MatchesSquadFPP.Data
                                        .Select(x => x.Id).ToList()
            };
            return stats;
        }
    }

    /// <summary>
    /// Contain a player's aggregated stats
    /// for a game mode in the context of a season.
    /// </summary>
    public class GameModeStats
    {
        /// <summary>
        /// Number of enemy players this player damaged that were killed by teammates.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Highest number of rank points the player was awarded during the season across all game modes.
        /// </summary>
        public float BestRankPoint { get; set; }

        /// <summary>
        /// Number of boost items used.
        /// </summary>
        public int Boosts { get; set; }

        /// <summary>
        /// Number of enemy players knocked.
        /// </summary>
        public int DBNOs { get; set; }

        /// <summary>
        /// Number of kills during the most recent day played.
        /// </summary>
        public int DailyKills { get; set; }

        /// <summary>
        /// Total damage dealt. 
        /// Note: Self inflicted damage is subtracted.
        /// </summary>
        public float DamageDealt { get; set; }

        public int Days { get; set; }

        /// <summary>
        /// Number of wins during the most recent day played.
        /// </summary>
        public int DailyWins { get; set; }

        /// <summary>
        /// Number of enemy players killed with headshots.
        /// </summary>
        public int HeadshotKills { get; set; }

        /// <summary>
        /// Number of healing items used.
        /// </summary>
        public int Heals { get; set; }

        /// <summary>
        /// Number of enemy players killed.
        /// </summary>
        public int Kills { get; set; }

        public float LongestKill { get; set; }

        /// <summary>
        /// Longest time survived in a match.
        /// </summary>
        public float LongestTimeSurvived { get; set; }

        /// <summary>
        /// Number of matches lost
        /// </summary>
        public int Losses { get; set; }

        public int MaxKillStreaks { get; set; }

        /// <summary>
        /// Longest time survived in a match.
        /// </summary>
        public float MostSurvivalTime { get; set; }

        /// <summary>
        /// Number of rank points the player was awarded.
        /// </summary>
        /// <remarks>
        /// This value will be 0 when roundsPlayed < 10.
        /// </remarks>
        public float RankPoints { get; set; }

        /// <summary>
        /// Rank title in the form title-level
        /// </summary>
        public string RankPointsTitle { get; set; }

        /// <summary>
        /// Number of times this player revived teammates.
        /// </summary>
        public int Revives { get; set; }

        /// <summary>
        /// Total distance traveled in vehicles measured in meters.
        /// </summary>
        public float RideDistance { get; set; }

        /// <summary>
        /// Number of kills while in a vehicle.
        /// </summary>
        public int RoadKills { get; set; }

        /// <summary>
        /// Highest number of kills in a single match.
        /// </summary>
        public int RoundMostKills { get; set; }

        /// <summary>
        /// Number of matches played.
        /// </summary>
        public int RoundsPlayed { get; set; }

        /// <summary>
        /// Number of self-inflicted deaths.
        /// </summary>
        public int Suicides { get; set; }

        /// <summary>
        /// Total distance traveled while swimming measured in meters.
        /// </summary>
        public float SwimDistance { get; set; }

        /// <summary>
        /// Number of times this player killed a teammate.
        /// </summary>
        public int TeamKills { get; set; }

        /// <summary>
        /// Total time survived.
        /// </summary>
        public float TimeSurvived { get; set; }

        /// <summary>
        /// Number of times this player made it to the top 10 in a match.
        /// </summary>
        public int Top10s { get; set; }

        /// <summary>
        /// Number of vehicles destroyed.
        /// </summary>
        public int VehicleDestroys { get; set; }

        /// <summary>
        /// Total distance traveled on foot measured in meters.
        /// </summary>
        public float WalkDistance { get; set; }

        /// <summary>
        /// Number of weapons picked up.
        /// </summary>
        public int WeaponsAcquired { get; set; }

        /// <summary>
        /// Number of kills during the most recent week played.
        /// </summary>
        public int WeeklyKills { get; set; }

        /// <summary>
        /// Number of wins during the most recent week played.
        /// </summary>
        public int WeeklyWins { get; set; }

        /// <summary>
        /// Number of matches won.
        /// </summary>
        public int Wins { get; set; }

        [Obsolete]
        public long KillPoints { get; set; }

        [Obsolete]
        public long WinPoints { get; set; }
    }

    #region DTO

    public class StatsDTO
    {
        public StatsData Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class StatsData
    {
        /// <summary>
        /// Identifier for this object type ("playerSeason")
        /// </summary>
        public string Type { get; set; }

        public StatsRelationships Relationships { get; set; }
        public StatsAttributes Attributes { get; set; }
    }

    public class StatsAttributes
    {
        public GameModeStatsWrapper GameModeStats { get; set; }
    }

    public class GameModeStatsWrapper
    {
        public GameModeStats Solo { get; set; }
        public GameModeStats Duo { get; set; }
        public GameModeStats Squad { get; set; }

        [JsonProperty("solo-fpp")]
        public GameModeStats SoloFPP { get; set; }

        [JsonProperty("duo-fpp")]
        public GameModeStats DuoFPP { get; set; }
        
        [JsonProperty("squad-fpp")]
        public GameModeStats SquadFPP { get; set; }
    }

    public class StatsRelationships
    {
        public MultiRelationship MatchesSolo { get; set; }
        public MultiRelationship MatchesSoloFPP { get; set; }
        public MultiRelationship MatchesDuo { get; set; }
        public MultiRelationship MatchesDuoFPP { get; set; }
        public MultiRelationship MatchesSquad { get; set; }
        public MultiRelationship MatchesSquadFPP { get; set; }
        public Relationship Season { get; set; }
        public Relationship Player { get; set; }
    }

    #endregion
}
