﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges
{
	// Token: 0x0200000D RID: 13
	public class Building_sd_bridges_drawbridge_down : Building_sd_bridges_drawbridge
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002FDC File Offset: 0x00001FDC
		[CompilerGenerated]
		private IEnumerable<Gizmo> FabricatedMethod9()
		{
			return base.GetGizmos();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000032F8 File Offset: 0x000022F8
		public override IEnumerable<Gizmo> GetGizmos()
		{
            var command_Action = new Command_Action
            {
                defaultDesc = Translator.Translate("sd_bridges.drawbridge_up_Desc"),
                defaultLabel = Translator.Translate("sd_bridges.drawbridge_up_Lable"),
                activateSound = SoundDef.Named("Click"),
                action = new Action(SpawnDrawbridge),
                disabled = false,
                icon = Textures.drawbridge_up
            };
            yield return command_Action;
			if (FabricatedMethod9() != null)
			{
				foreach (Gizmo gizmo in FabricatedMethod9())
				{
					var command = (Command)gizmo;
					yield return command;
				}
			}
			yield break;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000331C File Offset: 0x0000231C
		public override void SpawnDrawbridge()
		{
			Map map = base.Map;
			IntVec3 position = base.Position;
			Rot4 rotation = base.Rotation;
			if (Util_sd_bridges.IsAquaticTerrain(map, position) && Util_sd_bridges.IsAquaticTerrain(map, position + new IntVec3(0, 0, 1).RotatedBy(rotation)))
			{
				Thing thing = ThingMaker.MakeThing(Building_sd_bridges_drawbridge.sd_bridges_drawbridge_up, base.Stuff);
				thing.SetFactionDirect(base.Faction);
				thing.HitPoints = HitPoints;
				this.DestroyedOrNull();
				DoDustPuff();
				GenSpawn.Spawn(thing, base.Position, map, base.Rotation, WipeMode.Vanish, false);
			}
			else
			{
				Messages.Message(Translator.Translate("sd_bridges_drawbridge_not_both_water"), MessageTypeDefOf.CautionInput, true);
				SoundDefOf.Designate_Failed.PlayOneShotOnCamera(null);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000033E8 File Offset: 0x000023E8
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
			BridgeCell = base.Position + new IntVec3(0, 0, 1).RotatedBy(base.Rotation);
			TerrainDef terrainDef = map.terrainGrid.TerrainAt(base.Position);
			if (terrainDef == TerrainDef.Named("Mud"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
			}
			if (terrainDef == TerrainDef.Named("Marsh"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
			}
			if (terrainDef == TerrainDef.Named("WaterShallow"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterDeep"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
			}
			if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_DigUpWater"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_MarshWater"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_ShallowWater"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_DeepWater"))
			{
				TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
			}
			TerrainDef terrainDef2 = map.terrainGrid.TerrainAt(BridgeCell);
			if (terrainDef2 == TerrainDef.Named("Mud"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMudDef);
			}
			if (terrainDef2 == TerrainDef.Named("Marsh"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMarshDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterShallow"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterOceanShallow"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterMovingShallow"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterDeep"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterOceanDeep"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterMovingChestDeep"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_DigUpWater"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMudDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_MarshWater"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMarshDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_ShallowWater"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_DeepWater"))
			{
				TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000039A0 File Offset: 0x000029A0
		public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
		{
			base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
			base.Map.terrainGrid.SetTerrain(BridgeCell, TerrainDef.Named(TerrainTypeAtBridgeCellDefAsString));
			base.Destroy(mode);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000039FA File Offset: 0x000029FA
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<string>(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
			Scribe_Values.Look<string>(ref TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString", null, false);
		}

		// Token: 0x04000008 RID: 8
		public string TerrainTypeAtBaseCellDefAsString;

		// Token: 0x04000009 RID: 9
		public string TerrainTypeAtBridgeCellDefAsString;

		// Token: 0x0400000A RID: 10
		public IntVec3 BridgeCell = new IntVec3(0, 0, 0);
	}
}
