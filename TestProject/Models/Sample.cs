using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    /// <summary>
    /// Sample objects contain the ID and shard of a match.
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// Match
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Match ID
        /// </summary>
        public string Id { get; set; }

        public static Sample Deserialize(string json)
        {
            Sample sample = JsonConvert.DeserializeObject<Sample>(json);
            return sample;
        }
    }
}
