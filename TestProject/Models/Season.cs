using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestProject.Models
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

        public static List<Season> DeserializeSeason(string seasonJson)
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
        public List<SeasonData> Data { get; set; }
        public SeasonLinks Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class SeasonData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public SeasonAttributes Attributes { get; set; }
    }

    public class SeasonLinks
    {
        public string Self { get; set; }
    }
    
    public class SeasonAttributes
    {
        public bool IsCurrentSeason { get; set; }
        public bool IsOffSeason { get; set; }
    }

    #endregion
}
