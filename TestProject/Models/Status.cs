using Newtonsoft.Json;
using System;

namespace TestProject.Models
{
    /// <summary>
    /// Object representation of the status of the PUBG Servers.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the DTO.
    /// </remarks>
    public class Status
    {
        public string Id { get; set; }
        public DateTime Released { get; set; }
        public string Version { get; set; }

        public override string ToString()
        {
            string statusString = "Id: " + Id + "\n";
            statusString += "Version: " + Version + "\n";
            statusString += "Date Released: " + Released + "\n";

            return statusString;
        }

        public static Status Deserialize(string statusJson)
        {
            StatusDTO dto = JsonConvert.DeserializeObject<StatusDTO>(statusJson);
            Status s = new Status()
            {
                Id = dto.Data.Id,
                Released = DateTime.Parse(dto.Data.Attributes.Released),
                Version = dto.Data.Attributes.Version
            };
            return s;
        }
    }

    #region DTO

    public class StatusDTO
    {
        [JsonProperty("data")]
        public StatusData Data { get; set; }
    }

    public class StatusData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public StatusAttributes Attributes { get; set; }
    }

    public class StatusAttributes
    {
        [JsonProperty("releasedAt")]
        public string Released { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    #endregion
}
