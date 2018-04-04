using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public class Match
    {

    }

    #region DTO

    public class MatchDTO
    {
		//Player Data
        public List<Data> Data { get; set; }

        /// <remarks>
        /// This isn't right. They're not all player objects,
        /// rather some are players, and some are rosters,
        /// determined by the type field
        /// TODO: How the fuck do you deserialize an object that might
        /// be one of a couple things?
        /// </remarks>
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

	public class Data {
		public string Type { get; set; }
		public string Id { get; set; }
		public Relationships Relationships { get; set; }
		public PlayerAttributes Attributes { get; set; }
	}

	public class Relationships {
		public Matches Matches { get; set; }
		public Assets Assets { get; set; }
	}

	public class Matches {
		public List<Data> Data { get; set; }
	}

	public class Assets {
		public List<Data> Data { get; set; }
	}

	public class PlayerAttributes {
		public string CreatedAt { get; set; }
		public string Name { get; set; }
		public string Actor { get; set; }
		public string ShardId { get; set; }
		public PlayerStats Stats { get; set; }
		public string UpdatedAt { get; set; }
	}

	public class Links
    {
        public string Next { get; set; }
        public string Self { get; set; }
		public string Schema { get; set; }
	}

    public class Meta
    { }





    public class MatchAttributes
    {
        public DateTime CreatedAt { get; set; }
        public long Duration { get; set; }
        public string GameMode { get; set; }
        public string PatchVersion { get; set; }
        public string ShardId { get; set; }
        public dynamic Stats { get; set; }
        public dynamic Tags { get; set; }
        public string TitleId { get; set; }
    }




    public class PlayerStats
    {
        public int DBNOs { get; set; }
        public int Assists { get; set; }
        public int Boosts { get; set; }
        public decimal DamageDealt { get; set; }
        public string DeathType { get; set; }
        public int HeadshotKills { get; set; }
        public int Heals { get; set; }
        public int KillPlace { get; set; }
        public int KillPoints { get; set; }
        public decimal KillPointsDelta { get; set; }
        public int KillStreaks { get; set; }
        public int Kills { get; set; }
        public int LastKillPoints { get; set; }
        public int LastWinPoints { get; set; }
        public int LongestKill { get; set; }
        public int MostDamage { get; set; }
        public string Name { get; set; }
        public string PlayerId { get; set; }
        public int Revives { get; set; }
        public decimal RideDistance { get; set; }
        public int RoadKills { get; set; }
        public int TeamKills { get; set; }
        public int TimeSurvived { get; set; }
        public int VehicleDestroys { get; set; }
        public decimal WalkDistance { get; set; }
        public int WeaponsAcquired { get; set; }
        public int WinPlace { get; set; }
        public int WinPoints { get; set; }
        public decimal WinPointsDelta { get; set; }
    }

    #endregion
}
