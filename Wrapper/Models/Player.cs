using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a PUBG Player.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the DTO.
    /// </remarks>
    public class Player
    {
        /// <summary>
        /// Unique GUID for a player.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Username of the player.
        /// </summary>
        public string Name { get; set; }
        public string Version { get; set; }
        public string Shard { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Unique GUIDs of the five most recent matches played.
        /// </summary>
        public List<string> MatchIds { get; set; }

        public override string ToString()
        {
            string playerString = "Player: " + Name + "\n";
            playerString += "Id: " + Id + "\n";
            playerString += "Region: " + Shard + "\n";
            playerString += "Recent Matches:\n";

            foreach (string id in MatchIds)
                playerString += "    Id: " + id + "\n";

            return playerString;
        }
        
        public static Player Deserialize(string playerJson)
        {
            PlayerDTO dto = JsonConvert.DeserializeObject<PlayerDTO>(playerJson);
            return BuildPlayerFromDTO(dto);
        }

        // TODO: Reduce duplication here
        public static List<Player> DeserializePlayerList(string playerJson)
        {
            List<PlayerDTO> dto = JsonConvert.DeserializeObject<List<PlayerDTO>>(playerJson);
            List<Player> players = new List<Player>();
            foreach (PlayerDTO player in dto)
            {
                players.Add(BuildPlayerFromDTO(player));
            }

            return players;
        }

        private static Player BuildPlayerFromDTO(PlayerDTO dto)
        {
            Player player = new Player()
            {
                Id = dto?.Data?.Id,
                Name = dto?.Data?.Attributes?.Name,
                Version = dto?.Data?.Attributes?.Version,
                Shard = dto?.Data?.Attributes?.Shard, // TODO: use enum?
                Title = dto?.Data?.Attributes?.Title,
                MatchIds = dto?.Data?.Relationships?.Matches?.Data?.Select(x => x.Id).ToList()
            };

            return player;
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

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patchVersion")]
        public string Version { get; set; }

        [JsonProperty("shardId")]
        public string Shard { get; set; }

        [JsonProperty("titleId")]
        public string Title { get; set; }
    }

    #endregion
}
