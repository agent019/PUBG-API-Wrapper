using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Represents a relationship between the object with this field, 
    /// and the referenced object.
    /// </summary>
    public class Relationship
    {
        [JsonProperty("data")]
        public Reference Data { get; set; }
    }

    /// <summary>
    /// Represents a relationship between the object with this field,
    /// and a group of referenced objects.
    /// </summary>
    public class MultiRelationship
    {
        [JsonProperty("data")]
        public List<Reference> Data { get; set; }
    }

    /// <summary>
    /// Represents an relational object that is a reference to some other object.
    /// </summary>
    public class Reference
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }


}
