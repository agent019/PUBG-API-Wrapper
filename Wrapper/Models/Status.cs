using Newtonsoft.Json;
using System;

namespace PUBGAPIWrapper.Models
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
        public string Type { get; set; }

        public override string ToString()
        {
            string statusString = "Id: " + Id + "\n";
            statusString += "Type: " + Type + "\n";

            return statusString;
        }

        public static Status Deserialize(string statusJson)
        {
            StatusDTO dto = JsonConvert.DeserializeObject<StatusDTO>(statusJson);
            Status s = new Status()
            {
                Id = dto.Data.Id,
                Type = dto.Data.Type
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
    }

    #endregion
}
