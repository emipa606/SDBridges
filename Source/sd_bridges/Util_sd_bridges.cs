using Verse;

namespace sd_bridges
{
    // Token: 0x02000007 RID: 7
    public static class Util_sd_bridges
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600000D RID: 13 RVA: 0x000025EC File Offset: 0x000015EC
        public static TerrainDef Sd_bridges_fakeMudDef => TerrainDef.Named("sd_bridges_fakeMud");

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000E RID: 14 RVA: 0x00002608 File Offset: 0x00001608
        public static TerrainDef Sd_bridges_fakeMarshDef => TerrainDef.Named("sd_bridges_fakeMarsh");

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x0600000F RID: 15 RVA: 0x00002624 File Offset: 0x00001624
        public static TerrainDef Sd_bridges_fakeWaterShallowDef => TerrainDef.Named("sd_bridges_fakeWaterShallow");

        public static TerrainDef Sd_bridges_fakeWaterOceanShallowDef =>
            TerrainDef.Named("sd_bridges_fakeWaterOceanShallow");

        public static TerrainDef Sd_bridges_fakeWaterMovingShallowDef =>
            TerrainDef.Named("sd_bridges_fakeWaterMovingShallow");

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000010 RID: 16 RVA: 0x00002640 File Offset: 0x00001640
        public static TerrainDef Sd_bridges_fakeDeepWaterDef => TerrainDef.Named("sd_bridges_fakeWaterDeep");
        public static TerrainDef Sd_bridges_fakeWaterOceanDeepDef => TerrainDef.Named("sd_bridges_fakeWaterOceanDeep");

        public static TerrainDef Sd_bridges_fakeWaterMovingChestDeepDef =>
            TerrainDef.Named("sd_bridges_fakeWaterMovingChestDeep");

        // Token: 0x06000011 RID: 17 RVA: 0x0000265C File Offset: 0x0000165C
        public static bool IsAquaticTerrain(Map map, IntVec3 position)
        {
            var terrainDef = map.terrainGrid.TerrainAt(position);
            return terrainDef == TerrainDef.Named("WaterShallow") ||
                   terrainDef == TerrainDef.Named("WaterOceanShallow") ||
                   terrainDef == TerrainDef.Named("WaterMovingShallow") ||
                   terrainDef == TerrainDef.Named("sd_bridges_ShallowWater") ||
                   terrainDef == TerrainDef.Named("WaterDeep") ||
                   terrainDef == TerrainDef.Named("WaterOceanDeep") ||
                   terrainDef == TerrainDef.Named("WaterMovingChestDeep") ||
                   terrainDef == TerrainDef.Named("sd_bridges_DeepWater") ||
                   terrainDef == TerrainDef.Named("Marsh") ||
                   terrainDef == TerrainDef.Named("sd_bridges_MarshWater") ||
                   terrainDef == TerrainDef.Named("sd_bridges_MarshWater") ||
                   terrainDef == Sd_bridges_fakeMarshDef ||
                   terrainDef == Sd_bridges_fakeMarshDef ||
                   terrainDef == Sd_bridges_fakeWaterShallowDef ||
                   terrainDef == Sd_bridges_fakeWaterOceanShallowDef ||
                   terrainDef == Sd_bridges_fakeWaterMovingShallowDef ||
                   terrainDef == Sd_bridges_fakeDeepWaterDef ||
                   terrainDef == Sd_bridges_fakeWaterOceanDeepDef ||
                   terrainDef == Sd_bridges_fakeWaterMovingChestDeepDef;
        }
    }
}