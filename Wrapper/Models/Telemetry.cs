using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of the Telemetry for a specific PUBG Match.
    /// Contains lists for each of the type of possible events.
    /// </summary>
    /// <remarks>
    /// TODO: Added some new objects/properties that need deserialization.
    /// Also finish the old ones yeah?
    /// </remarks>
    public class Telemetry
    {
        #region Properties

        public List<LogArmorDestroy> ArmorDestroyEvents { get; set; }
        public List<LogCarePackageLand> CarePackageLandEvents { get; set; }
        public List<LogCarePackageSpawn> CarePackageSpawnEvents { get; set; }
        public List<LogGameStatePeriodic> GameStatePeriodicEvents { get; set; }
        public List<LogItemAttach> ItemAttachEvents { get; set; }
        public List<LogItemDetach> ItemDetachEvents { get; set; }
        public List<LogItemDrop> ItemDropEvents { get; set; }
        public List<LogItemEquip> ItemEquipEvents { get; set; }
        public List<LogItemPickup> ItemPickupEvents { get; set; }
        public List<LogItemUnequip> ItemUnequipEvents { get; set; }
        public List<LogItemUse> ItemUseEvents { get; set; }
        public List<LogMatchDefinition> MatchDefinitionEvents { get; set; }
        public List<LogMatchEnd> MatchEndEvents { get; set; }
        public List<LogMatchStart> MatchStartEvents { get; set; }
        public List<LogPlayerAttack> PlayerAttackEvents { get; set; }
        public List<LogPlayerCreate> PlayerCreateEvents { get; set; }
        public List<LogPlayerKill> PlayerKillEvents { get; set; }
        public List<LogPlayerLogin> PlayerLoginEvents { get; set; }
        public List<LogPlayerLogout> PlayerLogoutEvents { get; set; }
        public List<LogPlayerPosition> PlayerPositionEvents { get; set; }
        public List<LogPlayerTakeDamage> PlayerTakeDamageEvents { get; set; }
        public List<LogSwimEnd> SwimEndEvents { get; set; }
        public List<LogSwimStart> SwimStartEvents { get; set; }
        public List<LogVehicleDestroy> VehicleDestroyEvents { get; set; }
        public List<LogVehicleLeave> VehicleLeaveEvents { get; set; }
        public List<LogVehicleRide> VehicleRideEvents { get; set; }

        #endregion

        public Telemetry()
        {
            this.ArmorDestroyEvents = new List<LogArmorDestroy>();
            this.CarePackageLandEvents = new List<LogCarePackageLand>();
            this.CarePackageSpawnEvents = new List<LogCarePackageSpawn>();
            this.GameStatePeriodicEvents = new List<LogGameStatePeriodic>();
            this.ItemAttachEvents = new List<LogItemAttach>();
            this.ItemDetachEvents = new List<LogItemDetach>();
            this.ItemDropEvents = new List<LogItemDrop>();
            this.ItemEquipEvents = new List<LogItemEquip>();
            this.ItemPickupEvents = new List<LogItemPickup>();
            this.ItemUnequipEvents = new List<LogItemUnequip>();
            this.ItemUseEvents = new List<LogItemUse>();
            this.MatchDefinitionEvents = new List<LogMatchDefinition>();
            this.MatchEndEvents = new List<LogMatchEnd>();
            this.MatchStartEvents = new List<LogMatchStart>();
            this.PlayerAttackEvents = new List<LogPlayerAttack>();
            this.PlayerCreateEvents = new List<LogPlayerCreate>();
            this.PlayerKillEvents = new List<LogPlayerKill>();
            this.PlayerLoginEvents = new List<LogPlayerLogin>();
            this.PlayerLogoutEvents = new List<LogPlayerLogout>();
            this.PlayerPositionEvents = new List<LogPlayerPosition>();
            this.PlayerTakeDamageEvents = new List<LogPlayerTakeDamage>();
            this.SwimEndEvents = new List<LogSwimEnd>();
            this.SwimStartEvents = new List<LogSwimStart>();
            this.VehicleDestroyEvents = new List<LogVehicleDestroy>();
            this.VehicleLeaveEvents = new List<LogVehicleLeave>();
            this.VehicleRideEvents = new List<LogVehicleRide>();
        }

        public static Telemetry Deserialize(string json)
        {
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(json);

            Telemetry t = new Telemetry();

            foreach (dynamic obj in results)
            {
                switch ((string)obj._T)
                {
                    case "LogPlayerLogin":
                        LogPlayerLogin playerLogin = new LogPlayerLogin()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AccountId = obj.accountId
                        };
                        break;
                    case "LogPlayerCreate":
                        LogPlayerCreate playerCreate = new LogPlayerCreate()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = new Character()
                            {
                                AccountId = obj.character.accountId,
                                Health = obj.character.health,
                                Location = new Location()
                                {
                                    X = obj.character.location.x,
                                    Y = obj.character.location.y,
                                    Z = obj.character.location.z
                                },
                                Name = obj.character.name,
                                Ranking = obj.character.ranking,
                                TeamId = obj.character.teamId
                            }
                        };

                        t.PlayerCreateEvents.Add(playerCreate);
                        break;
                    case "LogPlayerPosition":
                        LogPlayerPosition playerPosition = new LogPlayerPosition()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = new Character()
                            {
                                AccountId = obj.character.accountId,
                                Health = obj.character.health,
                                Location = new Location()
                                {
                                    X = obj.character.location.x,
                                    Y = obj.character.location.y,
                                    Z = obj.character.location.z
                                },
                                Name = obj.character.name,
                                Ranking = obj.character.ranking,
                                TeamId = obj.character.teamId
                            },
                            ElapsedTime = obj.elapsedTime,
                            NumAlivePlayers = obj.numAlivePlayers
                        };

                        t.PlayerPositionEvents.Add(playerPosition);
                        break;
                    case "LogPlayerAttack":
                        LogPlayerAttack playerAttack = new LogPlayerAttack()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Attacker = new Character()
                            {
                                AccountId = obj.attacker.accountId,
                                Health = obj.attacker.health,
                                Location = new Location()
                                {
                                    X = obj.attacker.location.x,
                                    Y = obj.attacker.location.y,
                                    Z = obj.attacker.location.z
                                },
                                Name = obj.attacker.name,
                                Ranking = obj.attacker.ranking,
                                TeamId = obj.attacker.teamId
                            },
                            AttackId = obj.attackId,
                            AttackType = String.IsNullOrWhiteSpace(Convert.ToString(obj.attackType)) ? null : Enum.Parse(typeof(AttackType), Convert.ToString(obj.attackType)),
                            Weapon = new Item()
                            {
                                AttachedItems = ((JArray) obj.weapon.attachedItems).Select(jv => (string)jv).ToArray(),
                                Category = String.IsNullOrWhiteSpace(Convert.ToString(obj.weapon.category)) ? null : Enum.Parse(typeof(Category), Convert.ToString(obj.weapon.category)),
                                ItemId = obj.weapon.itemId,
                                StackCount = obj.weapon.stackCount,
                                SubCategory = String.IsNullOrWhiteSpace(Convert.ToString(obj.weapon.subCategory)) ? null : Enum.Parse(typeof(SubCategory), Convert.ToString(obj.weapon.subCategory))
                            },
                            Vehicle = new Vehicle()
                            {
                                FuelPercent = obj.vehicle.fuelPercent,
                                HealthPercent = obj.vehicle.healthPercent,
                                VehicleId = obj.vehicle.vehicleId,
                                VehicleType = String.IsNullOrWhiteSpace(Convert.ToString(obj.vehicle.vehicleType)) ? null : Enum.Parse(typeof(VehicleType), Convert.ToString(obj.vehicle.vehicleType))
                            }
                        };
                        break;
                    case "LogItemPickup":
                        LogItemPickup playerPickup = new LogItemPickup()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = new Character()
                            {
                                AccountId = obj.character.accountId,
                                Health = obj.character.health,
                                Location = new Location()
                                {
                                    X = obj.character.location.x,
                                    Y = obj.character.location.y,
                                    Z = obj.character.location.z
                                },
                                Name = obj.character.name,
                                Ranking = obj.character.ranking,
                                TeamId = obj.character.teamId
                            },
                            Item = new Item()
                            {
                                AttachedItems = ((JArray)obj.item.attachedItems).Select(jv => (string)jv).ToArray(),
                                Category = String.IsNullOrWhiteSpace(Convert.ToString(obj.item.category)) ? null : Enum.Parse(typeof(Category), Convert.ToString(obj.item.category)),
                                ItemId = obj.item.itemId,
                                StackCount = obj.item.stackCount,
                                SubCategory = String.IsNullOrWhiteSpace(Convert.ToString(obj.item.subCategory)) ? null : Enum.Parse(typeof(SubCategory), Convert.ToString(obj.item.subCategory))
                            },
                        };
                        break;
                    case "LogItemEquip":
                        LogItemEquip playerEquip = new LogItemEquip()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = new Character()
                            {
                                AccountId = obj.character.accountId,
                                Health = obj.character.health,
                                Location = new Location()
                                {
                                    X = obj.character.location.x,
                                    Y = obj.character.location.y,
                                    Z = obj.character.location.z
                                },
                                Name = obj.character.name,
                                Ranking = obj.character.ranking,
                                TeamId = obj.character.teamId
                            },
                            Item = new Item()
                            {
                                AttachedItems = ((JArray)obj.item.attachedItems).Select(jv => (string)jv).ToArray(),
                                Category = String.IsNullOrWhiteSpace(Convert.ToString(obj.item.category)) ? null : Enum.Parse(typeof(Category), Convert.ToString(obj.item.category)),
                                ItemId = obj.item.itemId,
                                StackCount = obj.item.stackCount,
                                SubCategory = String.IsNullOrWhiteSpace(Convert.ToString(obj.item.subCategory)) ? null : Enum.Parse(typeof(SubCategory), Convert.ToString(obj.item.subCategory))
                            },
                        };
                        break;
                    case "LogItemUnequip":
                        LogItemUnequip playerUnequip = new LogItemUnequip()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogVehicleRide":
                        LogVehicleRide playerRide = new LogVehicleRide()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogMatchDefinition":
                        LogMatchDefinition matchDefinition = new LogMatchDefinition()
                        {
                            Timestamp = obj._D,
                            Type = obj._T
                        };
                        break;
                    case "LogMatchStart":
                        LogMatchStart matchStart = new LogMatchStart()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogGameStatePeriodic":
                        LogGameStatePeriodic GameStatePeriodic = new LogGameStatePeriodic()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogVehicleLeave":
                        LogVehicleLeave vehicleLeave = new LogVehicleLeave()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogPlayerTakeDamage":
                        LogPlayerTakeDamage playerTakeDamage = new LogPlayerTakeDamage()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogPlayerLogout":
                        LogPlayerLogout playerLogout = new LogPlayerLogout()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogItemAttach":
                        LogItemAttach itemAttach = new LogItemAttach()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogItemDrop":
                        LogItemDrop itemDrop = new LogItemDrop()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogPlayerKill":
                        LogPlayerKill playerKill = new LogPlayerKill()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogItemDetach":
                        LogItemDetach itemDetach = new LogItemDetach()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogItemUse":
                        LogItemUse itemUse = new LogItemUse()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogCarePackageSpawn":
                        LogCarePackageSpawn carePackageSpawn = new LogCarePackageSpawn()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogVehicleDestroy":
                        LogVehicleDestroy vehicleDestroy = new LogVehicleDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogCarePackageLand":
                        LogCarePackageLand carePackageLand = new LogCarePackageLand()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogMatchEnd":
                        LogMatchEnd matchEnd = new LogMatchEnd()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogSwimStart":
                        LogSwimStart swimStart = new LogSwimStart()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogSwimEnd":
                        LogSwimEnd swimEnd = new LogSwimEnd()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    case "LogArmorDestroy":
                        LogArmorDestroy armorDestroy = new LogArmorDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            }

                        };
                        break;
                    default:
                        throw new NotImplementedException("Events list contained event not seen before.");
                }
            }

            return t;
        }

        public override string ToString()
        {
            string toString = "Telemetry:\n";
            foreach (LogPlayerCreate e in PlayerCreateEvents)
            {
                toString += e.ToString();
                toString += "\n";
            }
            foreach (LogPlayerPosition e in PlayerPositionEvents)
            {
                toString += e.ToString();
                toString += "\n";
            }

            return toString;
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public float Health { get; set; }
        public Location Location { get; set; }
        public int Ranking { get; set; }
        public string AccountId { get; set; }

        public override string ToString()
        {
            string toString = "Name: " + this.Name + "\n"
                + "TeamId: " + this.TeamId + "\n"
                + "Health: " + this.Health + "\n"
                + Location.ToString()
                + "Ranking: " + this.Ranking + "\n"
                + "AccountId: " + this.AccountId + "\n";

            return toString;
        }
    }

    public class Common
    {
        /// <remarks>
        /// isGame represents the phase of the game defined by the status of bluezone and safezone:
        /// isGame = 0 -> Before lift off
        /// isGame = 0.1->On airplane
        /// isGame = 0.5->When there’s no ‘zone’ on map(before game starts)
        /// isGame = 1.0 -> First safezone and bluezone appear
        /// isGame = 1.5->First bluezone shrinks
        /// isGame = 2.0 -> Second bluezone appears
        /// isGame = 2.5->Second bluezone shrinks
        /// ...
        /// </remarks>
        public float IsGame { get; set; }
    }

    public class GameState
    {
        public int ElapsedTime { get; set; }
        public int NumAliveTeams { get; set; }
        public int NumJoinPlayers { get; set; }
        public int NumStartPlayers { get; set; }
        public int NumAlivePlayers { get; set; }
        public Location SafetyZonePosition { get; set; }
        public float SafetyZoneRadius { get; set; }
        public Location PoisonGasWarningPosition { get; set; }
        public float PoisonGasWarningRadius { get; set; }
        public Location RedZonePosition { get; set; }
        public float RedZoneRadius { get; set; }
    }

    public class Item
    {
        public string ItemId { get; set; }
        public int StackCount { get; set; }
        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public string[] AttachedItems { get; set; }
    }

    public class ItemPackage
    {
        public string ItemPackageId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

    /// <remarks>
    /// The range for the X and Y axes is 0 - 816,000 for 8km maps.
    /// Location values are measured in centimeters
    /// </remarks>
    public class Location
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public override string ToString()
        {
            string toString = "X: " + this.X + "\n"
                + "Y: " + this.Y + "\n"
                + "Z: " + this.Z + "\n";
                
            return toString;
        }
    }

    public class Vehicle
    {
        public VehicleType? VehicleType { get; set; }
        public string VehicleId { get; set; }
        public float? HealthPercent { get; set; }
        public float? FuelPercent { get; set; }
    }

    public class Asset
    {
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public enum Category
    {
        Ammunition,
        Attachment,
        Equipment,
        Use,
        Weapon
    }

    public enum SubCategory
    {
        Backpack,
        Boost,
        Fuel,
        Handgun,
        Headgear,
        Heal,
        Jacket,
        Main,
        Melee,
        None,
        Throwable,
        Vest
    }

    public enum MapName
    {
        Desert_Main,
        Erangel_Main,
        Savage_Main
    }

    public enum VehicleType
    {
        FloatingVehicle,
        Parachute,
        TransportAircraft,
        WheeledVehicle
    }

    public enum AttackType
    {
        RedZone,
        Weapon
    }

    public enum DamageReason
    {
        ArmShot,
        HeadShot,
        LegShot,
        None,
        NonSpecific,
        PelvisShot,
        TorsoShot
    }
}
