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
        public static string GetDescription(this Shard shard)
        {
            Type type = shard.GetType();
            var name = Shard.GetName(type, shard);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .Single()
                .Description;
        }
    }

    /// <summary>
    /// Enum representing the platform and region.
    /// </summary>
    public enum Shard
    {
        /// <summary>
        /// Xbox Asia
        /// </summary>
        [JsonProperty("xbox-as")]
        [Description("xbox-as")]
        Xbox_AS,

        /// <summary>
        /// Xbox Europe
        /// </summary>
        [JsonProperty("xbox-eu")]
        [Description("xbox-eu")]
        Xbox_EU,

        /// <summary>
        /// Xbox North America
        /// </summary>
        [JsonProperty("xbox-na")]
        [Description("xbox-na")]
        Xbox_NA,

        /// <summary>
        /// Xbox Oceania
        /// </summary>
        [JsonProperty("xbox-oc")]
        [Description("xbox-oc")]
        Xbox_OC,

        /// <summary>
        /// PC Korea
        /// </summary>
        [JsonProperty("pc-krjp")]
        [Description("pc-krjp")]
        PC_KRJP,

        /// <summary>
        /// PC Japan
        /// </summary>
        [JsonProperty("pc-jp")]
        [Description("pc-jp")]
        PC_JP,

        /// <summary>
        /// PC North America
        /// </summary>
        [JsonProperty("pc-na")]
        [Description("pc-na")]
        PC_NA,

        /// <summary>
        /// PC Europe
        /// </summary>
        [JsonProperty("pc-eu")]
        [Description("pc-eu")]
        PC_EU,

        /// <summary>
        /// PC Russia
        /// </summary>
        [JsonProperty("pc-ru")]
        [Description("pc-ru")]
        PC_RU,

        /// <summary>
        /// PC Oceania
        /// </summary>
        [JsonProperty("pc-oc")]
        [Description("pc-oc")]
        PC_OC,

        /// <summary>
        /// Alternative platform to Steam (https://www.kakaogames.com/)
        /// </summary>
        [JsonProperty("pc-kakao")]
        [Description("pc-kakao")]
        PC_KAKAO,

        /// <summary>
        /// PC South East Asia
        /// </summary>
        [JsonProperty("pc-sea")]
        [Description("pc-sea")]
        PC_SEA,

        /// <summary>
        /// PC South and Central Amercia
        /// </summary>
        [JsonProperty("pc-sa")]
        [Description("pc-sa")]
        PC_SA,

        /// <summary>
        /// PC Asia
        /// </summary>
        [JsonProperty("pc-as")]
        [Description("pc-as")]
        PC_AS,

        /// <summary>
        /// PC Tournaments
        /// </summary>
        [JsonProperty("pc-tournament")]
        [Description("pc-tournament")]
        PC_TOURNAMENT
    }
}
