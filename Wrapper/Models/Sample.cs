using Newtonsoft.Json;
using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Sample objects contain the ID and shard of a match.
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// Match IDs
        /// </summary>
        public List<string> Ids { get; set; }

        public Sample()
        {
            Ids = new List<string>();
        }

        public static Sample Deserialize(string json)
        {
            SampleDTO dto = JsonConvert.DeserializeObject<SampleDTO>(json);
            Sample sample = new Sample();
            foreach (Reference match in dto.Data.Relationships.Matches.Data)
            {
                sample.Ids.Add(match.Id);
            }
            return sample;
        }

        public override string ToString()
        {
            string toString = "Sample:\n";
            foreach (string id in Ids)
            {
                toString += "Id: " + id + "\n";
            }
            return toString;
        }
    }

    #region DTO

    public class SampleDTO
    {
        [JsonProperty("data")]
        public SampleData Data { get; set; }
    }

    public class SampleData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public SampleAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public SampleRelationships Relationships { get; set; }
    }

    public class SampleAttributes
    {
        [JsonProperty("createdAt")]
        public string Created { get; set; }

        [JsonProperty("titleId")]
        public string Title { get; set; }

        [JsonProperty("shardId")]
        public string Shard { get; set; }
    }

    public class SampleRelationships
    {
        [JsonProperty("matches")]
        public MultiRelationship Matches { get; set; }
    }

    #endregion
}
