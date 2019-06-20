using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a PUBG Player.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
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
            Player player = new Player()
            {
                Id = dto.Data.Id,
                Name = dto.Data.Attributes.Name,
                Version = dto.Data.Attributes.Version,
                Shard = dto.Data.Attributes.Shard,
                Title = dto.Data.Attributes.Title,
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
                    Name = player.Data.Attributes.Name,
                    Version = player.Data.Attributes.Version,
                    Shard = player.Data.Attributes.Shard,
                    Title = player.Data.Attributes.Title,
                    MatchIds = player.Data.Relationships.Matches.Data.Select(x => x.Id).ToList()
                });
            }

            return players;
        }
    }

    #region DTO

    /// <summary>
    /// Player objects contain information about a player 
    /// and a list of their recent matches (up to 14 days old). 
    /// Note: player objects are specific to platform shards.
    /// </summary>
    public class PlayerDTO
    {
        public PlayerData Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// Players objects contain information about multiple players 
    /// and a list of their recent matches (up to 14 days old). 
    /// Note: player objects are specific to platform shards.
    /// </summary>
    public class PlayersDTO
    {
        public List<PlayerData> Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class PlayerData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public Attributes Attributes { get; set; }
        public PlayerRelationships Relationships { get; set; }
        public Links Links { get; set; }
    }

    public class PlayerRelationships
    {
        public MultiRelationship Matches { get; set; }
        public MultiRelationship Assets { get; set; }
    }

    public class Attributes
    {
        public string Name { get; set; }

        [JsonProperty("patchVersion")]
        public string Version { get; set; }

        [JsonProperty("shardId")]
        public string Shard { get; set; }

        [JsonProperty("titleId")]
        public string Title { get; set; }
        
        // Dynamic because api returns null in all cases, for now
        public dynamic Stats { get; set; }
    }

    #endregion
}
