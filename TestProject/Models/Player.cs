using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Shard { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<string> MatchIds { get; set; }

        public override string ToString()
        {
            return "Player: " + Name + "\nId: " + Id;
        }
    }

    #region DTO

    public class PlayerDTO
    {
        [JsonProperty("data")]
        public PlayerData Data { get; set; }
    }

    public class PlayerData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public PlayerRelationships Relationships { get; set; }
    }

    public class PlayerRelationships
    {
        [JsonProperty("matches")]
        public PlayerMatches Matches { get; set; }
    }
    public class PlayerMatches
    {
        [JsonProperty("data")]
        public List<PlayerMatchesData> Data { get; set; }
    }

    public class PlayerMatchesData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("createdAt")]
        public string Created { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patchVersion")]
        public string Version { get; set; }

        [JsonProperty("shardId")]
        public string Shard { get; set; }

        [JsonProperty("titleId")]
        public string Title { get; set; }

        [JsonProperty("updatedAt")]
        public string Updated { get; set; }
    }

    #endregion
}
