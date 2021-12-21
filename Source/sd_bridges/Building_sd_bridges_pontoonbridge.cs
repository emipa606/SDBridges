using Verse;

namespace sd_bridges;

public class Building_sd_bridges_pontoonbridge : Building
{
    public string TerrainTypeAtBaseCellDefAsString;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        var terrainDef = map.terrainGrid.TerrainAt(Position);
        if (terrainDef == TerrainDef.Named("Mud"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("Marsh"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("WaterShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_DigUpWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_MarshWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_ShallowWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef != TerrainDef.Named("sd_bridges_DeepWater"))
        {
            return;
        }

        TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
        map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Map.terrainGrid.SetTerrain(Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString");
    }
}