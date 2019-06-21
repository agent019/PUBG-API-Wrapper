using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Leaderboard objects show a specific page containing
    /// the current rank of 500 of the top 1000 players for a game mode.
    /// </summary>
    public class Leaderboard
    {
        /// <summary>
        /// Platform shard.
        /// </summary>
        public string Shard { get; set; }

        /// <summary>
        /// The game mode.
        /// </summary>
        public string GameMode { get; set; }

        /// <summary>
        /// List of stats, by player.
        /// </summary>
        public List<LeaderboardStats> PlayerStats { get; set; }

        public static Leaderboard Deserialize(string serialized)
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
        /// <summary>
        /// The player's IGN.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The accountId of the player.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The player's current rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Number of rank points the player was awarded.
        /// </summary>
        public int RankPoints { get; set; }

        /// <summary>
        /// Number of matches won.
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// Number of games played.
        /// </summary>
        public int Games { get; set; }

        /// <summary>
        /// Win ratio.
        /// </summary>
        public double WinRatio { get; set; }

        /// <summary>
        /// Average amount of damage dealt per match.
        /// </summary>
        public int AverageDamage { get; set; }

        /// <summary>
        /// Number of enemy players killed.
        /// </summary>
        public int Kills { get; set; }

        /// <summary>
        /// Kill death ratio.
        /// </summary>
        public double KillDeathRatio { get; set; }

        /// <summary>
        /// Average rank.
        /// </summary>
        public double AverageRank { get; set; }
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

    /// <summary>
    /// Player stats in the context of a season.
    /// </summary>
    public class IncludedStats
    {
        public int RankPoints { get; set; }
        public int Wins { get; set; }
        public int Games { get; set; }
        public double WinRatio { get; set; }
        public int AverageDamage { get; set; }
        public int Kills { get; set; }
        public double KillDeathRatio { get; set; }
        public double AverageRank { get; set; }
    }

    #endregion
}
