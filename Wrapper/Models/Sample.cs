using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Sample objects contain the ID and shard of a match.
    /// </summary>
    /// <remarks>
    /// Flattened representation of the JSON provided by the API.
    /// </remarks>
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
        public SampleData Data { get; set; }
    }

    public class SampleData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public SampleAttributes Attributes { get; set; }
        public SampleRelationships Relationships { get; set; }
    }

    public class SampleAttributes
    {
        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }

        [JsonProperty("titleId")]
        public string Title { get; set; }

        [JsonProperty("shardId")]
        public string Shard { get; set; }
    }

    public class SampleRelationships
    {
        public MultiRelationship Matches { get; set; }
    }

    #endregion
}
