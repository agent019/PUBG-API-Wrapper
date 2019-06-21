using Newtonsoft.Json;
using System.Collections.Generic;

// TODO: Verify these objects deserialize correctly
namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Parent class. Holds the fields common to every event subclass.
    /// </summary>
    public abstract class Event
    {
        [JsonProperty("_D")]
        public string Timestamp { get; set; }

        [JsonProperty("_T")]
        public string Type { get; set; }

        public Common Common { get; set; }
    }
    
    public class LogArmorDestroy : Event
    {
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Character Victim { get; set; }
        public string DamageTypeCategory { get; set; }
        public DamageReason DamageReason { get; set; }
        public string DamageCauserName { get; set; }
        public Item Item { get; set; }
        public float Distance { get; set; }
    }

    public class LogCarePackageLand : Event
    {
        public ItemPackage ItemPackage { get; set; }
    }

    public class LogCarePackageSpawn : Event
    {
        public ItemPackage ItemPackage { get; set; }
    }

    public class LogGameStatePeriodic : Event
    {
        public GameState GameState { get; set; }
    }
    public class LogHeal : Event // new 
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
        public double HealAmount { get; set; }
    }

    public class LogItemAttach : Event
    {
        public Character Character { get; set; }
        public Item ParentItem { get; set; }
        public Item ChildItem { get; set; }
    }

    public class LogItemDetach : Event
    {
        public Character Character { get; set; }
        public Item ParentItem { get; set; }
        public Item ChildItem { get; set; }
    }

    public class LogItemDrop : Event
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemEquip : Event
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemPickup : Event
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemPickupFromCarePackage : Event // new
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemPickupFromLootBox : Event // new
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemUnequip : Event
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogItemUse : Event
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
    }

    public class LogMatchDefinition : Event
    {
        public string MatchId { get; set; }
        public string PingQuality { get; set; }
        public string SeasonState { get; set; } // new
    }

    public class LogMatchEnd : Event
    {
        public IEnumerable<Character> Characters { get; set; }
    }

    public class LogMatchStart : Event
    {
        public string MapName { get; set; }
        public string WeatherId { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public string CameraViewBehaviour { get; set; }
        public int TeamSize { get; set; }
        public bool IsCustomGame { get; set; }
        public bool IsEventMode { get; set; }
        //TODO: this is a stringified array of objects
        public string BlueZoneCustomOptions { get; set; }
    }

    public class LogObjectDestroy : Event // new
    {
        public Character Character { get; set; }
        public string ObjectType { get; set; }
        public Location ObjectLocation { get; set; }
    }


    public class LogParachuteLanding : Event // new 
    {
        public Character Character { get; set; }
        public double Distance { get; set; }
    }

    public class LogPlayerAttack : Event
    {
        public int AttackId { get; set; }
        public int FireWeaponStackCount { get; set; } // new
        public Character Attacker { get; set; }
        public AttackType? AttackType { get; set; }
        public Item Weapon { get; set; }
        public Vehicle Vehicle { get; set; }
    }

    public class LogPlayerCreate : Event
    {
        public Character Character { get; set; }
    }

    public class LogPlayerKill : Event
    {
        public int AttackId { get; set; }
        public Character Killer { get; set; }
        public Character Victim { get; set; }
        public Character Assistant { get; set; } // new
        public int DBNOId { get; set; } // new
        public string DamageTypeCategory { get; set; }
        public string DamageCauserName { get; set; }
        public string DamageCauserAdditionalInfo { get; set; } // new
        public string DamageReason { get; set; }
        public float Distance { get; set; }
        public GameResult VictimGameResult { get; set; } // new
    }

    public class LogPlayerLogin : Event
    {
        public string AccountId { get; set; }
    }

    public class LogPlayerLogout : Event
    {
        public string AccountId { get; set; }
    }

    public class LogPlayerMakeGroggy : Event
    {
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Character Victim { get; set; }
        public string DamageReason { get; set; } // new
        public string DamageTypeCategory { get; set; }
        public string DamageCauserName { get; set; }
        public string DamageCauserAdditionalInfo { get; set; } // new
        public float Distance { get; set; }
        public bool IsAttackerInVehicle { get; set; }
        public int DBNOId { get; set; }
    }

    public class LogPlayerPosition : Event
    {
        public Character Character { get; set; }
        public Vehicle Vehicle { get; set; } // new
        public float ElapsedTime { get; set; }
        public int NumAlivePlayers { get; set; }
    }

    public class LogPlayerRevive : Event
    {
        public Character Reviver { get; set; }
        public Character Victim { get; set; }
        public int DBNOId { get; set; } // new
    }

    public class LogPlayerTakeDamage : Event
    {
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Character Victim { get; set; }
        public string DamageTypeCategory { get; set; }
        public DamageReason DamageReason { get; set; } // string?
        /// <remarks>
        /// 1.0 Damage = 1.0 Health
        /// Net damage after armor; Damage to health
        /// </remarks>
        public float Damage { get; set; }
        public string DamageCauserName { get; set; }
    }

    public class LogRedZoneEnded : Event // new
    {
        public List<Character> Drivers { get; set; }
    }

    public class LogSwimEnd : Event
    {
        public Character Character { get; set; }
        public double SwimDistance { get; set; }
        public double MaxSwimDepthOfWater { get; set; } // new
    }

    public class LogSwimStart : Event
    {
        public Character Character { get; set; }
    }

    public class LogVaultStart : Event // new 
    {
        public Character Character { get; set; }
    }

    public class LogVehicleDestroy : Event
    {
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Vehicle Vehicle { get; set; }
        public string DamageTypeCategory { get; set; }
        public string DamageCauserName { get; set; }
        public float Distance { get; set; }
    }

    public class LogVehicleLeave : Event
    {
        public Character Character { get; set; }
        public Vehicle Vehicle { get; set; }
        public float RideDistance { get; set; }
        public int SeatIndex { get; set; }
        public double MaxSpeed { get; set; } // new
    }

    public class LogVehicleRide : Event
    {
        public Character Character { get; set; }
        public Vehicle Vehicle { get; set; }
        public int SeatIndex { get; set; }
    }

    public class LogWeaponFireCount : Event // new
    {
        public Character Character { get; set; }
        public string WeaponId { get; set; }
        // increments of 10
        public int FireCount { get; set; }
    }

    public class LogWheelDestroy : Event
    {
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Vehicle Vehicle { get; set; }
        public string DamageTypeCategory { get; set; }
        public string DamageCauserName { get; set; }
    }
}
