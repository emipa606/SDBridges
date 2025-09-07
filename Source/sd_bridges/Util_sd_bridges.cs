using Verse;

namespace sd_bridges;

public static class Util_sd_bridges
{
    public static JobDef Sd_bridges_drawbridge => DefDatabase<JobDef>.GetNamedSilentFail("sd_bridges_DrawBridge");

    public static TerrainDef Sd_bridges_fakeMudDef => TerrainDef.Named("sd_bridges_fakeMud");

    public static TerrainDef Sd_bridges_fakeMarshDef => TerrainDef.Named("sd_bridges_fakeMarsh");

    public static TerrainDef Sd_bridges_fakeWaterShallowDef => TerrainDef.Named("sd_bridges_fakeWaterShallow");

    public static TerrainDef Sd_bridges_fakeWaterOceanShallowDef =>
        TerrainDef.Named("sd_bridges_fakeWaterOceanShallow");

    public static TerrainDef Sd_bridges_fakeWaterMovingShallowDef =>
        TerrainDef.Named("sd_bridges_fakeWaterMovingShallow");

    public static TerrainDef Sd_bridges_fakeDeepWaterDef => TerrainDef.Named("sd_bridges_fakeWaterDeep");
    public static TerrainDef Sd_bridges_fakeWaterOceanDeepDef => TerrainDef.Named("sd_bridges_fakeWaterOceanDeep");

    public static TerrainDef Sd_bridges_fakeWaterMovingChestDeepDef =>
        TerrainDef.Named("sd_bridges_fakeWaterMovingChestDeep");

    public static void TrySetTerrain(IntVec3 intVec3, Map map, string terrainDefString)
    {
        if (string.IsNullOrEmpty(terrainDefString))
        {
            return;
        }

        var terrain = DefDatabase<TerrainDef>.GetNamedSilentFail(terrainDefString);
        if (terrain != null)
        {
            map.terrainGrid.SetTerrain(intVec3, terrain);
        }
    }

    public static bool IsAquaticTerrain(Map map, IntVec3 position)
    {
        var terrainDef = map.terrainGrid.BaseTerrainAt(position);
        return terrainDef.IsWater ||
               terrainDef == TerrainDef.Named("WaterShallow") ||
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