using Newtonsoft.Json;
using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of a PUBG Season.
    /// Season objects each contain the ID of a season, 
    /// which can be used to lookup season information for a player.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
    /// </remarks>
    public class Season
    {
        /// <summary>
        /// Season ID.
        /// </summary>
        /// <remarks>
        /// Used to lookup a player's stats for this season on the /players endpoint.
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// Indicates if the season is active.
        /// </summary>
        public bool IsCurrentSeason { get; set; }

        /// <summary>
        /// Indicates if the season is not active.
        /// </summary>
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
                + "Id: " + this.Id + "\n"
                + "IsCurrentSeason: " + this.IsCurrentSeason + "\n"
                + "IsOffSeason: " + this.IsOffSeason + "\n";
            return toString;
        }
    }

    #region DTO

    /// <summary>
    /// Season objects each contain the ID of a season, 
    /// which can be used to lookup season information for a player.
    /// </summary>
    public class SeasonDTO
    {
        public List<SeasonData> Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class SeasonData
    {
        /// <summary>
        /// Identifier for this object type ("season")
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Season ID.
        /// </summary>
        /// <remarks>
        /// Used to lookup a player's stats for this season on the /players endpoint.
        /// </remarks>
        public string Id { get; set; }
        public SeasonAttributes Attributes { get; set; }
    }
    
    public class SeasonAttributes
    {
        public bool IsCurrentSeason { get; set; }
        public bool IsOffSeason { get; set; }
    }

    #endregion
}
