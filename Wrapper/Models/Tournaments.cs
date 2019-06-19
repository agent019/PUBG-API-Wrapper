using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PUBGAPIWrapper.Models
{
    public class Tournaments
    {
    }

    #region DTO

    public class TournamentDTO
    {
        public TournamentData Data { get; set; }
        public List<TournamentIncluded> Included { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class TournamentsDTO
    {
        public List<TournamentIncluded> Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

    public class TournamentIncluded
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public TournamentAttributes Attributes { get; set; }
    }

    public class TournamentAttributes
    {
        [JsonProperty("createdAt")]
        public DateTime Created { get; set; }
    }

    public class TournamentData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public TournamentRelationships Relationships { get; set; }
    }

    public class TournamentRelationships
    {
        public MultiRelationship Matches { get; set; }
    }

    #endregion
}
