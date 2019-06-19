using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGAPIWrapper.Models
{
    public class Leaderboard
    {
    }

    #region DTO

    public class LeaderboardDTO
    {
        public LeaderboardData Data { get; set; }
        public List<LeaderboardIncluded> Included { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class LeaderboardData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public LeaderboardAttributes Attributes { get; set; }
        public LeaderboardRelationships Relationships { get; set; }
    }

    public class LeaderboardAttributes
    {
        [JsonProperty("shardId")]
        public string Shard { get; set; }
        public string GameMode { get; set; }
    }

    public class LeaderboardRelationships
    {
        public MultiRelationship Players { get; set; }
    }

    public class LeaderboardIncluded
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public IncludedAttributes Attributes { get; set; }
    }

    public class IncludedAttributes
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public IncludedStats Stats { get; set; }
    }
    
    public class IncludedStats
    {
        public int RankPoints { get; set; }
        public int Wins { get; set; }
        public int Games { get; set; }
        public decimal WinRatio { get; set; }
        public int AverageDamage { get; set; }
        public int Kills { get; set; }
        public decimal KillDeathRatio { get; set; }
        public decimal AverageRank { get; set; }
    }

    #endregion
}
