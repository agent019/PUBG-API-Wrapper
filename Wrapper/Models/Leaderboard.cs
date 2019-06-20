using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    public class Leaderboard
    {
        public string Shard { get; set; }
        public string GameMode { get; set; }
        public List<LeaderboardStats> PlayerStats { get; set; }

        public Leaderboard Deserialize(string serialized)
        {
            LeaderboardDTO dto = JsonConvert.DeserializeObject<LeaderboardDTO>(serialized);
            return new Leaderboard()
            {
                Shard = dto.Data.Attributes.Shard,
                GameMode = dto.Data.Attributes.GameMode,
                PlayerStats = dto.Included.Select(x => new LeaderboardStats()
                {
                    Name = x.Attributes.Name,
                    Id = x.Id,
                    Rank = x.Attributes.Rank,
                    RankPoints = x.Attributes.Stats.RankPoints,
                    Wins = x.Attributes.Stats.Wins,
                    Games = x.Attributes.Stats.Games,
                    WinRatio = x.Attributes.Stats.WinRatio,
                    AverageDamage = x.Attributes.Stats.AverageDamage,
                    Kills = x.Attributes.Stats.Kills,
                    KillDeathRatio = x.Attributes.Stats.KillDeathRatio,
                    AverageRank = x.Attributes.Stats.AverageRank
                }).OrderBy(x => x.Rank).ToList()
            };
        }
    }

    public class LeaderboardStats
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Rank { get; set; }
        public int RankPoints { get; set; }
        public int Wins { get; set; }
        public int Games { get; set; }
        public float WinRatio { get; set; }
        public int AverageDamage { get; set; }
        public int Kills { get; set; }
        public float KillDeathRatio { get; set; }
        public float AverageRank { get; set; }
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
        public float WinRatio { get; set; }
        public int AverageDamage { get; set; }
        public int Kills { get; set; }
        public float KillDeathRatio { get; set; }
        public float AverageRank { get; set; }
    }

    #endregion
}
