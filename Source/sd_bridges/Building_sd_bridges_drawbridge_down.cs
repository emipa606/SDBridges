using System;
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
			Command_Action command_Action = new Command_Action();
			command_Action.defaultDesc = Translator.Translate("sd_bridges.drawbridge_up_Desc");
			command_Action.defaultLabel = Translator.Translate("sd_bridges.drawbridge_up_Lable");
			command_Action.activateSound = SoundDef.Named("Click");
			command_Action.action = new Action(this.SpawnDrawbridge);
			command_Action.disabled = false;
			command_Action.icon = Textures.drawbridge_up;
			yield return command_Action;
			if (this.FabricatedMethod9() != null)
			{
				foreach (Gizmo gizmo in this.FabricatedMethod9())
				{
					Command command = (Command)gizmo;
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
				thing.HitPoints = this.HitPoints;
				this.DestroyedOrNull();
				this.DoDustPuff();
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
			this.BridgeCell = base.Position + new IntVec3(0, 0, 1).RotatedBy(base.Rotation);
			TerrainDef terrainDef = map.terrainGrid.TerrainAt(base.Position);
			if (terrainDef == TerrainDef.Named("Mud"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeMudDef);
			}
			if (terrainDef == TerrainDef.Named("Marsh"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeMarshDef);
			}
			if (terrainDef == TerrainDef.Named("WaterShallow"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("WaterDeep"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_DigUpWater"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeMudDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_MarshWater"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeMarshDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_ShallowWater"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef == TerrainDef.Named("sd_bridges_DeepWater"))
			{
				this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			TerrainDef terrainDef2 = map.terrainGrid.TerrainAt(this.BridgeCell);
			if (terrainDef2 == TerrainDef.Named("Mud"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeMudDef);
			}
			if (terrainDef2 == TerrainDef.Named("Marsh"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeMarshDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterShallow"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterOceanShallow"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterMovingShallow"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterDeep"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterOceanDeep"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef2 == TerrainDef.Named("WaterMovingChestDeep"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_DigUpWater"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeMudDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_MarshWater"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeMarshDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_ShallowWater"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
			if (terrainDef2 == TerrainDef.Named("sd_bridges_DeepWater"))
			{
				this.TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
				map.terrainGrid.SetTerrain(this.BridgeCell, Util_sd_bridges.sd_bridges_fakeDeepWaterDef);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000039A0 File Offset: 0x000029A0
		public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
		{
			base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(this.TerrainTypeAtBaseCellDefAsString));
			base.Map.terrainGrid.SetTerrain(this.BridgeCell, TerrainDef.Named(this.TerrainTypeAtBridgeCellDefAsString));
			base.Destroy(mode);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000039FA File Offset: 0x000029FA
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<string>(ref this.TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
			Scribe_Values.Look<string>(ref this.TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString", null, false);
		}

		// Token: 0x04000008 RID: 8
		public string TerrainTypeAtBaseCellDefAsString;

		// Token: 0x04000009 RID: 9
		public string TerrainTypeAtBridgeCellDefAsString;

		// Token: 0x0400000A RID: 10
		public IntVec3 BridgeCell = new IntVec3(0, 0, 0);
	}
}
