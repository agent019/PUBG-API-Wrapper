using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    public static class ShardExtensions
    {
        /// <summary>
        /// Extension method that pulls the uri-ready string representation of the Shard
        /// from the description attribute.
        /// </summary>
        /// <remarks>
        /// We have to do this because C# doesn't support the '-' character in enum values.
        /// </remarks>
        public static string GetDescription(this PlatformRegionShard shard)
        {
            Type type = shard.GetType();
            var name = PlatformRegionShard.GetName(type, shard);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .Single()
                .Description;
        }
    }

    public enum PlatformShard
    {
        /// <remarks>
        /// Alternative platform to Steam (https://www.kakaogames.com/)
        /// </remarks>
        [JsonProperty("kakao")]
        Kakao = 0,

        [JsonProperty("psn")]
        PSN = 1,

        [JsonProperty("steam")]
        Steam = 2,

        [JsonProperty("tournament")]
        Tournament = 3,

        [JsonProperty("xbox")]
        Xbox = 4
    }

    /// <summary>
    /// Enum representing the platform and region.
    /// </summary>
    public enum PlatformRegionShard
    {
        /// <summary>
        /// Xbox Asia
        /// </summary>
        [JsonProperty("xbox-as")]
        [Description("xbox-as")]
        Xbox_AS = 0,

        /// <summary>
        /// Xbox Europe
        /// </summary>
        [JsonProperty("xbox-eu")]
        [Description("xbox-eu")]
        Xbox_EU = 1,

        /// <summary>
        /// Xbox North America
        /// </summary>
        [JsonProperty("xbox-na")]
        [Description("xbox-na")]
        Xbox_NA = 2,

        /// <summary>
        /// Xbox Oceania
        /// </summary>
        [JsonProperty("xbox-oc")]
        [Description("xbox-oc")]
        Xbox_OC = 3,

        /// <summary>
        /// PC Korea
        /// </summary>
        [JsonProperty("pc-krjp")]
        [Description("pc-krjp")]
        PC_KRJP = 4,

        /// <summary>
        /// PC Japan
        /// </summary>
        [JsonProperty("pc-jp")]
        [Description("pc-jp")]
        PC_JP = 5,

        /// <summary>
        /// PC North America
        /// </summary>
        [JsonProperty("pc-na")]
        [Description("pc-na")]
        PC_NA = 6,

        /// <summary>
        /// PC Europe
        /// </summary>
        [JsonProperty("pc-eu")]
        [Description("pc-eu")]
        PC_EU = 7,

        /// <summary>
        /// PC Russia
        /// </summary>
        [JsonProperty("pc-ru")]
        [Description("pc-ru")]
        PC_RU = 8,

        /// <summary>
        /// PC Oceania
        /// </summary>
        [JsonProperty("pc-oc")]
        [Description("pc-oc")]
        PC_OC = 9,

        /// <summary>
        /// Alternative platform to Steam (https://www.kakaogames.com/)
        /// </summary>
        [JsonProperty("pc-kakao")]
        [Description("pc-kakao")]
        PC_KAKAO = 10,

        /// <summary>
        /// PC South East Asia
        /// </summary>
        [JsonProperty("pc-sea")]
        [Description("pc-sea")]
        PC_SEA = 11,

        /// <summary>
        /// PC South and Central Amercia
        /// </summary>
        [JsonProperty("pc-sa")]
        [Description("pc-sa")]
        PC_SA = 12,

        /// <summary>
        /// PC Asia
        /// </summary>
        [JsonProperty("pc-as")]
        [Description("pc-as")]
        PC_AS = 13,

        /// <summary>
        /// PC Tournaments
        /// </summary>
        [JsonProperty("pc-tournament")]
        [Description("pc-tournament")]
        PC_TOURNAMENT = 14,

        /// <summary>
        /// PSN Asia
        /// </summary>
        [JsonProperty("psn-as")]
        [Description("psn-as")]
        PSN_AS = 15,

        /// <summary>
        /// PSN Europe
        /// </summary>
        [JsonProperty("psn-eu")]
        [Description("psn-eu")]
        PSN_EU = 16,

        /// <summary>
        /// PSN North America
        /// </summary>
        [JsonProperty("psn-na")]
        [Description("psn-na")]
        PSN_NA = 17,

        /// <summary>
        /// PSN Oceania
        /// </summary>
        [JsonProperty("psn-oc")]
        [Description("psn-oc")]
        PSN_OC = 18,
    }
}
