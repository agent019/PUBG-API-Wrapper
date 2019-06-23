using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class TelemetryTests
    {
        #region Test Data

        public readonly string SampleEventsArrayJson = @"[
    {
        ""MatchId"": ""match.bro.official.pc-2018-03.steam.squad.sa.2019.06.19.23.546b7a2d-92ef-49c5-926c-7a1101497006"",
        ""PingQuality"": ""low"",
        ""SeasonState"": ""closed"",
        ""_D"": ""2019-06-19T23:36:54.894336Z"",
        ""_T"": ""LogMatchDefinition""
    },
    {
        ""accountId"": ""account.id-123"",
        ""common"": {
            ""isGame"": 0
        },
        ""_D"": ""2019-06-19T23:34:29.017Z"",
        ""_T"": ""LogPlayerLogin""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 796827.4375,
                ""y"": 20855.162109375,
                ""z"": 547.231201171875
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""common"": {
            ""isGame"": 0
        },
        ""_D"": ""2019-06-19T23:34:29.034Z"",
        ""_T"": ""LogPlayerCreate""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 796827.4375,
                ""y"": 20855.162109375,
                ""z"": 528.5342407226563
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""vehicle"": {
            ""vehicleType"": """",
            ""vehicleId"": """",
            ""healthPercent"": 0,
            ""feulPercent"": 0
        },
        ""elapsedTime"": 0,
        ""numAlivePlayers"": 43,
        ""common"": {
            ""isGame"": 0
        },
        ""_D"": ""2019-06-19T23:34:39.045Z"",
        ""_T"": ""LogPlayerPosition""
    },
    {
        ""attackId"": 1644167213,
        ""attacker"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 468019.34375,
                ""y"": 644856.4375,
                ""z"": 161.77999877929688
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""sosnovkamilitarybase""
            ]
        },
        ""victim"": {
            ""name"": ""Player2"",
            ""teamId"": 2,
            ""health"": 0,
            ""location"": {
                ""x"": 467627.0625,
                ""y"": 645212,
                ""z"": 133.75
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-456"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""sosnovkamilitarybase""
            ]
        },
        ""damageTypeCategory"": ""Damage_Gun"",
        ""damageReason"": ""TorsoShot"",
        ""damageCauserName"": ""WeapBerylM762_C"",
        ""item"": {
            ""itemId"": ""Item_Armor_D_01_Lv2_C"",
            ""stackCount"": 1,
            ""category"": ""Equipment"",
            ""subCategory"": ""Vest"",
            ""attachedItems"": []
        },
        ""distance"": 530.1838989257813,
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:39:37.976Z"",
        ""_T"": ""LogArmorDestroy""
    },
    {
        ""itemPackage"": {
            ""itemPackageId"": ""Carapackage_RedBox_C"",
            ""location"": {
                ""x"": 730582.25,
                ""y"": 373777.5,
                ""z"": -238.90403747558595
            },
            ""items"": [
                {
                    ""itemId"": ""Item_Weapon_AUG_C"",
                    ""stackCount"": 1,
                    ""category"": ""Weapon"",
                    ""subCategory"": ""Main"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Ammo_556mm_C"",
                    ""stackCount"": 30,
                    ""category"": ""Ammunition"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Ammo_556mm_C"",
                    ""stackCount"": 30,
                    ""category"": ""Ammunition"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Ammo_556mm_C"",
                    ""stackCount"": 30,
                    ""category"": ""Ammunition"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C"",
                    ""stackCount"": 1,
                    ""category"": ""Attachment"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Armor_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Vest"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Head_G_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Headgear"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Back_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Backpack"",
                    ""attachedItems"": []
                }
            ]
        },
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:42:41.709Z"",
        ""_T"": ""LogCarePackageLand""
    },
    {
        ""itemPackage"": {
            ""itemPackageId"": ""Carapackage_RedBox_C"",
            ""location"": {
                ""x"": 725696.125,
                ""y"": 261458.0625,
                ""z"": 30000
            },
            ""items"": [
                {
                    ""itemId"": ""Item_Weapon_AUG_C"",
                    ""stackCount"": 1,
                    ""category"": ""Weapon"",
                    ""subCategory"": ""Main"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Ammo_556mm_C"",
                    ""stackCount"": 30,
                    ""category"": ""Ammunition"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Ammo_556mm_C"",
                    ""stackCount"": 30,
                    ""category"": ""Ammunition"",
                    ""subCategory"": ""None"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Armor_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Vest"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Head_G_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Headgear"",
                    ""attachedItems"": []
                },
                {
                    ""itemId"": ""Item_Back_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Backpack"",
                    ""attachedItems"": []
                }
            ]
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:17.037Z"",
        ""_T"": ""LogCarePackageSpawn""
    },
    {
        ""gameState"": {
            ""elapsedTime"": 560,
            ""numAliveTeams"": 22,
            ""numJoinPlayers"": 91,
            ""numStartPlayers"": 97,
            ""numAlivePlayers"": 64,
            ""safetyZonePosition"": {
                ""x"": 533191.1875,
                ""y"": 376426.6875,
                ""z"": 0
            },
            ""safetyZoneRadius"": 405833.625,
            ""poisonGasWarningPosition"": {
                ""x"": 660039.4375,
                ""y"": 346455.375,
                ""z"": 0
            },
            ""poisonGasWarningRadius"": 231887.484375,
            ""redZonePosition"": {
                ""x"": 652706.875,
                ""y"": 460413.5625,
                ""z"": 0
            },
            ""redZoneRadius"": 50000
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:26.002Z"",
        ""_T"": ""LogGameStatePeriodic""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 67.56538391113281,
            ""location"": {
                ""x"": 552430.9375,
                ""y"": 245498.75,
                ""z"": 156.6699981689453
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""item"": {
            ""itemId"": """",
            ""stackCount"": 254345235,
            ""category"": """",
            ""subCategory"": """",
            ""attachedItems"": []
        },
        ""healAmount"": 7.4346160888671879,
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:26.303Z"",
        ""_T"": ""LogHeal""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 616987,
                ""y"": 608176.25,
                ""z"": 148.72000122070313
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""novorepnoye""
            ]
        },
        ""parentItem"": {
            ""itemId"": ""Item_Weapon_M24_C"",
            ""stackCount"": 1,
            ""category"": ""Weapon"",
            ""subCategory"": ""Main"",
            ""attachedItems"": []
        },
        ""childItem"": {
            ""itemId"": ""Item_Attach_Weapon_Magazine_Extended_SniperRifle_C"",
            ""stackCount"": 1,
            ""category"": ""Attachment"",
            ""subCategory"": ""None"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:26.391Z"",
        ""_T"": ""LogItemAttach""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 549508.5625,
                ""y"": 245599.234375,
                ""z"": 137.69000244140626
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""parentItem"": {
            ""itemId"": ""Item_Weapon_SCAR-L_C"",
            ""stackCount"": 1,
            ""category"": ""Weapon"",
            ""subCategory"": ""Main"",
            ""attachedItems"": [
                ""Item_Attach_Weapon_Upper_DotSight_01_C"",
                ""Item_Attach_Weapon_Lower_Foregrip_C"",
                ""Item_Attach_Weapon_Magazine_QuickDraw_Large_C""
            ]
        },
        ""childItem"": {
            ""itemId"": ""Item_Attach_Weapon_Upper_DotSight_01_C"",
            ""stackCount"": 1,
            ""category"": ""Attachment"",
            ""subCategory"": ""None"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:28.016Z"",
        ""_T"": ""LogItemDetach""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 549508.5625,
                ""y"": 245599.234375,
                ""z"": 137.69000244140626
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""item"": {
            ""itemId"": ""Item_Weapon_SCAR-L_C"",
            ""stackCount"": 1,
            ""category"": ""Weapon"",
            ""subCategory"": ""Main"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:28.504Z"",
        ""_T"": ""LogItemDrop""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 549508.5625,
                ""y"": 245599.234375,
                ""z"": 137.69000244140626
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""item"": {
            ""itemId"": ""Item_Weapon_HK416_C"",
            ""stackCount"": 1,
            ""category"": ""Weapon"",
            ""subCategory"": ""Main"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:29.075Z"",
        ""_T"": ""LogItemEquip""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 549508.5625,
                ""y"": 245599.234375,
                ""z"": 137.69000244140626
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""item"": {
            ""itemId"": ""Item_Weapon_HK416_C"",
            ""stackCount"": 1,
            ""category"": ""Weapon"",
            ""subCategory"": ""Main"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:46:29.075Z"",
        ""_T"": ""LogItemPickup""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 92,
            ""location"": {
                ""x"": 726520.25,
                ""y"": 260342.953125,
                ""z"": -260.2599792480469
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""item"": {
            ""itemId"": ""Item_Head_G_01_Lv3_C"",
            ""stackCount"": 1,
            ""category"": ""Equipment"",
            ""subCategory"": ""Headgear"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:22.303Z"",
        ""_T"": ""LogItemPickupFromCarepackage""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 547226.4375,
                ""y"": 241881.671875,
                ""z"": 155.1199951171875
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""item"": {
            ""itemId"": ""Item_Attach_Weapon_Muzzle_Compensator_Large_C"",
            ""stackCount"": 1,
            ""category"": ""Attachment"",
            ""subCategory"": ""None"",
            ""attachedItems"": []
        },
        ""ownerTeamId"": 9,
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:44.135Z"",
        ""_T"": ""LogItemPickupFromLootBox""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 93.91320037841797,
            ""location"": {
                ""x"": 485886.34375,
                ""y"": 450286.9375,
                ""z"": 1545.159912109375
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""item"": {
            ""itemId"": ""Item_Armor_E_01_Lv1_C"",
            ""stackCount"": 1,
            ""category"": ""Equipment"",
            ""subCategory"": ""Vest"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:46.951Z"",
        ""_T"": ""LogItemUnequip""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 75.53963470458985,
            ""location"": {
                ""x"": 329760.9375,
                ""y"": 493568.21875,
                ""z"": 777.5020751953125
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": true,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""item"": {
            ""itemId"": ""Item_Boost_EnergyDrink_C"",
            ""stackCount"": 2,
            ""category"": ""Use"",
            ""subCategory"": ""Boost"",
            ""attachedItems"": []
        },
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:49:04.913Z"",
        ""_T"": ""LogItemUse""
    },
    {
        ""mapName"": ""Erangel_Main"",
        ""weatherId"": ""Clear"",
        ""characters"": [
            {
                ""name"": ""Player1"",
                ""teamId"": 1,
                ""health"": 100,
                ""location"": {
                    ""x"": 43038.5625,
                    ""y"": 851672.875,
                    ""z"": 150088
                },
                ""ranking"": 0,
                ""accountId"": ""account.id-123"",
                ""isInBlueZone"": false,
                ""isInRedZone"": false,
                ""zone"": []
            },
            {
                ""name"": ""Player2"",
                ""teamId"": 2,
                ""health"": 100,
                ""location"": {
                    ""x"": 43038.5625,
                    ""y"": 851672.875,
                    ""z"": 150088
                },
                ""ranking"": 0,
                ""accountId"": ""account.id-456"",
                ""isInBlueZone"": false,
                ""isInRedZone"": false,
                ""zone"": []
            },
            {
                ""name"": ""Player3"",
                ""teamId"": 1,
                ""health"": 100,
                ""location"": {
                    ""x"": 43038.5625,
                    ""y"": 851672.875,
                    ""z"": 150088
                },
                ""ranking"": 0,
                ""accountId"": ""account.id-789"",
                ""isInBlueZone"": false,
                ""isInRedZone"": false,
                ""zone"": []
            }
        ],
        ""cameraViewBehaviour"": ""FpsAndTps"",
        ""teamSize"": 4,
        ""isCustomGame"": false,
        ""isEventMode"": false,
        ""blueZoneCustomOptions"": ""[]"",
        ""common"": {
            ""isGame"": 0.10000000149011612
        },
        ""_D"": ""2019-06-19T23:36:54.891Z"",
        ""_T"": ""LogMatchStart""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 296759.21875,
                ""y"": 445691.6875,
                ""z"": 1079.851806640625
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""objectType"": ""Window"",
        ""objectLocation"": {
            ""x"": 0,
            ""y"": 0,
            ""z"": 0
        },
        ""common"": {
            ""isGame"": 0.10000000149011612
        },
        ""_D"": ""2019-06-19T23:38:20.241Z"",
        ""_T"": ""LogObjectDestroy""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 603433.0625,
                ""y"": 481313.09375,
                ""z"": 1081.6036376953126
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""mylta""
            ]
        },
        ""distance"": 337.9662780761719,
        ""common"": {
            ""isGame"": 0.10000000149011612
        },
        ""_D"": ""2019-06-19T23:38:20.525Z"",
        ""_T"": ""LogParachuteLanding""
    },
    {
        ""attackId"": 230,
        ""fireWeaponStackCount"": 0,
        ""attacker"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 437908.0625,
                ""y"": 623300.8125,
                ""z"": 273.0799865722656
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""sosnovkamilitarybase""
            ]
        },
        ""attackType"": ""Weapon"",
        ""weapon"": {
            ""itemId"": """",
            ""stackCount"": -2,
            ""category"": """",
            ""subCategory"": """",
            ""attachedItems"": []
        },
        ""vehicle"": null,
        ""common"": {
            ""isGame"": 0.10000000149011612
        },
        ""_D"": ""2019-06-19T23:38:31.857Z"",
        ""_T"": ""LogPlayerAttack""
    },
    {
        ""attackId"": 1040187405,
        ""killer"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 546873.3125,
                ""y"": 254181.390625,
                ""z"": 619.989990234375
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""victim"": {
            ""name"": ""Player2"",
            ""teamId"": 2,
            ""health"": 0,
            ""location"": {
                ""x"": 546972.4375,
                ""y"": 255136.890625,
                ""z"": 781.6199951171875
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-456"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""assistant"": {
            ""name"": ""Player3"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 546735.75,
                ""y"": 255261.5,
                ""z"": 815.5799560546875
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-789"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""yasnayapolyana""
            ]
        },
        ""dBNOId"": 1308622848,
        ""damageReason"": ""HeadShot"",
        ""damageTypeCategory"": ""Damage_Gun"",
        ""damageCauserName"": ""WeapHK416_C"",
        ""damageCauserAdditionalInfo"": [],
        ""distance"": 974.1304931640625,
        ""victimGameResult"": {
            ""rank"": 0,
            ""gameResult"": """",
            ""teamId"": 2,
            ""stats"": {
                ""killCount"": 0,
                ""distanceOnFoot"": 77.72235870361328,
                ""distanceOnSwim"": 0,
                ""distanceOnVehicle"": 0,
                ""distanceOnParachute"": 376.2899169921875,
                ""distanceOnFreefall"": 1733.07421875
            },
            ""accountId"": ""account.id-456""
        },
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:39:00.129Z"",
        ""_T"": ""LogPlayerKill""
    },
    {
        ""accountId"": ""account.id-123"",
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:39:22.427Z"",
        ""_T"": ""LogPlayerLogout""
    },
    {
        ""attackId"": 1644167205,
        ""attacker"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 467805.78125,
                ""y"": 644423.25,
                ""z"": 161.75
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""sosnovkamilitarybase""
            ]
        },
        ""victim"": {
            ""name"": ""Player2"",
            ""teamId"": 2,
            ""health"": 0,
            ""location"": {
                ""x"": 467785,
                ""y"": 645243.75,
                ""z"": 161.75
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-456"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""sosnovkamilitarybase""
            ]
        },
        ""damageReason"": ""TorsoShot"",
        ""damageTypeCategory"": ""Damage_Gun"",
        ""damageCauserName"": ""WeapBerylM762_C"",
        ""damageCauserAdditionalInfo"": [
            ""Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C""
        ],
        ""distance"": 820.7631225585938,
        ""isAttackerInVehicle"": false,
        ""dBNOId"": 1526726656,
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:39:34.166Z"",
        ""_T"": ""LogPlayerMakeGroggy""
    },
    {
        ""reviver"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 375420.15625,
                ""y"": 398376.5,
                ""z"": 3837.10986328125
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""pochinki""
            ]
        },
        ""victim"": {
            ""name"": ""Player3"",
            ""teamId"": 1,
            ""health"": 10,
            ""location"": {
                ""x"": 375500.1875,
                ""y"": 398379.21875,
                ""z"": 3837.10986328125
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-789"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""pochinki""
            ]
        },
        ""dBNOId"": 117440512,
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:41:21.098Z"",
        ""_T"": ""LogPlayerRevive""
    },
    {
        ""attackId"": -1,
        ""attacker"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 0,
            ""location"": {
                ""x"": 594938.1875,
                ""y"": 244331.59375,
                ""z"": 148.87998962402345
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""victim"": {
            ""name"": ""Player2"",
            ""teamId"": 2,
            ""health"": 0,
            ""location"": {
                ""x"": 594938.1875,
                ""y"": 244331.59375,
                ""z"": 148.87998962402345
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-456"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""damageTypeCategory"": ""Damage_Groggy"",
        ""damageReason"": ""None"",
        ""damage"": 0,
        ""damageCauserName"": ""PlayerMale_A_C"",
        ""common"": {
            ""isGame"": 1
        },
        ""_D"": ""2019-06-19T23:41:21.518Z"",
        ""_T"": ""LogPlayerTakeDamage""
    },
    {
        ""drivers"": [
            {
                ""name"": ""Player1"",
                ""teamId"": 1,
                ""health"": 100,
                ""location"": {
                    ""x"": 639578.5625,
                    ""y"": 468742.15625,
                    ""z"": 551.0599975585938
                },
                ""ranking"": 0,
                ""accountId"": ""account.id-123"",
                ""isInBlueZone"": false,
                ""isInRedZone"": true,
                ""zone"": []
            }
        ],
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:47:43.321Z"",
        ""_T"": ""LogRedZoneEnded""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 383196.28125,
                ""y"": 265369.0625,
                ""z"": -260.00634765625
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": [
                ""rozhok""
            ]
        },
        ""swimDistance"": 8.800971031188965,
        ""maxSwimDepthOfWater"": 532.1516723632813,
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:07.008Z"",
        ""_T"": ""LogSwimEnd""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 92,
            ""location"": {
                ""x"": 727007.5,
                ""y"": 261163.96875,
                ""z"": -380.97064208984377
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:15.786Z"",
        ""_T"": ""LogSwimStart""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 100,
            ""location"": {
                ""x"": 641817.75,
                ""y"": 470017.34375,
                ""z"": 901.010009765625
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""common"": {
            ""isGame"": 1.5
        },
        ""_D"": ""2019-06-19T23:48:16.423Z"",
        ""_T"": ""LogVaultStart""
    },
    {
        ""attackId"": -1,
        ""attacker"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 0,
            ""location"": {
                ""x"": 0,
                ""y"": 0,
                ""z"": 0
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""vehicle"": {
            ""vehicleType"": ""WheeledVehicle"",
            ""vehicleId"": ""Uaz_C_01_C"",
            ""healthPercent"": 0,
            ""feulPercent"": 37.54453659057617
        },
        ""damageTypeCategory"": ""Damage_VehicleCrashHit"",
        ""damageCauserName"": ""Uaz_C_01_C"",
        ""distance"": -1,
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:50:42.420Z"",
        ""_T"": ""LogVehicleDestroy""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 14.039304733276368,
            ""location"": {
                ""x"": 486830.15625,
                ""y"": 463277.625,
                ""z"": 595.263427734375
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""vehicle"": {
            ""vehicleType"": ""WheeledVehicle"",
            ""vehicleId"": ""Uaz_C_01_C"",
            ""healthPercent"": 48.400001525878909,
            ""feulPercent"": 47.668853759765628
        },
        ""rideDistance"": 1708.075927734375,
        ""seatIndex"": 0,
        ""maxSpeed"": 97.77061462402344,
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:50:52.592Z"",
        ""_T"": ""LogVehicleLeave""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 94,
            ""location"": {
                ""x"": 504985.1875,
                ""y"": 326676.53125,
                ""z"": 398.5401916503906
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""vehicle"": {
            ""vehicleType"": ""WheeledVehicle"",
            ""vehicleId"": ""Uaz_C_01_C"",
            ""healthPercent"": 100,
            ""feulPercent"": 43.97563171386719
        },
        ""seatIndex"": 0,
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:50:56.089Z"",
        ""_T"": ""LogVehicleRide""
    },
    {
        ""character"": {
            ""name"": ""Player1"",
            ""teamId"": 1,
            ""health"": 93.91320037841797,
            ""location"": {
                ""x"": 487456.03125,
                ""y"": 445695.625,
                ""z"": 960.75
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""weaponId"": ""Item_Weapon_AK47_C"",
        ""fireCount"": 20,
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:50:59.741Z"",
        ""_T"": ""LogWeaponFireCount""
    },
    {
        ""attackId"": 1124073488,
        ""attacker"": {
            ""name"": ""WK-Triazol"",
            ""teamId"": 1,
            ""health"": 89.74388885498047,
            ""location"": {
                ""x"": 606647.5625,
                ""y"": 278059,
                ""z"": 472
            },
            ""ranking"": 0,
            ""accountId"": ""account.id-123"",
            ""isInBlueZone"": false,
            ""isInRedZone"": false,
            ""zone"": []
        },
        ""vehicle"": {
            ""vehicleType"": ""WheeledVehicle"",
            ""vehicleId"": ""BP_Motorbike_04_SideCar_C"",
            ""healthPercent"": 53.36394500732422,
            ""feulPercent"": 71.52766418457031
        },
        ""damageTypeCategory"": ""Damage_Gun"",
        ""damageCauserName"": ""WeapFNFal_C"",
        ""common"": {
            ""isGame"": 2
        },
        ""_D"": ""2019-06-19T23:51:56.692Z"",
        ""_T"": ""LogWheelDestroy""
    },
	{
		""characters"": [
			{
				""name"": ""Player1"",
				""teamId"": 1,
				""health"": 0,
				""location"": {
					""x"": 0,
					""y"": 0,
					""z"": 0
				},
				""ranking"": 21,
				""accountId"": ""account.id-123"",
				""isInBlueZone"": false,
				""isInRedZone"": false,
				""zone"": []
			},
			{
				""name"": ""Player2"",
				""teamId"": 2,
				""health"": 0,
				""location"": {
					""x"": 0,
					""y"": 0,
					""z"": 0
				},
				""ranking"": 21,
				""accountId"": ""account.id-456"",
				""isInBlueZone"": false,
				""isInRedZone"": false,
				""zone"": []
			},
			{
				""name"": ""Player3"",
				""teamId"": 1,
				""health"": 0,
				""location"": {
					""x"": 0,
					""y"": 0,
					""z"": 0
				},
				""ranking"": 21,
				""accountId"": ""account.id-789"",
				""isInBlueZone"": false,
				""isInRedZone"": false,
				""zone"": []
			}
		],
		""rewardDetail"": [],
		""gameResultOnFinished"": {
			""results"": []
		},
		""common"": {
			""isGame"": 8
		},
		""_D"": ""2019-06-20T00:08:32.213Z"",
		""_T"": ""LogMatchEnd""
	}
]";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesArmorDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ArmorDestroyEvents.Count);

            Assert.AreEqual("6/19/1019 11:39:37 PM", telemetry.ArmorDestroyEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogArmorDestroy", telemetry.ArmorDestroyEvents[0].Type);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Common.IsGame);

            Assert.AreEqual("Damage_Gun", telemetry.ArmorDestroyEvents[0].DamageTypeCategory);
            Assert.AreEqual("TorsoShot", telemetry.ArmorDestroyEvents[0].DamageReason);
            Assert.AreEqual("WeapBerylM762_C", telemetry.ArmorDestroyEvents[0].DamageCauserName);
            Assert.AreEqual(530.1838989257813, telemetry.ArmorDestroyEvents[0].Distance);

            Assert.AreEqual("Player1", telemetry.ArmorDestroyEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Attacker.TeamId);
            Assert.AreEqual(100, telemetry.ArmorDestroyEvents[0].Attacker.Health);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ArmorDestroyEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("Player1", telemetry.ArmorDestroyEvents[0].Attacker.Zone);
            Assert.AreEqual(468019.34375, telemetry.ArmorDestroyEvents[0].Attacker.Location.X);
            Assert.AreEqual(644856.4375, telemetry.ArmorDestroyEvents[0].Attacker.Location.Y);
            Assert.AreEqual(161.77999877929688, telemetry.ArmorDestroyEvents[0].Attacker.Location.Z);

            Assert.AreEqual("Player2", telemetry.ArmorDestroyEvents[0].Victim.Name);
            Assert.AreEqual(2, telemetry.ArmorDestroyEvents[0].Victim.TeamId);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Victim.Health);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Victim.Ranking);
            Assert.AreEqual("account.id-456", telemetry.ArmorDestroyEvents[0].Victim.AccountId);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Victim.IsInBlueZone);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Victim.IsInRedZone);
            // Assert.AreEqual("Player1", telemetry.ArmorDestroyEvents[0].Attacker.Zone);
            Assert.AreEqual(467627.0625, telemetry.ArmorDestroyEvents[0].Victim.Location.X);
            Assert.AreEqual(645212, telemetry.ArmorDestroyEvents[0].Victim.Location.Y);
            Assert.AreEqual(133.75, telemetry.ArmorDestroyEvents[0].Victim.Location.Z);

            Assert.AreEqual("Item_Armor_D_01_Lv2_C", telemetry.ArmorDestroyEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Item.StackCount);
            Assert.AreEqual("Equipment", telemetry.ArmorDestroyEvents[0].Item.Category);
            Assert.AreEqual("Vest", telemetry.ArmorDestroyEvents[0].Item.SubCategory);
            Assert.AreEqual("", telemetry.ArmorDestroyEvents[0].Item.AttachedItems);

        }
        
        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCarePackageLandEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents.Count);

            Assert.AreEqual("6/19/1019 11:42:41 PM", telemetry.CarePackageLandEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogCarePackageLand", telemetry.CarePackageLandEvents[0].Type);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].Common.IsGame);

            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.ItemPackageId);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.Location.X);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.Location.Y);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.Location.Z);

            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items.Count);

            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].ItemId);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].StackCount);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].Category);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].SubCategory);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].AttachedItems);

            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].ItemId);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].StackCount);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].Category);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].SubCategory);
            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCarePackageSpawnEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.CarePackageSpawnEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesGameStatePeriodicEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.GameStatePeriodicEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesHealEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.HealEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemAttachEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemAttachEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemDetachEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemDetachEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemDropEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemDropEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemEquipEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemEquipEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupFromCarePackageEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupFromCarePackageEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupFromLootBoxEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupFromLootBoxEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemUnequipEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemUnequipEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemUseEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemUseEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchDefinitionEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchDefinitionEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchEndEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchEndEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchStartsEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchStartEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesObjectDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ObjectDestroyEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesParachuteLandingEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ParachuteLandingEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerAttackEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerAttackEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerCreateEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerCreateEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerKillEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerKillEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerLoginEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerLoginEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerLogoutEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerLogoutEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerPositionEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerPositionEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerTakeDamageEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerTakeDamageEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesRedZoneEndedEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.RedZoneEndedEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSwimEndEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.SwimEndEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSwimStartEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.SwimStartEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVaultStartEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VaultStartEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleDestroyEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleLeaveEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleLeaveEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleRideEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleRideEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesWeaponFireCountCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.WeaponFireCountEvents.Count);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesWheelDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.WheelDestroyEvents.Count);
        }
    }
}
