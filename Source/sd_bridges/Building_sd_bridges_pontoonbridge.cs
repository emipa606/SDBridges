using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000006 RID: 6
	public class Building_sd_bridges_pontoonbridge : Building
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000022C4 File Offset: 0x000012C4
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
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
				map.terrainGrid.SetTerrain(base.Position, Util_sd_bridges.sd_bridges_fakeWaterShallowDef);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002599 File Offset: 0x00001599
		public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
		{
			base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(this.TerrainTypeAtBaseCellDefAsString));
			base.Destroy(mode);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000025C6 File Offset: 0x000015C6
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<string>(ref this.TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
		}

		// Token: 0x04000001 RID: 1
		public string TerrainTypeAtBaseCellDefAsString;
	}
}
