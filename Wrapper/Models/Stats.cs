using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGAPIWrapper.Models
{
    public class Stats
    {
    }

    public class StatsDTO
    {
        public StatsData Data { get; set; }

        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class StatsData
    {
        /// <summary>
        /// Identifier for this object type ("season")
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Season ID - Used to lookup a player's stats for this season on the /players endpoint
        /// </summary>
        public StatsAttributes Id { get; set; }

        public StatsRelationships Relationships { get; set; }
    }

    public class StatsAttributes
    {
        public GameModeStatsWrapper GameModeStats { get; set; }
    }

    public class GameModeStatsWrapper
    {
        [JsonProperty("duo")]
        public GameModeStats Duo { get; set; }

        [JsonProperty("duo-fpp")]
        public GameModeStats DuoFPP { get; set; }

        [JsonProperty("solo")]
        public GameModeStats Solo { get; set; }

        [JsonProperty("solo-fpp")]
        public GameModeStats SoloFPP { get; set; }

        [JsonProperty("squad")]
        public GameModeStats Squad { get; set; }

        [JsonProperty("squad-fpp")]
        public GameModeStats SquadFPP { get; set; }
    }

    public class GameModeStats
    {
        public int Assists { get; set; }
        public long BestRankPoint { get; set; }
        public int Boosts { get; set; }
        public int DBNOs { get; set; }
        public int DailyKills { get; set; }
        public long DamageDealt { get; set; }
        public int Days { get; set; }
        public int DailyWins { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        
        [Obsolete]
        public long KillPoints { get; set; }
        public int Kills { get; set; }
        public long LongestKill { get; set; }
        public long LongestTimeSurvived { get; set; }
        public int Losses { get; set; }
        public int MaxKillStreaks { get; set; }
        public long MostSurvivalTime { get; set; }
        public long RankPoints { get; set; }
        public string RankPointsTitle { get; set; }
        public int Revives { get; set; }
        public int RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int RoundMostKills { get; set; }
        public int RoundsPlayed { get; set; }
        public int Suicides { get; set; }
        public long SwimDistance { get; set; }
        public int TeamKills { get; set; }
        public int TimeSurvived { get; set; }
        public int Top10s { get; set; }
        public int VehicleDestroys { get; set; }
        public long WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WeeklyKills { get; set; }
        public int WeeklyWins { get; set; }

        [Obsolete]
        public long WinPoints { get; set; }
        public int Wins { get; set; }
    }

    public class StatsRelationships
    {
        // todo: this isnt right, they're seperate objects, each with a list of data
        public List<MatchReference> Data { get; set; }
    }
}
