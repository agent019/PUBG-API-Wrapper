using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string playerString = "Player: " + Name + "\n";
            playerString += "Id: " + Id + "\n";
            playerString += "Region: " + Shard + "\n";
            playerString += "Date created: " + Created.ToString() + "\n";
            playerString += "Last played: " + Updated.ToString() + "\n"; ;
            playerString += "Recent Matches:\n";

            foreach (string id in MatchIds)
                playerString += "    Id: " + id + "\n";

            return playerString;
        }
        
        public static Player DeserializePlayer(string playerJson)
        {
            PlayerDTO dto = JsonConvert.DeserializeObject<PlayerDTO>(playerJson);
            Player player = new Player()
            {
                Id = dto.Data.Id,
                Created = DateTime.Parse(dto.Data.Attributes.Created),
                Name = dto.Data.Attributes.Name,
                Version = dto.Data.Attributes.Version,
                Shard = dto.Data.Attributes.Shard,
                Title = dto.Data.Attributes.Title,
                Updated = DateTime.Parse(dto.Data.Attributes.Updated),
                MatchIds = dto.Data.Relationships.Matches.Data.Select(x => x.Id).ToList()
            };

            return player;
        }

        public static List<Player> DeserializePlayerList(string playerJson)
        {
            List<PlayerDTO> dto = JsonConvert.DeserializeObject<List<PlayerDTO>>(playerJson);
            List<Player> players = new List<Player>();
            foreach (PlayerDTO player in dto)
            {
                players.Add(new Player()
                {
                    Id = player.Data.Id,
                    Created = DateTime.Parse(player.Data.Attributes.Created),
                    Name = player.Data.Attributes.Name,
                    Version = player.Data.Attributes.Version,
                    Shard = player.Data.Attributes.Shard,
                    Title = player.Data.Attributes.Title,
                    Updated = DateTime.Parse(player.Data.Attributes.Updated),
                    MatchIds = player.Data.Relationships.Matches.Data.Select(x => x.Id).ToList()
                });
            }

            return players;
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
