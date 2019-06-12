using Newtonsoft.Json;
using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a PUBG Season.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the DTO.
    /// </remarks>
    public class Season
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public bool IsCurrentSeason { get; set; }
        public bool IsOffSeason { get; set; }

        public static List<Season> Deserialize(string seasonJson)
        {
            SeasonDTO dto = JsonConvert.DeserializeObject<SeasonDTO>(seasonJson);
            List<Season> seasons = new List<Season>();

            foreach (SeasonData ssn in dto.Data)
            {
                Season season = new Season()
                {
                    Id = ssn.Id,
                    Type = ssn.Type,
                    IsCurrentSeason = ssn.Attributes.IsCurrentSeason,
                    IsOffSeason = ssn.Attributes.IsOffSeason
                };
                seasons.Add(season);
            }

            return seasons;
        }

        public override string ToString()
        {
            string toString = "Season:\n"
                + "Type: " + this.Type + "\n"
                + "Id: " + this.Id + "\n"
                + "IsCurrentSeason: " + this.IsCurrentSeason + "\n"
                + "IsOffSeason: " + this.IsOffSeason + "\n";
            return toString;
        }
    }

    #region DTO

    public class SeasonDTO
    {
        [JsonProperty("data")]
        public List<SeasonData> Data { get; set; }

        [JsonProperty("links")]
        public SeasonLinks Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class SeasonData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public SeasonAttributes Attributes { get; set; }
    }

    public class SeasonLinks
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }
    
    public class SeasonAttributes
    {
        [JsonProperty("isCurrentSeason")]
        public bool IsCurrentSeason { get; set; }

        [JsonProperty("isOffSeason")]
        public bool IsOffSeason { get; set; }
    }

    #endregion
}
