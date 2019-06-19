using Newtonsoft.Json;
using System;

namespace PUBGAPIWrapper.Models
{
    public class Stats
    {
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

    public class GameModeStats
    {
        public int Assists { get; set; }
        public float BestRankPoint { get; set; }
        public int Boosts { get; set; }
        public int DBNOs { get; set; }
        public int DailyKills { get; set; }
        public float DamageDealt { get; set; }
        public int Days { get; set; }
        public int DailyWins { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        public int Kills { get; set; }
        public float LongestKill { get; set; }
        public float LongestTimeSurvived { get; set; }
        public int Losses { get; set; }
        public int MaxKillStreaks { get; set; }
        public float MostSurvivalTime { get; set; }
        public float RankPoints { get; set; }
        public string RankPointsTitle { get; set; }
        public int Revives { get; set; }
        public float RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int RoundMostKills { get; set; }
        public int RoundsPlayed { get; set; }
        public int Suicides { get; set; }
        public float SwimDistance { get; set; }
        public int TeamKills { get; set; }
        public float TimeSurvived { get; set; }
        public int Top10s { get; set; }
        public int VehicleDestroys { get; set; }
        public float WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WeeklyKills { get; set; }
        public int WeeklyWins { get; set; }
        public int Wins { get; set; }

        [Obsolete]
        public long KillPoints { get; set; }

        [Obsolete]
        public long WinPoints { get; set; }
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
