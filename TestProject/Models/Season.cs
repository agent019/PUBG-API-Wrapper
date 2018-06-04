using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public class Season
    {
        public string Type { get; set; }
        public String Id { get; set; }
        public SeasonAttributes Attributes { get; set; }

        public static List<Season> DeserializeSeason(string seasonJson)
        {
            throw new NotImplementedException();
        }
    }

    public class SeasonAttributes
    {
        public bool IsCurrentSeason { get; set; }
        public bool IsOffSeason { get; set; }
    }
}
