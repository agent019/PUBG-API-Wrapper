using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Verify all of these objects deserialize correctly
namespace PUBGAPIWrapper.Models
{
    /// <summary>
    /// Object representation of the Telemetry for a specific PUBG Match.
    /// Contains lists for each of the type of possible events.
    /// </summary>
    public class Telemetry
    {
        #region Properties

        public List<LogArmorDestroy> ArmorDestroyEvents { get; set; }
        public List<LogCarePackageLand> CarePackageLandEvents { get; set; }
        public List<LogCarePackageSpawn> CarePackageSpawnEvents { get; set; }
        public List<LogGameStatePeriodic> GameStatePeriodicEvents { get; set; }
        public List<LogHeal> HealEvents { get; set; }
        public List<LogItemAttach> ItemAttachEvents { get; set; }
        public List<LogItemDetach> ItemDetachEvents { get; set; }
        public List<LogItemDrop> ItemDropEvents { get; set; }
        public List<LogItemEquip> ItemEquipEvents { get; set; }
        public List<LogItemPickup> ItemPickupEvents { get; set; }
        public List<LogItemPickupFromCarepackage> ItemPickupFromCarePackageEvents { get; set; }
        public List<LogItemPickupFromLootBox> ItemPickupFromLootBoxEvents { get; set; }
        public List<LogItemUnequip> ItemUnequipEvents { get; set; }
        public List<LogItemUse> ItemUseEvents { get; set; }
        public List<LogMatchDefinition> MatchDefinitionEvents { get; set; }
        public List<LogMatchEnd> MatchEndEvents { get; set; }
        public List<LogMatchStart> MatchStartEvents { get; set; }
        public List<LogObjectDestroy> ObjectDestroyEvents { get; set; }
        public List<LogParachuteLanding> ParachuteLandingEvents { get; set; }
        public List<LogPlayerAttack> PlayerAttackEvents { get; set; }
        public List<LogPlayerCreate> PlayerCreateEvents { get; set; }
        public List<LogPlayerKill> PlayerKillEvents { get; set; }
        public List<LogPlayerLogin> PlayerLoginEvents { get; set; }
        public List<LogPlayerLogout> PlayerLogoutEvents { get; set; }
        public List<LogPlayerMakeGroggy> PlayerMakeGroggyEvents { get; set; }
        public List<LogPlayerPosition> PlayerPositionEvents { get; set; }
        public List<LogPlayerTakeDamage> PlayerTakeDamageEvents { get; set; }
        public List<LogRedZoneEnded> RedZoneEndedEvents { get; set; }
        public List<LogSwimEnd> SwimEndEvents { get; set; }
        public List<LogSwimStart> SwimStartEvents { get; set; }
        public List<LogVaultStart> VaultStartEvents { get; set; }
        public List<LogVehicleDestroy> VehicleDestroyEvents { get; set; }
        public List<LogVehicleLeave> VehicleLeaveEvents { get; set; }
        public List<LogVehicleRide> VehicleRideEvents { get; set; }
        public List<LogWeaponFireCount> WeaponFireCountEvents { get; set; }
        public List<LogWheelDestroy> WheelDestroyEvents { get; set; }

        #endregion

        public Telemetry()
        {
            this.ArmorDestroyEvents = new List<LogArmorDestroy>();
            this.CarePackageLandEvents = new List<LogCarePackageLand>();
            this.CarePackageSpawnEvents = new List<LogCarePackageSpawn>();
            this.GameStatePeriodicEvents = new List<LogGameStatePeriodic>();
            this.HealEvents = new List<LogHeal>();
            this.ItemAttachEvents = new List<LogItemAttach>();
            this.ItemDetachEvents = new List<LogItemDetach>();
            this.ItemDropEvents = new List<LogItemDrop>();
            this.ItemEquipEvents = new List<LogItemEquip>();
            this.ItemPickupEvents = new List<LogItemPickup>();
            this.ItemPickupFromCarePackageEvents = new List<LogItemPickupFromCarepackage>();
            this.ItemPickupFromLootBoxEvents = new List<LogItemPickupFromLootBox>();
            this.ItemUnequipEvents = new List<LogItemUnequip>();
            this.ItemUseEvents = new List<LogItemUse>();
            this.MatchDefinitionEvents = new List<LogMatchDefinition>();
            this.MatchEndEvents = new List<LogMatchEnd>();
            this.MatchStartEvents = new List<LogMatchStart>();
            this.ObjectDestroyEvents = new List<LogObjectDestroy>();
            this.ParachuteLandingEvents = new List<LogParachuteLanding>();
            this.PlayerAttackEvents = new List<LogPlayerAttack>();
            this.PlayerCreateEvents = new List<LogPlayerCreate>();
            this.PlayerKillEvents = new List<LogPlayerKill>();
            this.PlayerLoginEvents = new List<LogPlayerLogin>();
            this.PlayerLogoutEvents = new List<LogPlayerLogout>();
            this.PlayerMakeGroggyEvents = new List<LogPlayerMakeGroggy>();
            this.PlayerPositionEvents = new List<LogPlayerPosition>();
            this.PlayerTakeDamageEvents = new List<LogPlayerTakeDamage>();
            this.RedZoneEndedEvents = new List<LogRedZoneEnded>();
            this.SwimEndEvents = new List<LogSwimEnd>();
            this.SwimStartEvents = new List<LogSwimStart>();
            this.VaultStartEvents = new List<LogVaultStart>();
            this.VehicleDestroyEvents = new List<LogVehicleDestroy>();
            this.VehicleLeaveEvents = new List<LogVehicleLeave>();
            this.WeaponFireCountEvents = new List<LogWeaponFireCount>();
            this.VehicleRideEvents = new List<LogVehicleRide>();
            this.WheelDestroyEvents = new List<LogWheelDestroy>();
        }

        private static Character BuildCharacter(dynamic obj)
        {
            return new Character()
            {
                AccountId = obj?.accountId,
                Health = obj?.health,
                Location = new Location()
                {
                    X = obj?.location?.x,
                    Y = obj?.location?.y,
                    Z = obj?.location?.z
                },
                Name = obj?.name,
                Ranking = obj?.ranking,
                TeamId = obj?.teamId,
                IsInBlueZone = obj?.isInBlueZone,
                IsInRedZone = obj?.isInRedZone,
                //Zone = (RegionId)Enum.Parse(typeof(RegionId), (string)obj.zone)
            };
        }

        private static List<Character> BuildCharacterList(dynamic obj)
        {
            List<Character> characters = new List<Character>();
            foreach (var character in obj)
            {
                characters.Add(BuildCharacter(character));
            }
            return characters;
        }

        private static Item BuildItem(dynamic obj)
        {
            return new Item()
            {
                AttachedItems = ((JArray)obj?.attachedItems).Select(jv => (string)jv).ToArray(),
                Category = String.IsNullOrWhiteSpace(Convert.ToString(obj?.category)) ? null : Enum.Parse(typeof(Category), Convert.ToString(obj?.category)),
                ItemId = obj?.itemId,
                StackCount = obj?.stackCount,
                SubCategory = String.IsNullOrWhiteSpace(Convert.ToString(obj?.subCategory)) ? null : Enum.Parse(typeof(SubCategory), Convert.ToString(obj?.subCategory))
            };
        }

        private static Vehicle BuildVehicle(dynamic obj)
        {
            return new Vehicle()
            {
                // "feulPercent" is misspelled on purpose: https://documentation.pubg.com/en/known-issues.html
                FuelPercent = obj?.feulPercent,
                HealthPercent = obj?.healthPercent,
                VehicleId = obj?.vehicleId,
                VehicleType = String.IsNullOrWhiteSpace(Convert.ToString(obj?.vehicleType)) ? null : Enum.Parse(typeof(VehicleType), Convert.ToString(obj?.vehicleType))
            };
        }

        private static GameState BuildGameState(dynamic obj)
        {
            return new GameState()
            {
                ElapsedTime = obj.elapsedTime,
                NumAliveTeams = obj.numAliveTeams,
                NumJoinPlayers = obj.numJoinPlayers,
                NumStartPlayers = obj.numStartPlayers,
                NumAlivePlayers = obj.numAlivePlayers,
                SafetyZonePosition = BuildLocation(obj.safetyZonePosition),
                SafetyZoneRadius = obj.safetyZoneRadius,
                PoisonGasWarningPosition = BuildLocation(obj.poisonGasWarningPosition),
                PoisonGasWarningRadius = obj.poisonGasWarningRadius,
                RedZonePosition = BuildLocation(obj.redZonePosition),
                RedZoneRadius = obj.redZoneRadius
            };
        }

        private static Location BuildLocation(dynamic obj)
        {
            return new Location()
            {
                X = obj.x,
                Y = obj.y,
                Z = obj.z
            };
        }

        private static ItemPackage BuildItemPackage(dynamic obj)
        {
            List<Item> items = new List<Item>();
            foreach (var item in obj.items)
            {
                items.Add(BuildItem(item));
            }
            return new ItemPackage()
            {
                ItemPackageId = obj.itemPackageId,
                Location = BuildLocation(obj.location),
                Items = items
            };
        }

        public static Telemetry Deserialize(string json)
        {
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(json);

            Telemetry t = new Telemetry();

            foreach (dynamic obj in results)
            {
                switch ((string)obj._T)
                {
                    case "LogArmorDestroy":
                        LogArmorDestroy armorDestroy = new LogArmorDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AttackId = obj.attackId,
                            Attacker = BuildCharacter(obj.attacker),
                            Victim = BuildCharacter(obj.victim),
                            DamageTypeCategory = obj.damageTypeCategory,
                            DamageReason = String.IsNullOrWhiteSpace(Convert.ToString(obj.damageReason)) ? null : Enum.Parse(typeof(DamageReason), Convert.ToString(obj.damageReason)),
                            DamageCauserName = obj.damageCauserName,
                            Item = BuildItem(obj.item),
                            Distance = obj.distance
                        };
                        t.ArmorDestroyEvents.Add(armorDestroy);
                        break;
                    case "LogCarePackageLand":
                        LogCarePackageLand carePackageLand = new LogCarePackageLand()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            ItemPackage = BuildItemPackage(obj.itemPackage)
                        };
                        t.CarePackageLandEvents.Add(carePackageLand);
                        break;
                    case "LogCarePackageSpawn":
                        LogCarePackageSpawn carePackageSpawn = new LogCarePackageSpawn()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            ItemPackage = BuildItemPackage(obj.itemPackage)
                        };
                        t.CarePackageSpawnEvents.Add(carePackageSpawn);
                        break;
                    case "LogGameStatePeriodic":
                        LogGameStatePeriodic gameStatePeriodic = new LogGameStatePeriodic()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            GameState = BuildGameState(obj.gameState)
                        };
                        t.GameStatePeriodicEvents.Add(gameStatePeriodic);
                        break;
                    case "LogHeal":
                        LogHeal heal = new LogHeal()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            HealAmount = obj.healAmount,
                            Item = BuildItem(obj.item)
                        };
                        t.HealEvents.Add(heal);
                        break;
                    case "LogItemAttach":
                        LogItemAttach itemAttach = new LogItemAttach()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            ParentItem = BuildItem(obj.parentItem),
                            ChildItem = BuildItem(obj.childItem)
                        };
                        t.ItemAttachEvents.Add(itemAttach);
                        break;
                    case "LogItemDetach":
                        LogItemDetach itemDetach = new LogItemDetach()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            ParentItem = BuildItem(obj.parentItem),
                            ChildItem = BuildItem(obj.childItem)
                        };
                        t.ItemDetachEvents.Add(itemDetach);
                        break;
                    case "LogItemDrop":
                        LogItemDrop itemDrop = new LogItemDrop()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemDropEvents.Add(itemDrop);
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
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemEquipEvents.Add(playerEquip);
                        break;
                    case "LogItemPickup":
                        LogItemPickup itemPickup = new LogItemPickup()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemPickupEvents.Add(itemPickup);
                        break;
                    case "LogItemPickupFromCarepackage":
                        LogItemPickupFromCarepackage playerPickupFromCarepackage = new LogItemPickupFromCarepackage()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemPickupFromCarePackageEvents.Add(playerPickupFromCarepackage);
                        break;
                    case "LogItemPickupFromLootBox":
                        LogItemPickupFromLootBox playerPickupFromLootBox = new LogItemPickupFromLootBox()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item),
                            OwnerTeamId = obj.ownerTeamId
                        };
                        t.ItemPickupFromLootBoxEvents.Add(playerPickupFromLootBox);
                        break;
                    case "LogItemUnequip":
                        LogItemUnequip playerUnequip = new LogItemUnequip()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemUnequipEvents.Add(playerUnequip);
                        break;
                    case "LogItemUse":
                        LogItemUse itemUse = new LogItemUse()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Item = BuildItem(obj.item)
                        };
                        t.ItemUseEvents.Add(itemUse);
                        break;
                    case "LogMatchDefinition":
                        LogMatchDefinition matchDefinition = new LogMatchDefinition()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            MatchId = obj.MatchId,
                            PingQuality = obj.PingQuality,
                            SeasonState = obj.SeasonState
                            // This item actually doesnt have a common field
                        };
                        t.MatchDefinitionEvents.Add(matchDefinition);
                        break;
                    case "LogMatchEnd":
                        LogMatchEnd matchEnd = new LogMatchEnd()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Characters = BuildCharacterList(obj.characters)
                        };
                        t.MatchEndEvents.Add(matchEnd);
                        break;
                    case "LogMatchStart":
                        LogMatchStart matchStart = new LogMatchStart()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            MapName = obj.mapName,
                            WeatherId = obj.weatherId,
                            Characters = BuildCharacterList(obj.characters),
                            CameraViewBehaviour = obj.cameraViewBehaviour,
                            TeamSize = obj.teamSize,
                            IsCustomGame = obj.isCustomGame,
                            IsEventMode = obj.isEventMode,
                            // BlueZoneCustomOptions = obj.blueZoneCustomOptions
                        };
                        t.MatchStartEvents.Add(matchStart);
                        break;
                    case "LogObjectDestroy":
                        LogObjectDestroy objectDestroy = new LogObjectDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            ObjectType = obj.objectType,
                            ObjectLocation = BuildLocation(obj.objectLocation)
                        };
                        t.ObjectDestroyEvents.Add(objectDestroy);
                        break;
                    case "LogParachuteLanding":
                        LogParachuteLanding parachuteLanding = new LogParachuteLanding()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Distance = obj.distance
                        };
                        t.ParachuteLandingEvents.Add(parachuteLanding);
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
                            Attacker = BuildCharacter(obj.attacker),
                            AttackId = obj.attackId,
                            FireWeaponStackCount = obj.fireWeaponStackCount,
                            AttackType = String.IsNullOrWhiteSpace(Convert.ToString(obj.attackType)) ? null : Enum.Parse(typeof(AttackType), Convert.ToString(obj.attackType)),
                            Weapon = BuildItem(obj.weapon),
                            Vehicle = obj?.vehicle != null ? BuildVehicle(obj.vehicle) : null
                        };
                        t.PlayerAttackEvents.Add(playerAttack);
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
                            Character = BuildCharacter(obj.character)
                        };
                        t.PlayerCreateEvents.Add(playerCreate);
                        break;
                    case "LogPlayerKill":
                        LogPlayerKill playerKill = new LogPlayerKill()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AttackId = obj.attackId,
                            Killer = BuildCharacter(obj.killer),
                            Victim = BuildCharacter(obj.victim),
                            Assistant = BuildCharacter(obj.assistant),
                            DBNOId = obj.dBNOId,
                            DamageTypeCategory = obj.damageTypeCategory,
                            DamageCauserName = obj.damageCauserName,
                            // DamageCauserAdditionalInfo = obj.damageCauserAdditionalInfo,
                            DamageReason = String.IsNullOrWhiteSpace(Convert.ToString(obj.damageReason)) ? null : Enum.Parse(typeof(DamageReason), Convert.ToString(obj.damageReason)),
                            Distance = obj.distance,
                            VictimGameResult = new GameResult()
                            {
                                AccountId = obj.victimGameResult.accountId,
                                Rank = obj.victimGameResult.rank,
                                Result = obj.victimGameResult.result,
                                Stats = new GameStats()
                                {
                                    KillCount = obj.victimGameResult.stats.killCount,
                                    DistanceOnFoot = obj.victimGameResult.stats.distanceOnFoot,
                                    DistanceOnFreefall = obj.victimGameResult.stats.distanceOnFreefall,
                                    DistanceOnParachute = obj.victimGameResult.stats.distanceOnParachute,
                                    DistanceOnSwim = obj.victimGameResult.stats.distanceOnSwim,
                                    DistanceOnVehicle = obj.victimGameResult.stats.distanceOnVehicle
                                },
                                TeamId = obj.victimGameResult.teamId
                            }
                        };
                        t.PlayerKillEvents.Add(playerKill);
                        break;
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
                        t.PlayerLoginEvents.Add(playerLogin);
                        break;
                    case "LogPlayerLogout":
                        LogPlayerLogout playerLogout = new LogPlayerLogout()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AccountId = obj.accountId
                        };
                        t.PlayerLogoutEvents.Add(playerLogout);
                        break;
                    case "LogPlayerMakeGroggy":
                        LogPlayerMakeGroggy playerMakeGroggy = new LogPlayerMakeGroggy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Attacker = BuildCharacter(obj.attacker),
                            Victim = BuildCharacter(obj.victim),
                            AttackId = obj.attackId,
                            // DamageCauserAdditionalInfo = obj.damageCauserAdditionalInfo,
                            DamageCauserName = obj.damageCauserName,
                            DamageReason = String.IsNullOrWhiteSpace(Convert.ToString(obj.damageReason)) ? null : Enum.Parse(typeof(DamageReason), Convert.ToString(obj.damageReason)),
                            DamageTypeCategory = obj.damageTypeCategory,
                            DBNOId = obj.dBNOId,
                            Distance = obj.distance,
                            IsAttackerInVehicle = obj.isAttackerInVehicle
                        };
                        t.PlayerMakeGroggyEvents.Add(playerMakeGroggy);
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
                            Character = BuildCharacter(obj.character),
                            Vehicle = BuildVehicle(obj.vehicle),
                            ElapsedTime = obj.elapsedTime,
                            NumAlivePlayers = obj.numAlivePlayers
                        };
                        t.PlayerPositionEvents.Add(playerPosition);
                        break;
                    case "LogPlayerTakeDamage":
                        LogPlayerTakeDamage playerTakeDamage = new LogPlayerTakeDamage()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AttackId = obj.attackId,
                            Attacker = BuildCharacter(obj.attacker),
                            Victim = BuildCharacter(obj.victim),
                            DamageTypeCategory = obj.damageTypeCategory,
                            DamageReason = String.IsNullOrWhiteSpace(Convert.ToString(obj.damageReason)) ? null : Enum.Parse(typeof(DamageReason), Convert.ToString(obj.damageReason)),
                            Damage = obj.damage,
                            DamageCauserName = obj.damageCauserName
                        };
                        t.PlayerTakeDamageEvents.Add(playerTakeDamage);
                        break;
                    case "LogRedZoneEnded":
                        LogRedZoneEnded redZoneEnded = new LogRedZoneEnded()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Drivers = BuildCharacterList(obj.drivers)
                        };
                        t.RedZoneEndedEvents.Add(redZoneEnded);
                        break;
                    case "LogSwimEnd":
                        LogSwimEnd swimEnd = new LogSwimEnd()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            SwimDistance = obj.swimDistance,
                            MaxSwimDepthOfWater = obj.maxSwimDepthOfWater
                        };
                        t.SwimEndEvents.Add(swimEnd);
                        break;
                    case "LogSwimStart":
                        LogSwimStart swimStart = new LogSwimStart()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                        };
                        t.SwimStartEvents.Add(swimStart);
                        break;
                    case "LogVaultStart":
                        LogVaultStart vaultStart = new LogVaultStart()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                        };
                        t.VaultStartEvents.Add(vaultStart);
                        break;
                    case "LogVehicleDestroy":
                        LogVehicleDestroy vehicleDestroy = new LogVehicleDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AttackId = obj.attackId,
                            Attacker = BuildCharacter(obj.attacker),
                            Vehicle = BuildVehicle(obj.vehicle),
                            DamageTypeCategory = obj.damageTypeCategory,
                            DamageCauserName = obj.damageCauserName,
                            Distance = obj.distance
                        };
                        t.VehicleDestroyEvents.Add(vehicleDestroy);
                        break;
                    case "LogVehicleLeave":
                        LogVehicleLeave vehicleLeave = new LogVehicleLeave()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Vehicle = BuildVehicle(obj.vehicle),
                            RideDistance = obj.rideDistance,
                            SeatIndex = obj.seatIndex,
                            MaxSpeed = obj.maxSpeed
                        };
                        t.VehicleLeaveEvents.Add(vehicleLeave);
                        break;
                    case "LogVehicleRide":
                        LogVehicleRide playerRide = new LogVehicleRide()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            Vehicle = BuildVehicle(obj.vehicle)
                        };
                        t.VehicleRideEvents.Add(playerRide);
                        break;
                    case "LogWeaponFireCount":
                        LogWeaponFireCount weaponFireCount = new LogWeaponFireCount()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            Character = BuildCharacter(obj.character),
                            FireCount = obj.fireCount,
                            WeaponId = obj.weaponId
                        };
                        t.WeaponFireCountEvents.Add(weaponFireCount);
                        break;
                    case "LogWheelDestroy":
                        LogWheelDestroy wheelDestroy = new LogWheelDestroy()
                        {
                            Timestamp = obj._D,
                            Type = obj._T,
                            Common = new Common()
                            {
                                IsGame = obj.common.isGame
                            },
                            AttackId = obj.attackId,
                            Attacker = BuildCharacter(obj.attacker),
                            Vehicle = BuildVehicle(obj.vehicle),
                            DamageTypeCategory = obj.damageTypeCategory,
                            DamageCauserName = obj.damageCauserName
                        };
                        t.WheelDestroyEvents.Add(wheelDestroy);
                        break;
                    default:
                        continue;
                        throw new NotImplementedException("Events list contained event not seen before.");
                }
            }

            return t;
        }
    }

    public class BlueZoneCustomOptions
    {
        public int PhaseNum { get; set; }
        public int StartDelay { get; set; }
        public int WarningDuration { get; set; }
        public int ReleaseDuration { get; set; }
        public double PoisonGasDamagePerSecond { get; set; }
        public double RadiusRate { get; set; }
        public double SpreadRatio { get; set; }
        public double LandRatio { get; set; }
        public int CircleAlgorithm { get; set; }
    }

    public class Character
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public double Health { get; set; }
        public Location Location { get; set; }
        public int Ranking { get; set; }
        public string AccountId { get; set; }
        public bool IsInBlueZone { get; set; }
        public bool IsInRedZone { get; set; }
        public RegionId Zone { get; set; }
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
        public double IsGame { get; set; }
    }

    public class GameResult
    {
        public int Rank { get; set; }
        [JsonProperty("gameResult")]
        public string Result { get; set; }
        public int TeamId { get; set; }
        public GameStats Stats { get; set; }
        public string AccountId { get; set; }
    }

    public class GameState
    {
        public int ElapsedTime { get; set; }
        public int NumAliveTeams { get; set; }
        public int NumJoinPlayers { get; set; }
        public int NumStartPlayers { get; set; }
        public int NumAlivePlayers { get; set; }
        public Location SafetyZonePosition { get; set; }
        public double SafetyZoneRadius { get; set; }
        public Location PoisonGasWarningPosition { get; set; }
        public double PoisonGasWarningRadius { get; set; }
        public Location RedZonePosition { get; set; }
        public double RedZoneRadius { get; set; }
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
        public List<Item> Items { get; set; }
    }

    /// <remarks>
    /// The range for the X and Y axes is 0 - 816,000 for 8km maps.
    /// Location values are measured in centimeters
    /// </remarks>
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class GameStats
    {
        public int KillCount { get; set; }
        public double DistanceOnFoot { get; set; }
        public double DistanceOnSwim { get; set; }
        public double DistanceOnVehicle { get; set; }
        public double DistanceOnParachute { get; set; }
        public double DistanceOnFreefall { get; set; }
    }

    public class Vehicle
    {
        public VehicleType? VehicleType { get; set; }
        public string VehicleId { get; set; }
        public double? HealthPercent { get; set; }
        public double? FuelPercent { get; set; }
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
        Savage_Main,
        DihorOtok_Main
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

    public enum RegionId
    {
        #region Desert_Main

        alcantara,
        ruins,
        lacobreria,
        trailerpark,
        craterfields,
        elpozo,
        watertreatment,
        sanmartin,
        heciendadelpatron,
        powergrid,
        cruzdelvalle,
        torreahumada,
        campomilitar,
        tierrabronca,
        elazahar,
        junkyard,
        minasgenerales,
        graveyard,
        montenuevo,
        ladrillera,
        chumacera,
        pecado,
        labendita,
        lmpala,
        losleones,
        puertoparaiso,
        loshigos,
        prison,
        minasdelsur,
        valledelmar,

        #endregion

        #region DihorOtok_Main

        port,
        cosmodrome,
        trevno,
        peshkova,
        mountkreznic,
        goroka,
        dobromesto,
        vihar,
        movatra,
        dinopark,
        tovar,
        castle,
        podvosto,
        cementfactory,
        cantra,
        hotspring,
        volnova,
        abbey,
        winery,
        milnar,
        zabava,
        krichas,
        coalmine,
        lumberyard,
        pilnec,
        sawmill,

        #endregion

        #region Erangel_Main
        
        zharki,
        shootingrange,
        severny,
        stalber,
        kameshki,
        yasnayapolyana,
        lipovka,
        mansion,
        shelter,
        //prison,
        myltapower,
        mylta,
        farm,
        rozhok,
        school,
        georgopol,
        hospital,
        gatka,
        quarry,
        primorsk,
        ferrypier,
        sosnovkamilitarybase,
        novorepnoye,
        //ruins,
        pochinki,

        #endregion

        #region Savage_Main
        
        kampong,
        dock,
        lawaki,
        campbravo,
        mongnai,
        khao,
        tatmok,
        paradiseresort,
        bootcamp,
        //quarry,
        cave,
        bahn,
        campalpha,
        campcharlie,
        bantai,
        painan,
        sahmee,
        nakham,
        tambang,
        //ruins,
        hatinh,

        #endregion
    }

    public enum WeatherId
    {
        Clear,
        Clear_02,
        Dark,
        Night,
        Overcast,
        Snow,
        Sunrise,
        Sunset,
        Weather_Range_Sunset
    }
}
