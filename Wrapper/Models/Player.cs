using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a PUBG Player.
    /// Player objects contain information about a player and a 
    /// list of their recent matches (up to 14 days old). 
    /// Note: player objects are specific to platform shards.
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
        /// PUBG IGN.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Platform shard.
        /// </summary>
        public string Shard { get; set; }

        /// <summary>
        /// Version of the game.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Identifies the studio and game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A list of match ids.
        /// Used to lookup the full match object on the /matches endpoint.
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
            return BuildPlayerFromDTO(dto.Data);
        }
        
        public static List<Player> DeserializePlayerList(string playerJson)
        {
            PlayersDTO dto = JsonConvert.DeserializeObject<PlayersDTO>(playerJson);
            List<Player> players = new List<Player>();
            foreach (PlayerData data in dto.Data)
            {
                players.Add(BuildPlayerFromDTO(data));
            }

            return players;
        }

        private static Player BuildPlayerFromDTO(PlayerData data)
        {
            Player player = new Player()
            {
                Id = data?.Id,
                Name = data?.Attributes?.Name,
                Version = data?.Attributes?.Version,
                Shard = data?.Attributes?.Shard, // TODO: use enum?
                Title = data?.Attributes?.Title,
                MatchIds = data?.Relationships?.Matches?.Data?.Select(x => x.Id).ToList()
            };

            return player;
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
