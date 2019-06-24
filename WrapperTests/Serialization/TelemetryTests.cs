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
        // Theres a -1 attackid somewhere... get rid of it?
        // Aka verify that data in all the fields makes some sort of sense

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
        ""elapsedTime"": 771,
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
                    ""itemId"": ""Item_Armor_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Vest"",
                    ""attachedItems"": []
                },
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
                    ""itemId"": ""Item_Armor_C_01_Lv3_C"",
                    ""stackCount"": 1,
                    ""category"": ""Equipment"",
                    ""subCategory"": ""Vest"",
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
			""name"": ""Player3"",
			""teamId"": 1,
			""health"": 100,
			""location"": {
				""x"": 490206.71875,
				""y"": 455457.5625,
				""z"": 1881.3699951171876
			},
			""ranking"": 0,
			""accountId"": ""account.id-789"",
			""isInBlueZone"": true,
			""isInRedZone"": false,
			""zone"": []
		},
		""item"": {
			""itemId"": ""Item_Heal_MedKit_C"",
			""stackCount"": 1,
			""category"": ""Use"",
			""subCategory"": ""Heal"",
			""attachedItems"": []
		},
		""healAmount"": 97.19999694824219,
		""common"": {
			""isGame"": 2.5
		},
		""_D"": ""2019-06-19T23:54:05.319Z"",
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
		""attackId"": 1577058344,
		""fireWeaponStackCount"": 13,
		""attacker"": {
			""name"": ""Player1"",
			""teamId"": 1,
			""health"": 75,
			""location"": {
				""x"": 486392.375,
				""y"": 449052.9375,
				""z"": 1158.1199951171876
			},
			""ranking"": 0,
			""accountId"": ""account.id-123"",
			""isInBlueZone"": false,
			""isInRedZone"": false,
			""zone"": []
		},
		""attackType"": ""Weapon"",
		""weapon"": {
			""itemId"": ""Item_Weapon_Mini14_C"",
			""stackCount"": 1,
			""category"": ""Weapon"",
			""subCategory"": ""Main"",
			""attachedItems"": [
				""Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C"",
				""Item_Attach_Weapon_Upper_CQBSS_C""
			]
		},
		""vehicle"": null,
		""common"": {
			""isGame"": 2
		},
		""_D"": ""2019-06-19T23:49:59.993Z"",
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
        ""accountId"": ""account.id-456"",
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
		""attackId"": 1577058343,
		""attacker"": {
			""name"": ""Player1"",
			""teamId"": 1,
			""health"": 75,
			""location"": {
				""x"": 486392.375,
				""y"": 449052.9375,
				""z"": 1158.1199951171876
			},
			""ranking"": 0,
			""accountId"": ""account.id-123"",
			""isInBlueZone"": false,
			""isInRedZone"": false,
			""zone"": []
		},
		""victim"": {
			""name"": ""Player2"",
			""teamId"": 19,
			""health"": 99.75,
			""location"": {
				""x"": 478005.21875,
				""y"": 447384.375,
				""z"": 675.3499755859375
			},
			""ranking"": 0,
			""accountId"": ""account.id-456"",
			""isInBlueZone"": false,
			""isInRedZone"": false,
			""zone"": []
		},
		""damageTypeCategory"": ""Damage_Gun"",
		""damageReason"": ""PelvisShot"",
		""damage"": 28.979999542236329,
		""damageCauserName"": ""WeapMini14_C"",
		""common"": {
			""isGame"": 2
		},
		""_D"": ""2019-06-19T23:49:59.792Z"",
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
            ""name"": ""Player1"",
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
				""ranking"": 1,
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
				""ranking"": 2,
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
				""ranking"": 1,
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

            Assert.AreEqual("06/19/2019 23:39:37", telemetry.ArmorDestroyEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogArmorDestroy", telemetry.ArmorDestroyEvents[0].Type);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Common.IsGame);

            Assert.AreEqual("Damage_Gun", telemetry.ArmorDestroyEvents[0].DamageTypeCategory);
            Assert.AreEqual("TorsoShot", telemetry.ArmorDestroyEvents[0].DamageReason);
            Assert.AreEqual("WeapBerylM762_C", telemetry.ArmorDestroyEvents[0].DamageCauserName);
            Assert.AreEqual(530.1838989257813, telemetry.ArmorDestroyEvents[0].Distance);

            Assert.AreEqual("Player1", telemetry.ArmorDestroyEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Attacker.TeamId);
            Assert.AreEqual(100, telemetry.ArmorDestroyEvents[0].Attacker.Health);
            Assert.AreEqual(468019.34375, telemetry.ArmorDestroyEvents[0].Attacker.Location.X);
            Assert.AreEqual(644856.4375, telemetry.ArmorDestroyEvents[0].Attacker.Location.Y);
            Assert.AreEqual(161.77999877929688, telemetry.ArmorDestroyEvents[0].Attacker.Location.Z);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ArmorDestroyEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("", telemetry.ArmorDestroyEvents[0].Attacker.Zone);

            Assert.AreEqual("Player2", telemetry.ArmorDestroyEvents[0].Victim.Name);
            Assert.AreEqual(2, telemetry.ArmorDestroyEvents[0].Victim.TeamId);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Victim.Health);
            Assert.AreEqual(467627.0625, telemetry.ArmorDestroyEvents[0].Victim.Location.X);
            Assert.AreEqual(645212, telemetry.ArmorDestroyEvents[0].Victim.Location.Y);
            Assert.AreEqual(133.75, telemetry.ArmorDestroyEvents[0].Victim.Location.Z);
            Assert.AreEqual(0, telemetry.ArmorDestroyEvents[0].Victim.Ranking);
            Assert.AreEqual("account.id-456", telemetry.ArmorDestroyEvents[0].Victim.AccountId);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Victim.IsInBlueZone);
            Assert.IsFalse(telemetry.ArmorDestroyEvents[0].Victim.IsInRedZone);
            // Assert.AreEqual("", telemetry.ArmorDestroyEvents[0].Attacker.Zone);

            Assert.AreEqual("Item_Armor_D_01_Lv2_C", telemetry.ArmorDestroyEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ArmorDestroyEvents[0].Item.StackCount);
            Assert.AreEqual("Equipment", telemetry.ArmorDestroyEvents[0].Item.Category);
            Assert.AreEqual("Vest", telemetry.ArmorDestroyEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ArmorDestroyEvents[0].Item.AttachedItems);

        }
        
        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCarePackageLandEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents.Count);

            Assert.AreEqual("06/19/2019 23:42:41", telemetry.CarePackageLandEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogCarePackageLand", telemetry.CarePackageLandEvents[0].Type);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].Common.IsGame);

            Assert.AreEqual("Carapackage_RedBox_C", telemetry.CarePackageLandEvents[0].ItemPackage.ItemPackageId);
            Assert.AreEqual(730582.25, telemetry.CarePackageLandEvents[0].ItemPackage.Location.X);
            Assert.AreEqual(373777.5, telemetry.CarePackageLandEvents[0].ItemPackage.Location.Y);
            Assert.AreEqual(-238.90403747558595, telemetry.CarePackageLandEvents[0].ItemPackage.Location.Z);

            Assert.AreEqual(2, telemetry.CarePackageLandEvents[0].ItemPackage.Items.Count);

            Assert.AreEqual("Item_Weapon_AUG_C", telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].ItemId);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].StackCount);
            Assert.AreEqual("Weapon", telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].Category);
            Assert.AreEqual("Main", telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].SubCategory);
            // Assert.AreEqual("", telemetry.CarePackageLandEvents[0].ItemPackage.Items[0].AttachedItems);

            Assert.AreEqual("Item_Armor_C_01_Lv3_C", telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].ItemId);
            Assert.AreEqual(1, telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].StackCount);
            Assert.AreEqual("Equipment", telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].Category);
            Assert.AreEqual("Vest", telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].SubCategory);
            // Assert.AreEqual("", telemetry.CarePackageLandEvents[0].ItemPackage.Items[1].AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCarePackageSpawnEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.CarePackageSpawnEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:17", telemetry.CarePackageSpawnEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogCarePackageSpawn", telemetry.CarePackageSpawnEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.CarePackageSpawnEvents[0].Common.IsGame);

            Assert.AreEqual("Carapackage_RedBox_C", telemetry.CarePackageSpawnEvents[0].ItemPackage.ItemPackageId);
            Assert.AreEqual(730582.25, telemetry.CarePackageSpawnEvents[0].ItemPackage.Location.X);
            Assert.AreEqual(373777.5, telemetry.CarePackageSpawnEvents[0].ItemPackage.Location.Y);
            Assert.AreEqual(30000, telemetry.CarePackageSpawnEvents[0].ItemPackage.Location.Z);

            Assert.AreEqual(2, telemetry.CarePackageSpawnEvents[0].ItemPackage.Items.Count);

            Assert.AreEqual("Item_Weapon_AUG_C", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[0].ItemId);
            Assert.AreEqual(1, telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[0].StackCount);
            Assert.AreEqual("Weapon", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[0].Category);
            Assert.AreEqual("Main", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[0].SubCategory);
            // Assert.AreEqual("", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[0].AttachedItems);

            Assert.AreEqual("Item_Armor_C_01_Lv3_C", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[1].ItemId);
            Assert.AreEqual(1, telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[1].StackCount);
            Assert.AreEqual("Equipment", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[1].Category);
            Assert.AreEqual("Vest", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[1].SubCategory);
            // Assert.AreEqual("", telemetry.CarePackageSpawnEvents[0].ItemPackage.Items[1].AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesGameStatePeriodicEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.GameStatePeriodicEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:26", telemetry.GameStatePeriodicEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogGameStatePeriodic", telemetry.GameStatePeriodicEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.GameStatePeriodicEvents[0].Common.IsGame);

            Assert.AreEqual(560, telemetry.GameStatePeriodicEvents[0].GameState.ElapsedTime);
            Assert.AreEqual(22, telemetry.GameStatePeriodicEvents[0].GameState.NumAliveTeams);
            Assert.AreEqual(91, telemetry.GameStatePeriodicEvents[0].GameState.NumJoinPlayers);
            Assert.AreEqual(97, telemetry.GameStatePeriodicEvents[0].GameState.NumStartPlayers);
            Assert.AreEqual(64, telemetry.GameStatePeriodicEvents[0].GameState.NumAlivePlayers);
            Assert.AreEqual(405833.625, telemetry.GameStatePeriodicEvents[0].GameState.SafetyZoneRadius);
            Assert.AreEqual(533191.1875, telemetry.GameStatePeriodicEvents[0].GameState.SafetyZonePosition.X);
            Assert.AreEqual(376426.6875, telemetry.GameStatePeriodicEvents[0].GameState.SafetyZonePosition.Y);
            Assert.AreEqual(0, telemetry.GameStatePeriodicEvents[0].GameState.SafetyZonePosition.Z);
            Assert.AreEqual(231887.484375, telemetry.GameStatePeriodicEvents[0].GameState.PoisonGasWarningRadius);
            Assert.AreEqual(660039.4375, telemetry.GameStatePeriodicEvents[0].GameState.PoisonGasWarningPosition.X);
            Assert.AreEqual(346455.375, telemetry.GameStatePeriodicEvents[0].GameState.PoisonGasWarningPosition.Y);
            Assert.AreEqual(0, telemetry.GameStatePeriodicEvents[0].GameState.PoisonGasWarningPosition.Z);
            Assert.AreEqual(50000, telemetry.GameStatePeriodicEvents[0].GameState.RedZoneRadius);
            Assert.AreEqual(652706.875, telemetry.GameStatePeriodicEvents[0].GameState.RedZonePosition.X);
            Assert.AreEqual(460413.5625, telemetry.GameStatePeriodicEvents[0].GameState.RedZonePosition.Y);
            Assert.AreEqual(0, telemetry.GameStatePeriodicEvents[0].GameState.RedZonePosition.Z);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesHealEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.HealEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:30", telemetry.HealEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogHeal", telemetry.HealEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.HealEvents[0].Common.IsGame);

            Assert.AreEqual(1, telemetry.HealEvents[0].HealAmount);

            Assert.AreEqual("", telemetry.HealEvents[0].Item.ItemId);
            Assert.AreEqual(254345235, telemetry.HealEvents[0].Item.StackCount);
            Assert.AreEqual("", telemetry.HealEvents[0].Item.Category);
            Assert.AreEqual("", telemetry.HealEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.HealEvents[0].Item.AttachedItems);

            Assert.AreEqual("Player1", telemetry.HealEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.HealEvents[0].Character.TeamId);
            Assert.AreEqual(67.56538391113281, telemetry.HealEvents[0].Character.Health);
            Assert.AreEqual(552430.9375, telemetry.HealEvents[0].Character.Location.X);
            Assert.AreEqual(245498.75, telemetry.HealEvents[0].Character.Location.Y);
            Assert.AreEqual(156.6699981689453, telemetry.HealEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.HealEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.HealEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.HealEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.HealEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.HealEvents[0].Character.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemAttachEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemAttachEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:28", telemetry.ItemAttachEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemDetach", telemetry.ItemAttachEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemAttachEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemAttachEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemAttachEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemAttachEvents[0].Character.Health);
            Assert.AreEqual(616987, telemetry.ItemAttachEvents[0].Character.Location.X);
            Assert.AreEqual(608176.25, telemetry.ItemAttachEvents[0].Character.Location.Y);
            Assert.AreEqual(148.72000122070313, telemetry.ItemAttachEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemAttachEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemAttachEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemAttachEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemAttachEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("novorepnoye", telemetry.ItemAttachEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_M24_C", telemetry.ItemAttachEvents[0].ParentItem.ItemId);
            Assert.AreEqual(1, telemetry.ItemAttachEvents[0].ParentItem.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemAttachEvents[0].ParentItem.Category);
            Assert.AreEqual("Main", telemetry.ItemAttachEvents[0].ParentItem.SubCategory);
            // Assert.AreEqual("", telemetry.ItemAttachEvents[0].ParentItem.AttachedItems);

            Assert.AreEqual("Item_Attach_Weapon_Magazine_Extended_SniperRifle_C", telemetry.ItemAttachEvents[0].ChildItem.ItemId);
            Assert.AreEqual(1, telemetry.ItemAttachEvents[0].ChildItem.StackCount);
            Assert.AreEqual("Attachment", telemetry.ItemAttachEvents[0].ChildItem.Category);
            Assert.AreEqual("None", telemetry.ItemAttachEvents[0].ChildItem.SubCategory);
            // Assert.AreEqual("", telemetry.ItemAttachEvents[0].ChildItem.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemDetachEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemDetachEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:26", telemetry.ItemDetachEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemAttach", telemetry.ItemDetachEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemDetachEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemDetachEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemDetachEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemDetachEvents[0].Character.Health);
            Assert.AreEqual(549508.5625, telemetry.ItemDetachEvents[0].Character.Location.X);
            Assert.AreEqual(245599.234375, telemetry.ItemDetachEvents[0].Character.Location.Y);
            Assert.AreEqual(137.69000244140626, telemetry.ItemDetachEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemDetachEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemDetachEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemDetachEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemDetachEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemDetachEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_SCAR-L_C", telemetry.ItemDetachEvents[0].ParentItem.ItemId);
            Assert.AreEqual(1, telemetry.ItemDetachEvents[0].ParentItem.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemDetachEvents[0].ParentItem.Category);
            Assert.AreEqual("Main", telemetry.ItemDetachEvents[0].ParentItem.SubCategory);
            // Assert.AreEqual("Item_Attach_Weapon_Upper_DotSight_01_C", telemetry.ItemDetachEvents[0].ParentItem.AttachedItems);
            // Item_Attach_Weapon_Upper_DotSight_01_C, Item_Attach_Weapon_Lower_Foregrip_C, Item_Attach_Weapon_Magazine_QuickDraw_Large_C

            Assert.AreEqual("Item_Attach_Weapon_Upper_DotSight_01_C", telemetry.ItemDetachEvents[0].ChildItem.ItemId);
            Assert.AreEqual(1, telemetry.ItemDetachEvents[0].ChildItem.StackCount);
            Assert.AreEqual("Attachment", telemetry.ItemDetachEvents[0].ChildItem.Category);
            Assert.AreEqual("None", telemetry.ItemDetachEvents[0].ChildItem.SubCategory);
            // Assert.AreEqual("", telemetry.ItemDetachEvents[0].ChildItem.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemDropEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemDropEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:28", telemetry.ItemDropEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemDrop", telemetry.ItemDropEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemDropEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemDropEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemDropEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemDropEvents[0].Character.Health);
            Assert.AreEqual(549508.5625, telemetry.ItemDropEvents[0].Character.Location.X);
            Assert.AreEqual(245599.234375, telemetry.ItemDropEvents[0].Character.Location.Y);
            Assert.AreEqual(137.69000244140626, telemetry.ItemDropEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemDropEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemDropEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemDropEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemDropEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemDropEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_SCAR-L_C", telemetry.ItemDropEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemDropEvents[0].Item.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemDropEvents[0].Item.Category);
            Assert.AreEqual("Main", telemetry.ItemDropEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemDropEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemEquipEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemEquipEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:29", telemetry.ItemEquipEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemEquip", telemetry.ItemEquipEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemEquipEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemEquipEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemEquipEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemEquipEvents[0].Character.Health);
            Assert.AreEqual(549508.5625, telemetry.ItemEquipEvents[0].Character.Location.X);
            Assert.AreEqual(245599.234375, telemetry.ItemEquipEvents[0].Character.Location.Y);
            Assert.AreEqual(137.69000244140626, telemetry.ItemEquipEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemEquipEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemEquipEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemEquipEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemEquipEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemEquipEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_HK416_C", telemetry.ItemEquipEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemEquipEvents[0].Item.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemEquipEvents[0].Item.Category);
            Assert.AreEqual("Main", telemetry.ItemEquipEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemEquipEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:29", telemetry.ItemPickupEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemPickup", telemetry.ItemPickupEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemPickupEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemPickupEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemPickupEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemPickupEvents[0].Character.Health);
            Assert.AreEqual(549508.5625, telemetry.ItemPickupEvents[0].Character.Location.X);
            Assert.AreEqual(245599.234375, telemetry.ItemPickupEvents[0].Character.Location.Y);
            Assert.AreEqual(137.69000244140626, telemetry.ItemPickupEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemPickupEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemPickupEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemPickupEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemPickupEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemPickupEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_SCAR-L_C", telemetry.ItemPickupEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemPickupEvents[0].Item.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemPickupEvents[0].Item.Category);
            Assert.AreEqual("Main", telemetry.ItemPickupEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemPickupEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupFromCarePackageEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupFromCarePackageEvents.Count);

            Assert.AreEqual("06/19/2019 23:46:28", telemetry.ItemPickupFromCarePackageEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemDrop", telemetry.ItemPickupFromCarePackageEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemPickupFromCarePackageEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemPickupFromCarePackageEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemPickupFromCarePackageEvents[0].Character.TeamId);
            Assert.AreEqual(92, telemetry.ItemPickupFromCarePackageEvents[0].Character.Health);
            Assert.AreEqual(726520.25, telemetry.ItemPickupFromCarePackageEvents[0].Character.Location.X);
            Assert.AreEqual(260342.953125, telemetry.ItemPickupFromCarePackageEvents[0].Character.Location.Y);
            Assert.AreEqual(-260.2599792480469, telemetry.ItemPickupFromCarePackageEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemPickupFromCarePackageEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemPickupFromCarePackageEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemPickupFromCarePackageEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemPickupFromCarePackageEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.ItemPickupFromCarePackageEvents[0].Character.Zone);

            Assert.AreEqual("Item_Head_G_01_Lv3_C", telemetry.ItemPickupFromCarePackageEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemPickupFromCarePackageEvents[0].Item.StackCount);
            Assert.AreEqual("Equipment", telemetry.ItemPickupFromCarePackageEvents[0].Item.Category);
            Assert.AreEqual("Headgear", telemetry.ItemPickupFromCarePackageEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemPickupFromCarePackageEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemPickupFromLootBoxEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemPickupFromLootBoxEvents.Count);

            Assert.AreEqual("06/19/2019 23:48:44", telemetry.ItemPickupFromLootBoxEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemPickupFromLootBox", telemetry.ItemPickupFromLootBoxEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemPickupFromLootBoxEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemPickupFromLootBoxEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemPickupFromLootBoxEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ItemPickupFromLootBoxEvents[0].Character.Health);
            Assert.AreEqual(547226.4375, telemetry.ItemPickupFromLootBoxEvents[0].Character.Location.X);
            Assert.AreEqual(241881.671875, telemetry.ItemPickupFromLootBoxEvents[0].Character.Location.Y);
            Assert.AreEqual(155.1199951171875, telemetry.ItemPickupFromLootBoxEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemPickupFromLootBoxEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemPickupFromLootBoxEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemPickupFromLootBoxEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemPickupFromLootBoxEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemPickupFromLootBoxEvents[0].Character.Zone);

            Assert.AreEqual("Item_Attach_Weapon_Muzzle_Compensator_Large_C-L_C", telemetry.ItemPickupFromLootBoxEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemPickupFromLootBoxEvents[0].Item.StackCount);
            Assert.AreEqual("Attachment", telemetry.ItemPickupFromLootBoxEvents[0].Item.Category);
            Assert.AreEqual("None", telemetry.ItemPickupFromLootBoxEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemPickupFromLootBoxEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemUnequipEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemUnequipEvents.Count);

            Assert.AreEqual("06/19/2019 23:48:46", telemetry.ItemUnequipEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemUnequip", telemetry.ItemUnequipEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.ItemUnequipEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemUnequipEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemUnequipEvents[0].Character.TeamId);
            Assert.AreEqual(93.91320037841797, telemetry.ItemUnequipEvents[0].Character.Health);
            Assert.AreEqual(485886.34375, telemetry.ItemUnequipEvents[0].Character.Location.X);
            Assert.AreEqual(450286.9375, telemetry.ItemUnequipEvents[0].Character.Location.Y);
            Assert.AreEqual(1545.159912109375, telemetry.ItemUnequipEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemUnequipEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemUnequipEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ItemUnequipEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemUnequipEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.ItemUnequipEvents[0].Character.Zone);

            Assert.AreEqual("Item_Armor_E_01_Lv1_C-L_C", telemetry.ItemUnequipEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemUnequipEvents[0].Item.StackCount);
            Assert.AreEqual("Equipment", telemetry.ItemUnequipEvents[0].Item.Category);
            Assert.AreEqual("Vest", telemetry.ItemUnequipEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemUnequipEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesItemUseEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ItemUseEvents.Count);

            Assert.AreEqual("06/19/2019 23:49:04", telemetry.ItemUseEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogItemUse", telemetry.ItemUseEvents[0].Type);
            Assert.AreEqual(2, telemetry.ItemUseEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ItemUseEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ItemUseEvents[0].Character.TeamId);
            Assert.AreEqual(75.53963470458985, telemetry.ItemUseEvents[0].Character.Health);
            Assert.AreEqual(329760.9375, telemetry.ItemUseEvents[0].Character.Location.X);
            Assert.AreEqual(493568.21875, telemetry.ItemUseEvents[0].Character.Location.Y);
            Assert.AreEqual(777.5020751953125, telemetry.ItemUseEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ItemUseEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ItemUseEvents[0].Character.AccountId);
            Assert.IsTrue(telemetry.ItemUseEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ItemUseEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.ItemUseEvents[0].Character.Zone);

            Assert.AreEqual("Item_Boost_EnergyDrink_C", telemetry.ItemUseEvents[0].Item.ItemId);
            Assert.AreEqual(2, telemetry.ItemUseEvents[0].Item.StackCount);
            Assert.AreEqual("Use", telemetry.ItemUseEvents[0].Item.Category);
            Assert.AreEqual("Boost", telemetry.ItemUseEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemUseEvents[0].Item.AttachedItems);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchDefinitionEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchDefinitionEvents.Count);

            Assert.AreEqual("06/19/2019 23:36:54", telemetry.MatchDefinitionEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogMatchDefinition", telemetry.MatchDefinitionEvents[0].Type);
            // Technically has no Common.IsGame, so defaults to 0
            Assert.AreEqual(0, telemetry.MatchDefinitionEvents[0].Common.IsGame);

            Assert.AreEqual("match.bro.official.pc-2018-03.steam.squad.sa.2019.06.19.23.546b7a2d-92ef-49c5-926c-7a1101497006", telemetry.MatchDefinitionEvents[0].MatchId);
            Assert.AreEqual("low", telemetry.MatchDefinitionEvents[0].PingQuality);
            Assert.AreEqual("closed", telemetry.MatchDefinitionEvents[0].SeasonState);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchEndEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchEndEvents.Count);

            Assert.AreEqual("06/20/2019 00:08:32", telemetry.MatchEndEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogMatchEnd", telemetry.MatchEndEvents[0].Type);
            Assert.AreEqual(8, telemetry.MatchEndEvents[0].Common.IsGame);

            Assert.AreEqual(3, telemetry.MatchEndEvents[0].Characters.Count);

            Assert.AreEqual("Player1", telemetry.MatchEndEvents[0].Characters[0].Name);
            Assert.AreEqual(1, telemetry.MatchEndEvents[0].Characters[0].TeamId);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[0].Health);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[0].Location.X);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[0].Location.Y);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[0].Location.Z);
            Assert.AreEqual(1, telemetry.MatchEndEvents[0].Characters[0].Ranking);
            Assert.AreEqual("account.id-123", telemetry.MatchEndEvents[0].Characters[0].AccountId);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[0].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[0].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchEndEvents[0].Characters[0].Zone);

            Assert.AreEqual("Player2", telemetry.MatchEndEvents[0].Characters[1].Name);
            Assert.AreEqual(2, telemetry.MatchEndEvents[0].Characters[1].TeamId);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[1].Health);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[1].Location.X);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[1].Location.Y);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[1].Location.Z);
            Assert.AreEqual(2, telemetry.MatchEndEvents[0].Characters[1].Ranking);
            Assert.AreEqual("account.id-456", telemetry.MatchEndEvents[0].Characters[1].AccountId);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[1].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[1].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchEndEvents[0].Characters[1].Zone);

            Assert.AreEqual("Player3", telemetry.MatchEndEvents[0].Characters[2].Name);
            Assert.AreEqual(1, telemetry.MatchEndEvents[0].Characters[2].TeamId);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[2].Health);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[2].Location.X);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[2].Location.Y);
            Assert.AreEqual(0, telemetry.MatchEndEvents[0].Characters[2].Location.Z);
            Assert.AreEqual(1, telemetry.MatchEndEvents[0].Characters[2].Ranking);
            Assert.AreEqual("account.id-789", telemetry.MatchEndEvents[0].Characters[2].AccountId);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[2].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchEndEvents[0].Characters[2].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchEndEvents[0].Characters[2].Zone);

            //Assert.AreEqual(3, telemetry.MatchEndEvents[0].RewardDetail);
            //Assert.AreEqual(3, telemetry.MatchEndEvents[0].GameResultsOnFinished);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesMatchStartsEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.MatchStartEvents.Count);

            Assert.AreEqual("06/19/2019 23:36:54", telemetry.MatchStartEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogMatchStart", telemetry.MatchStartEvents[0].Type);
            Assert.AreEqual(0.10000000149011612, telemetry.MatchStartEvents[0].Common.IsGame);

            Assert.AreEqual("Erangel_Main", telemetry.MatchStartEvents[0].MapName);
            Assert.AreEqual("Clear", telemetry.MatchStartEvents[0].WeatherId);
            Assert.AreEqual("FpsAndTps", telemetry.MatchStartEvents[0].CameraViewBehaviour);
            Assert.AreEqual(4, telemetry.MatchStartEvents[0].TeamSize);
            Assert.IsFalse(telemetry.MatchStartEvents[0].IsCustomGame);
            Assert.IsFalse(telemetry.MatchStartEvents[0].IsEventMode);
            // Assert.AreEqual("", telemetry.MatchStartEvents[0].BlueZoneCustomOptions);

            Assert.AreEqual(3, telemetry.MatchStartEvents[0].Characters.Count);

            Assert.AreEqual("Player1", telemetry.MatchStartEvents[0].Characters[0].Name);
            Assert.AreEqual(1, telemetry.MatchStartEvents[0].Characters[0].TeamId);
            Assert.AreEqual(100, telemetry.MatchStartEvents[0].Characters[0].Health);
            Assert.AreEqual(43038.5625, telemetry.MatchStartEvents[0].Characters[0].Location.X);
            Assert.AreEqual(851672.875, telemetry.MatchStartEvents[0].Characters[0].Location.Y);
            Assert.AreEqual(150088, telemetry.MatchStartEvents[0].Characters[0].Location.Z);
            Assert.AreEqual(0, telemetry.MatchStartEvents[0].Characters[0].Ranking);
            Assert.AreEqual("account.id-123", telemetry.MatchStartEvents[0].Characters[0].AccountId);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[0].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[0].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchStartEvents[0].Characters[0].Zone);

            Assert.AreEqual("Player2", telemetry.MatchStartEvents[0].Characters[1].Name);
            Assert.AreEqual(2, telemetry.MatchStartEvents[0].Characters[1].TeamId);
            Assert.AreEqual(100, telemetry.MatchStartEvents[0].Characters[1].Health);
            Assert.AreEqual(43038.5625, telemetry.MatchStartEvents[0].Characters[1].Location.X);
            Assert.AreEqual(851672.875, telemetry.MatchStartEvents[0].Characters[1].Location.Y);
            Assert.AreEqual(150088, telemetry.MatchStartEvents[0].Characters[1].Location.Z);
            Assert.AreEqual(0, telemetry.MatchStartEvents[0].Characters[1].Ranking);
            Assert.AreEqual("account.id-456", telemetry.MatchStartEvents[0].Characters[1].AccountId);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[1].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[1].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchStartEvents[0].Characters[1].Zone);

            Assert.AreEqual("Player3", telemetry.MatchStartEvents[0].Characters[2].Name);
            Assert.AreEqual(1, telemetry.MatchStartEvents[0].Characters[2].TeamId);
            Assert.AreEqual(100, telemetry.MatchStartEvents[0].Characters[2].Health);
            Assert.AreEqual(43038.5625, telemetry.MatchStartEvents[0].Characters[2].Location.X);
            Assert.AreEqual(851672.875, telemetry.MatchStartEvents[0].Characters[2].Location.Y);
            Assert.AreEqual(150088, telemetry.MatchStartEvents[0].Characters[2].Location.Z);
            Assert.AreEqual(0, telemetry.MatchStartEvents[0].Characters[2].Ranking);
            Assert.AreEqual("account.id-789", telemetry.MatchStartEvents[0].Characters[2].AccountId);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[2].IsInBlueZone);
            Assert.IsFalse(telemetry.MatchStartEvents[0].Characters[2].IsInRedZone);
            // Assert.AreEqual("", telemetry.MatchStartEvents[0].Characters[2].Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesObjectDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ObjectDestroyEvents.Count);

            Assert.AreEqual("06/19/2019 23:38:20", telemetry.ObjectDestroyEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogObjectDestroy", telemetry.ObjectDestroyEvents[0].Type);
            Assert.AreEqual(0.10000000149011612, telemetry.ObjectDestroyEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.ObjectDestroyEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ObjectDestroyEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ObjectDestroyEvents[0].Character.Health);
            Assert.AreEqual(296759.21875, telemetry.ObjectDestroyEvents[0].Character.Location.X);
            Assert.AreEqual(445691.6875, telemetry.ObjectDestroyEvents[0].Character.Location.Y);
            Assert.AreEqual(1079.851806640625, telemetry.ObjectDestroyEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ObjectDestroyEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ObjectDestroyEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ObjectDestroyEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ObjectDestroyEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.ObjectDestroyEvents[0].Character.Zone);

            Assert.AreEqual("Window", telemetry.ObjectDestroyEvents[0].ObjectType);

            Assert.AreEqual(0, telemetry.ObjectDestroyEvents[0].ObjectLocation.X);
            Assert.AreEqual(0, telemetry.ObjectDestroyEvents[0].ObjectLocation.Y);
            Assert.AreEqual(0, telemetry.ObjectDestroyEvents[0].ObjectLocation.Z);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesParachuteLandingEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.ParachuteLandingEvents.Count);

            Assert.AreEqual("06/19/2019 23:38:20", telemetry.ParachuteLandingEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogParachuteLanding", telemetry.ParachuteLandingEvents[0].Type);
            Assert.AreEqual(0.10000000149011612, telemetry.ParachuteLandingEvents[0].Common.IsGame);

            Assert.AreEqual(337.9662780761719, telemetry.ParachuteLandingEvents[0].Distance);

            Assert.AreEqual("Player1", telemetry.ParachuteLandingEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.ParachuteLandingEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.ParachuteLandingEvents[0].Character.Health);
            Assert.AreEqual(603433.0625, telemetry.ParachuteLandingEvents[0].Character.Location.X);
            Assert.AreEqual(481313.09375, telemetry.ParachuteLandingEvents[0].Character.Location.Y);
            Assert.AreEqual(1081.6036376953126, telemetry.ParachuteLandingEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.ParachuteLandingEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.ParachuteLandingEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.ParachuteLandingEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.ParachuteLandingEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("mylta", telemetry.ParachuteLandingEvents[0].Character.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerAttackEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerAttackEvents.Count);

            Assert.AreEqual("06/19/2019 23:49:59", telemetry.PlayerAttackEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerAttack", telemetry.PlayerAttackEvents[0].Type);
            Assert.AreEqual(2, telemetry.PlayerAttackEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.PlayerAttackEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.PlayerAttackEvents[0].Attacker.TeamId);
            Assert.AreEqual(75, telemetry.PlayerAttackEvents[0].Attacker.Health);
            Assert.AreEqual(486392.375, telemetry.PlayerAttackEvents[0].Attacker.Location.X);
            Assert.AreEqual(449052.9375, telemetry.PlayerAttackEvents[0].Attacker.Location.Y);
            Assert.AreEqual(1158.1199951171876, telemetry.PlayerAttackEvents[0].Attacker.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerAttackEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.PlayerAttackEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.PlayerAttackEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerAttackEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("", telemetry.PlayerAttackEvents[0].Attacker.Zone);

            Assert.AreEqual("Item_Weapon_Mini14_C", telemetry.ItemUseEvents[0].Item.ItemId);
            Assert.AreEqual(1, telemetry.ItemUseEvents[0].Item.StackCount);
            Assert.AreEqual("Weapon", telemetry.ItemUseEvents[0].Item.Category);
            Assert.AreEqual("Main", telemetry.ItemUseEvents[0].Item.SubCategory);
            // Assert.AreEqual("", telemetry.ItemUseEvents[0].Item.AttachedItems);
            // "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C", "Item_Attach_Weapon_Upper_CQBSS_C"

            Assert.IsNull(telemetry.PlayerAttackEvents[0].Vehicle);

            Assert.AreEqual(1, telemetry.PlayerAttackEvents[0].AttackId);
            Assert.AreEqual(1, telemetry.PlayerAttackEvents[0].FireWeaponStackCount);
            Assert.AreEqual(1, telemetry.PlayerAttackEvents[0].AttackType);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerCreateEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerCreateEvents.Count);

            Assert.AreEqual("06/19/2019 23:34:29", telemetry.PlayerCreateEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerCreate", telemetry.PlayerCreateEvents[0].Type);
            Assert.AreEqual(0, telemetry.PlayerCreateEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.PlayerCreateEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.PlayerCreateEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.PlayerCreateEvents[0].Character.Health);
            Assert.AreEqual(796827.4375, telemetry.PlayerCreateEvents[0].Character.Location.X);
            Assert.AreEqual(20855.162109375, telemetry.PlayerCreateEvents[0].Character.Location.Y);
            Assert.AreEqual(547.231201171875, telemetry.PlayerCreateEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerCreateEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.PlayerCreateEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.PlayerCreateEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerCreateEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.PlayerCreateEvents[0].Character.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerKillEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerKillEvents.Count);

            Assert.AreEqual("06/19/2019 23:39:00", telemetry.PlayerKillEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerKill", telemetry.PlayerKillEvents[0].Type);
            Assert.AreEqual(1, telemetry.PlayerKillEvents[0].Common.IsGame);

            Assert.AreEqual(1040187405, telemetry.PlayerKillEvents[0].AttackId);
            Assert.AreEqual(1308622848, telemetry.PlayerKillEvents[0].DBNOId);
            Assert.AreEqual("HeadShot", telemetry.PlayerKillEvents[0].DamageReason);
            Assert.AreEqual("Damage_Gun", telemetry.PlayerKillEvents[0].DamageTypeCategory);
            Assert.AreEqual("WeapHK416_C", telemetry.PlayerKillEvents[0].DamageCauserName);
            // Assert.AreEqual("", telemetry.PlayerKillEvents[0].DamageCauserAdditionalInfo);
            Assert.AreEqual(974.1304931640625, telemetry.PlayerKillEvents[0].Distance);

            Assert.AreEqual("Player1", telemetry.PlayerKillEvents[0].Killer.Name);
            Assert.AreEqual(1, telemetry.PlayerKillEvents[0].Killer.TeamId);
            Assert.AreEqual(100, telemetry.PlayerKillEvents[0].Killer.Health);
            Assert.AreEqual(546873.3125, telemetry.PlayerKillEvents[0].Killer.Location.X);
            Assert.AreEqual(254181.390625, telemetry.PlayerKillEvents[0].Killer.Location.Y);
            Assert.AreEqual(619.989990234375, telemetry.PlayerKillEvents[0].Killer.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].Killer.Ranking);
            Assert.AreEqual("account.id-123", telemetry.PlayerKillEvents[0].Killer.AccountId);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Killer.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Killer.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.PlayerKillEvents[0].Killer.Zone);

            Assert.AreEqual("Player2", telemetry.PlayerKillEvents[0].Victim.Name);
            Assert.AreEqual(2, telemetry.PlayerKillEvents[0].Victim.TeamId);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].Victim.Health);
            Assert.AreEqual(546972.4375, telemetry.PlayerKillEvents[0].Victim.Location.X);
            Assert.AreEqual(255136.890625, telemetry.PlayerKillEvents[0].Victim.Location.Y);
            Assert.AreEqual(781.6199951171875, telemetry.PlayerKillEvents[0].Victim.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].Victim.Ranking);
            Assert.AreEqual("account.id-456", telemetry.PlayerKillEvents[0].Victim.AccountId);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Victim.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Victim.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.PlayerKillEvents[0].Victim.Zone);

            Assert.AreEqual("Player3", telemetry.PlayerKillEvents[0].Assistant.Name);
            Assert.AreEqual(1, telemetry.PlayerKillEvents[0].Assistant.TeamId);
            Assert.AreEqual(100, telemetry.PlayerKillEvents[0].Assistant.Health);
            Assert.AreEqual(546735.75, telemetry.PlayerKillEvents[0].Assistant.Location.X);
            Assert.AreEqual(255261.5, telemetry.PlayerKillEvents[0].Assistant.Location.Y);
            Assert.AreEqual(815.5799560546875, telemetry.PlayerKillEvents[0].Assistant.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].Assistant.Ranking);
            Assert.AreEqual("account.id-789", telemetry.PlayerKillEvents[0].Assistant.AccountId);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Assistant.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerKillEvents[0].Assistant.IsInRedZone);
            // Assert.AreEqual("yasnayapolyana", telemetry.PlayerKillEvents[0].Assistant.Zone);

            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].VictimGameResult.Rank);
            Assert.AreEqual("", telemetry.PlayerKillEvents[0].VictimGameResult.Result);
            Assert.AreEqual(2, telemetry.PlayerKillEvents[0].VictimGameResult.TeamId);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.KillCount);
            Assert.AreEqual(77.72235870361328, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.DistanceOnFoot);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.DistanceOnSwim);
            Assert.AreEqual(0, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.DistanceOnVehicle);
            Assert.AreEqual(376.2899169921875, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.DistanceOnParachute);
            Assert.AreEqual(1733.07421875, telemetry.PlayerKillEvents[0].VictimGameResult.Stats.DistanceOnFreefall);
            Assert.AreEqual(1040187405, telemetry.PlayerKillEvents[0].VictimGameResult.AccountId);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerLoginEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerLoginEvents.Count);

            Assert.AreEqual("06/19/2019 23:34:29", telemetry.PlayerLogoutEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerLogin", telemetry.PlayerLogoutEvents[0].Type);
            Assert.AreEqual(0, telemetry.PlayerLogoutEvents[0].Common.IsGame);

            Assert.AreEqual("account.id-123", telemetry.PlayerLogoutEvents[0].AccountId);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerLogoutEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerLogoutEvents.Count);

            Assert.AreEqual("06/19/2019 23:39:22", telemetry.PlayerLogoutEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerLogout", telemetry.PlayerLogoutEvents[0].Type);
            Assert.AreEqual(1, telemetry.PlayerLogoutEvents[0].Common.IsGame);

            Assert.AreEqual("account.id-456", telemetry.PlayerLogoutEvents[0].AccountId);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerPositionEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerPositionEvents.Count);

            Assert.AreEqual("06/19/2019 23:34:39", telemetry.PlayerPositionEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerPosition", telemetry.PlayerPositionEvents[0].Type);
            Assert.AreEqual(0, telemetry.PlayerPositionEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.PlayerPositionEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.PlayerPositionEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.PlayerPositionEvents[0].Character.Health);
            Assert.AreEqual(796827.4375, telemetry.PlayerPositionEvents[0].Character.Location.X);
            Assert.AreEqual(20855.162109375, telemetry.PlayerPositionEvents[0].Character.Location.Y);
            Assert.AreEqual(528.5342407226563, telemetry.PlayerPositionEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerPositionEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.PlayerPositionEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.PlayerPositionEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerPositionEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.PlayerPositionEvents[0].Character.Zone);

            Assert.AreEqual("", telemetry.PlayerPositionEvents[0].Vehicle.VehicleType);
            Assert.AreEqual("", telemetry.PlayerPositionEvents[0].Vehicle.VehicleId);
            Assert.AreEqual(0, telemetry.PlayerPositionEvents[0].Vehicle.HealthPercent);
            Assert.AreEqual(0, telemetry.PlayerPositionEvents[0].Vehicle.FuelPercent);

            Assert.AreEqual(771, telemetry.PlayerPositionEvents[0].ElapsedTime);
            Assert.AreEqual(43, telemetry.PlayerPositionEvents[0].NumAlivePlayers);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerTakeDamageEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.PlayerTakeDamageEvents.Count);

            Assert.AreEqual("06/19/2019 23:49:59", telemetry.PlayerTakeDamageEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogPlayerTakeDamage", telemetry.PlayerTakeDamageEvents[0].Type);
            Assert.AreEqual(2, telemetry.PlayerTakeDamageEvents[0].Common.IsGame);

            Assert.AreEqual(1577058343, telemetry.PlayerTakeDamageEvents[0].AttackId);
            Assert.AreEqual("Damage_Gun", telemetry.PlayerTakeDamageEvents[0].DamageTypeCategory);
            Assert.AreEqual("PelvisShot", telemetry.PlayerTakeDamageEvents[0].DamageReason);
            Assert.AreEqual(28.979999542236329, telemetry.PlayerTakeDamageEvents[0].Damage);
            Assert.AreEqual("WeapMini14_C", telemetry.PlayerTakeDamageEvents[0].DamageCauserName);

            Assert.AreEqual("Player1", telemetry.PlayerTakeDamageEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.PlayerTakeDamageEvents[0].Attacker.TeamId);
            Assert.AreEqual(75, telemetry.PlayerTakeDamageEvents[0].Attacker.Health);
            Assert.AreEqual(486392.375, telemetry.PlayerTakeDamageEvents[0].Attacker.Location.X);
            Assert.AreEqual(449052.9375, telemetry.PlayerTakeDamageEvents[0].Attacker.Location.Y);
            Assert.AreEqual(1158.1199951171876, telemetry.PlayerTakeDamageEvents[0].Attacker.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerTakeDamageEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.PlayerTakeDamageEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.PlayerTakeDamageEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerTakeDamageEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("", telemetry.PlayerTakeDamageEvents[0].Attacker.Zone);

            Assert.AreEqual("Player2", telemetry.PlayerTakeDamageEvents[0].Victim.Name);
            Assert.AreEqual(2, telemetry.PlayerTakeDamageEvents[0].Victim.TeamId);
            Assert.AreEqual(99.75, telemetry.PlayerTakeDamageEvents[0].Victim.Health);
            Assert.AreEqual(478005.21875, telemetry.PlayerTakeDamageEvents[0].Victim.Location.X);
            Assert.AreEqual(447384.375, telemetry.PlayerTakeDamageEvents[0].Victim.Location.Y);
            Assert.AreEqual(675.3499755859375, telemetry.PlayerTakeDamageEvents[0].Victim.Location.Z);
            Assert.AreEqual(0, telemetry.PlayerTakeDamageEvents[0].Victim.Ranking);
            Assert.AreEqual("account.id-456", telemetry.PlayerTakeDamageEvents[0].Victim.AccountId);
            Assert.IsFalse(telemetry.PlayerTakeDamageEvents[0].Victim.IsInBlueZone);
            Assert.IsFalse(telemetry.PlayerTakeDamageEvents[0].Victim.IsInRedZone);
            // Assert.AreEqual("", telemetry.PlayerTakeDamageEvents[0].Victim.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesRedZoneEndedEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.RedZoneEndedEvents.Count);

            Assert.AreEqual("06/19/2019 23:47:43", telemetry.RedZoneEndedEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogRedZoneEnded", telemetry.RedZoneEndedEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.RedZoneEndedEvents[0].Common.IsGame);

            Assert.AreEqual(1, telemetry.RedZoneEndedEvents[0].Drivers.Count);

            Assert.AreEqual("Player1", telemetry.RedZoneEndedEvents[0].Drivers[0].Name);
            Assert.AreEqual(1, telemetry.RedZoneEndedEvents[0].Drivers[0].TeamId);
            Assert.AreEqual(100, telemetry.RedZoneEndedEvents[0].Drivers[0].Health);
            Assert.AreEqual(639578.5625, telemetry.RedZoneEndedEvents[0].Drivers[0].Location.X);
            Assert.AreEqual(468742.15625, telemetry.RedZoneEndedEvents[0].Drivers[0].Location.Y);
            Assert.AreEqual(551.0599975585938, telemetry.RedZoneEndedEvents[0].Drivers[0].Location.Z);
            Assert.AreEqual(0, telemetry.RedZoneEndedEvents[0].Drivers[0].Ranking);
            Assert.AreEqual("account.id-123", telemetry.RedZoneEndedEvents[0].Drivers[0].AccountId);
            Assert.IsFalse(telemetry.RedZoneEndedEvents[0].Drivers[0].IsInBlueZone);
            Assert.IsTrue(telemetry.RedZoneEndedEvents[0].Drivers[0].IsInRedZone);
            // Assert.AreEqual("", telemetry.RedZoneEndedEvents[0].Drivers[0].Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSwimEndEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.SwimEndEvents.Count);

            Assert.AreEqual("06/19/2019 23:48:15", telemetry.SwimEndEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogSwimStart", telemetry.SwimEndEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.SwimEndEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.SwimEndEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.SwimEndEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.SwimEndEvents[0].Character.Health);
            Assert.AreEqual(383196.28125, telemetry.SwimEndEvents[0].Character.Location.X);
            Assert.AreEqual(265369.0625, telemetry.SwimEndEvents[0].Character.Location.Y);
            Assert.AreEqual(-260.00634765625, telemetry.SwimEndEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.SwimEndEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.SwimEndEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.SwimEndEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.SwimEndEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("rozhok", telemetry.SwimEndEvents[0].Character.Zone);

            Assert.AreEqual(8.800971031188965, telemetry.SwimEndEvents[0].SwimDistance);
            Assert.AreEqual(532.1516723632813, telemetry.SwimEndEvents[0].MaxSwimDepthOfWater);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSwimStartEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.SwimStartEvents.Count);

            Assert.AreEqual("06/19/2019 23:48:15", telemetry.SwimStartEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogSwimStart", telemetry.SwimStartEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.SwimStartEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.SwimStartEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.SwimStartEvents[0].Character.TeamId);
            Assert.AreEqual(92, telemetry.SwimStartEvents[0].Character.Health);
            Assert.AreEqual(727007.5, telemetry.SwimStartEvents[0].Character.Location.X);
            Assert.AreEqual(261163.96875, telemetry.SwimStartEvents[0].Character.Location.Y);
            Assert.AreEqual(-380.97064208984377, telemetry.SwimStartEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.SwimStartEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.SwimStartEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.SwimStartEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.SwimStartEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.SwimStartEvents[0].Character.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVaultStartEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VaultStartEvents.Count);

            Assert.AreEqual("06/19/2019 23:48:16", telemetry.VaultStartEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogVaultStart", telemetry.VaultStartEvents[0].Type);
            Assert.AreEqual(1.5, telemetry.VaultStartEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.VaultStartEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.VaultStartEvents[0].Character.TeamId);
            Assert.AreEqual(100, telemetry.VaultStartEvents[0].Character.Health);
            Assert.AreEqual(641817.75, telemetry.VaultStartEvents[0].Character.Location.X);
            Assert.AreEqual(470017.34375, telemetry.VaultStartEvents[0].Character.Location.Y);
            Assert.AreEqual(901.010009765625, telemetry.VaultStartEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.VaultStartEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.VaultStartEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.VaultStartEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.VaultStartEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.VaultStartEvents[0].Character.Zone);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleDestroyEvents.Count);

            Assert.AreEqual("06/19/2019 23:50:42", telemetry.VehicleDestroyEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogVehicleDestroy", telemetry.VehicleDestroyEvents[0].Type);
            Assert.AreEqual(2, telemetry.VehicleDestroyEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.VehicleDestroyEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.VehicleDestroyEvents[0].Attacker.TeamId);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Attacker.Health);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Attacker.Location.X);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Attacker.Location.Y);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Attacker.Location.Z);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.VehicleDestroyEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.VehicleDestroyEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.VehicleDestroyEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("", telemetry.VehicleDestroyEvents[0].Attacker.Zone);

            Assert.AreEqual("WheeledVehicle", telemetry.VehicleDestroyEvents[0].Vehicle.VehicleType);
            Assert.AreEqual("Uaz_C_01_C", telemetry.VehicleDestroyEvents[0].Vehicle.VehicleId);
            Assert.AreEqual(0, telemetry.VehicleDestroyEvents[0].Vehicle.HealthPercent);
            Assert.AreEqual(37.54453659057617, telemetry.VehicleDestroyEvents[0].Vehicle.FuelPercent);

            Assert.AreEqual(-1, telemetry.VehicleDestroyEvents[0].AttackId);
            Assert.AreEqual("Damage_VehicleCrashHit", telemetry.VehicleDestroyEvents[0].DamageTypeCategory);
            Assert.AreEqual("Uaz_C_01_C", telemetry.VehicleDestroyEvents[0].DamageCauserName);
            Assert.AreEqual(-1, telemetry.VehicleDestroyEvents[0].Distance);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleLeaveEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleLeaveEvents.Count);

            Assert.AreEqual("06/19/2019 23:50:52", telemetry.VehicleLeaveEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogVehicleLeave", telemetry.VehicleLeaveEvents[0].Type);
            Assert.AreEqual(2, telemetry.VehicleLeaveEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.VehicleLeaveEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.VehicleLeaveEvents[0].Character.TeamId);
            Assert.AreEqual(14.039304733276368, telemetry.VehicleLeaveEvents[0].Character.Health);
            Assert.AreEqual(486830.15625, telemetry.VehicleLeaveEvents[0].Character.Location.X);
            Assert.AreEqual(463277.625, telemetry.VehicleLeaveEvents[0].Character.Location.Y);
            Assert.AreEqual(595.263427734375, telemetry.VehicleLeaveEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.VehicleLeaveEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.VehicleLeaveEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.VehicleLeaveEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.VehicleLeaveEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.VehicleLeaveEvents[0].Character.Zone);

            Assert.AreEqual("WheeledVehicle", telemetry.VehicleLeaveEvents[0].Vehicle.VehicleType);
            Assert.AreEqual("Uaz_C_01_C", telemetry.VehicleLeaveEvents[0].Vehicle.VehicleId);
            Assert.AreEqual(48.400001525878909, telemetry.VehicleLeaveEvents[0].Vehicle.HealthPercent);
            Assert.AreEqual(47.668853759765628, telemetry.VehicleLeaveEvents[0].Vehicle.FuelPercent);

            Assert.AreEqual(1708.075927734375, telemetry.VehicleLeaveEvents[0].RideDistance);
            Assert.AreEqual(0, telemetry.VehicleLeaveEvents[0].SeatIndex);
            Assert.AreEqual(97.77061462402344, telemetry.VehicleLeaveEvents[0].MaxSpeed);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesVehicleRideEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.VehicleRideEvents.Count);

            Assert.AreEqual("06/19/2019 23:50:56", telemetry.VehicleRideEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogVehicleRide", telemetry.VehicleRideEvents[0].Type);
            Assert.AreEqual(2, telemetry.VehicleRideEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.VehicleRideEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.VehicleRideEvents[0].Character.TeamId);
            Assert.AreEqual(94, telemetry.VehicleRideEvents[0].Character.Health);
            Assert.AreEqual(504985.1875, telemetry.VehicleRideEvents[0].Character.Location.X);
            Assert.AreEqual(326676.53125, telemetry.VehicleRideEvents[0].Character.Location.Y);
            Assert.AreEqual(398.5401916503906, telemetry.VehicleRideEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.VehicleRideEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.VehicleRideEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.VehicleRideEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.VehicleRideEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.VehicleRideEvents[0].Character.Zone);

            Assert.AreEqual("WheeledVehicle", telemetry.VehicleRideEvents[0].Vehicle.VehicleType);
            Assert.AreEqual("Uaz_C_01_C", telemetry.VehicleRideEvents[0].Vehicle.VehicleId);
            Assert.AreEqual(100, telemetry.VehicleRideEvents[0].Vehicle.HealthPercent);
            Assert.AreEqual(43.97563171386719, telemetry.VehicleRideEvents[0].Vehicle.FuelPercent);

            Assert.AreEqual(0, telemetry.VehicleRideEvents[0].SeatIndex);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesWeaponFireCountCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.WeaponFireCountEvents.Count);

            Assert.AreEqual("06/19/2019 23:50:59", telemetry.WeaponFireCountEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogWeaponFireCount", telemetry.WeaponFireCountEvents[0].Type);
            Assert.AreEqual(2, telemetry.WeaponFireCountEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.WeaponFireCountEvents[0].Character.Name);
            Assert.AreEqual(1, telemetry.WeaponFireCountEvents[0].Character.TeamId);
            Assert.AreEqual(93.91320037841797, telemetry.WeaponFireCountEvents[0].Character.Health);
            Assert.AreEqual(487456.03125, telemetry.WeaponFireCountEvents[0].Character.Location.X);
            Assert.AreEqual(445695.625, telemetry.WeaponFireCountEvents[0].Character.Location.Y);
            Assert.AreEqual(960.75, telemetry.WeaponFireCountEvents[0].Character.Location.Z);
            Assert.AreEqual(0, telemetry.WeaponFireCountEvents[0].Character.Ranking);
            Assert.AreEqual("account.id-123", telemetry.WeaponFireCountEvents[0].Character.AccountId);
            Assert.IsFalse(telemetry.WeaponFireCountEvents[0].Character.IsInBlueZone);
            Assert.IsFalse(telemetry.WeaponFireCountEvents[0].Character.IsInRedZone);
            // Assert.AreEqual("", telemetry.WeaponFireCountEvents[0].Character.Zone);

            Assert.AreEqual("Item_Weapon_AK47_C", telemetry.WeaponFireCountEvents[0].WeaponId);
            Assert.AreEqual(20, telemetry.WeaponFireCountEvents[0].FireCount);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesWheelDestroyEventsCorrectly()
        {
            Telemetry telemetry = Telemetry.Deserialize(SampleEventsArrayJson);

            Assert.AreEqual(1, telemetry.WheelDestroyEvents.Count);

            Assert.AreEqual("06/19/2019 23:51:56", telemetry.WheelDestroyEvents[0].Timestamp.ToString());
            Assert.AreEqual("LogWheelDestroy", telemetry.WheelDestroyEvents[0].Type);
            Assert.AreEqual(2, telemetry.WheelDestroyEvents[0].Common.IsGame);

            Assert.AreEqual("Player1", telemetry.WheelDestroyEvents[0].Attacker.Name);
            Assert.AreEqual(1, telemetry.WheelDestroyEvents[0].Attacker.TeamId);
            Assert.AreEqual(89.74388885498047, telemetry.WheelDestroyEvents[0].Attacker.Health);
            Assert.AreEqual(606647.5625, telemetry.WheelDestroyEvents[0].Attacker.Location.X);
            Assert.AreEqual(278059, telemetry.WheelDestroyEvents[0].Attacker.Location.Y);
            Assert.AreEqual(472, telemetry.WheelDestroyEvents[0].Attacker.Location.Z);
            Assert.AreEqual(0, telemetry.WheelDestroyEvents[0].Attacker.Ranking);
            Assert.AreEqual("account.id-123", telemetry.WheelDestroyEvents[0].Attacker.AccountId);
            Assert.IsFalse(telemetry.WheelDestroyEvents[0].Attacker.IsInBlueZone);
            Assert.IsFalse(telemetry.WheelDestroyEvents[0].Attacker.IsInRedZone);
            // Assert.AreEqual("", telemetry.WheelDestroyEvents[0].Attacker.Zone);

            Assert.AreEqual("WheeledVehicle", telemetry.WheelDestroyEvents[0].Vehicle.VehicleType);
            Assert.AreEqual("BP_Motorbike_04_SideCar_C", telemetry.WheelDestroyEvents[0].Vehicle.VehicleId);
            Assert.AreEqual(53.36394500732422, telemetry.WheelDestroyEvents[0].Vehicle.HealthPercent);
            Assert.AreEqual(71.52766418457031, telemetry.WheelDestroyEvents[0].Vehicle.FuelPercent);

            Assert.AreEqual(71.52766418457031, telemetry.WheelDestroyEvents[0].AttackId);
            Assert.AreEqual("Damage_Gun", telemetry.WheelDestroyEvents[0].DamageTypeCategory);
            Assert.AreEqual("WeapFNFal_C", telemetry.WheelDestroyEvents[0].DamageCauserName);
        }
    }
}
