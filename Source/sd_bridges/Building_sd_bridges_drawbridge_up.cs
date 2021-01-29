using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges
{
	// Token: 0x0200000C RID: 12
	public class Building_sd_bridges_drawbridge_up : Building_sd_bridges_drawbridge
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000028A8 File Offset: 0x000018A8
		[CompilerGenerated]
		private IEnumerable<Gizmo> FabricatedMethod9()
		{
			return base.GetGizmos();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002BC4 File Offset: 0x00001BC4
		public override IEnumerable<Gizmo> GetGizmos()
		{
            var command_Action = new Command_Action
            {
                defaultDesc = Translator.Translate("sd_bridges.drawbridge_down_Desc"),
                defaultLabel = Translator.Translate("sd_bridges.drawbridge_down_Lable"),
                activateSound = SoundDef.Named("Click"),
                action = new Action(SpawnDrawbridge),
                disabled = false,
                icon = Textures.drawbridge_down
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

		// Token: 0x0600001D RID: 29 RVA: 0x00002BE8 File Offset: 0x00001BE8
		public override void SpawnDrawbridge()
		{
			Map map = base.Map;
			IntVec3 position = base.Position;
			Rot4 rotation = base.Rotation;
			if (Util_sd_bridges.IsAquaticTerrain(map, position) && Util_sd_bridges.IsAquaticTerrain(map, position + new IntVec3(0, 0, 1).RotatedBy(rotation)))
			{
				Thing thing = ThingMaker.MakeThing(Building_sd_bridges_drawbridge.sd_bridges_drawbridge_down, base.Stuff);
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

		// Token: 0x0600001E RID: 30 RVA: 0x00002CB4 File Offset: 0x00001CB4
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
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
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002F89 File Offset: 0x00001F89
		public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
		{
			base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
			base.Destroy(mode);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002FB6 File Offset: 0x00001FB6
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<string>(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
		}

		// Token: 0x04000007 RID: 7
		public string TerrainTypeAtBaseCellDefAsString;
	}
}
