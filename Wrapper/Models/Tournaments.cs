using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    public class Tournament
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }

        public List<Tournament> Deserialize(string serialized)
        {
            TournamentsDTO dto = JsonConvert.DeserializeObject<TournamentsDTO>(serialized);
            return dto.Data.Select(x => new Tournament()
            {
                Id = x.Id,
                Created = x.Attributes.Created
            }).ToList();
        }
    }

    public class TournamentMatches
    {
        public string Id { get; set; }
        public List<MatchReference> Matches { get; set; }

        public TournamentMatches Deserialize(string serialized)
        {
            TournamentDTO dto = JsonConvert.DeserializeObject<TournamentDTO>(serialized);
            return new TournamentMatches()
            {
                Id = dto.Data.Id,
                Matches = dto.Included.Select(x => new MatchReference()
                {
                    Id = x.Id,
                    Created = x.Attributes.Created
                }).ToList()
            };
        }
    }

    public class MatchReference
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
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
