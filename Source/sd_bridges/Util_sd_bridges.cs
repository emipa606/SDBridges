using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000007 RID: 7
	public static class Util_sd_bridges
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000025EC File Offset: 0x000015EC
		public static TerrainDef sd_bridges_fakeMudDef
		{
			get
			{
				return TerrainDef.Named("sd_bridges_fakeMud");
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002608 File Offset: 0x00001608
		public static TerrainDef sd_bridges_fakeMarshDef
		{
			get
			{
				return TerrainDef.Named("sd_bridges_fakeMarsh");
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002624 File Offset: 0x00001624
		public static TerrainDef sd_bridges_fakeWaterShallowDef
		{
			get
			{
				return TerrainDef.Named("sd_bridges_fakeWaterShallow");
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002640 File Offset: 0x00001640
		public static TerrainDef sd_bridges_fakeDeepWaterDef
		{
			get
			{
				return TerrainDef.Named("sd_bridges_fakeWaterDeep");
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000265C File Offset: 0x0000165C
		public static bool IsAquaticTerrain(Map map, IntVec3 position)
		{
			TerrainDef terrainDef = map.terrainGrid.TerrainAt(position);
			return terrainDef == TerrainDef.Named("WaterShallow") || terrainDef == TerrainDef.Named("WaterOceanShallow") || terrainDef == TerrainDef.Named("WaterMovingShallow") || terrainDef == TerrainDef.Named("sd_bridges_ShallowWater") || terrainDef == TerrainDef.Named("WaterDeep") || terrainDef == TerrainDef.Named("WaterOceanDeep") || terrainDef == TerrainDef.Named("WaterMovingChestDeep") || terrainDef == TerrainDef.Named("sd_bridges_DeepWater") || terrainDef == TerrainDef.Named("Marsh") || terrainDef == TerrainDef.Named("sd_bridges_MarshWater") || terrainDef == TerrainDef.Named("sd_bridges_MarshWater") || terrainDef == TerrainDef.Named("sd_bridges_fakeMud") || terrainDef == TerrainDef.Named("sd_bridges_fakeMarsh") || terrainDef == TerrainDef.Named("sd_bridges_fakeWaterShallow") || terrainDef == TerrainDef.Named("sd_bridges_fakeWaterDeep");
		}
	}
}
