using Verse;

namespace sd_bridges
{
    // Token: 0x02000006 RID: 6
    public class Building_sd_bridges_pontoonbridge : Building
    {
        // Token: 0x04000001 RID: 1
        public string TerrainTypeAtBaseCellDefAsString;

        // Token: 0x06000009 RID: 9 RVA: 0x000022C4 File Offset: 0x000012C4
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

        // Token: 0x0600000A RID: 10 RVA: 0x00002599 File Offset: 0x00001599
        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            Map.terrainGrid.SetTerrain(Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
            base.Destroy(mode);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x000025C6 File Offset: 0x000015C6
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString");
        }
    }
}