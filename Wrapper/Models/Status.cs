using Newtonsoft.Json;
using PUBGAPIWrapper.Serialization;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of the status of the PUBG Servers.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
    /// </remarks>
    [JsonConverter(typeof(StatusJsonConverter))]
    public class Status
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public static Status Deserialize(string statusJson)
        {
            StatusDTO dto = JsonConvert.DeserializeObject<StatusDTO>(statusJson);
            return new Status()
            {
                Id = dto.Data.Id,
                Type = dto.Data.Type
            };
        }

        public override string ToString()
        {
            string statusString = "Id: " + Id + "\n";
            statusString += "Type: " + Type + "\n";

            return statusString;
        }
    }
    
    #region DTO

    public class StatusDTO
    {
        public Reference Data { get; set; }
    }

    #endregion
}
