﻿using Verse;

namespace sd_bridges
{
    // Token: 0x02000002 RID: 2
    public class PlaceWorker_FundamentBaseNotInDeepWater : PlaceWorker
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
            Thing thingToIgnore = null, Thing thing = null)
        {
            var named = DefDatabase<TerrainDef>.GetNamed("WaterDeep");
            var named2 = DefDatabase<TerrainDef>.GetNamed("WaterOceanDeep");
            var named3 = DefDatabase<TerrainDef>.GetNamed("WaterMovingChestDeep");
            var named4 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_DeepWater");
            AcceptanceReport result;
            if (map.terrainGrid.TerrainAt(loc) == named || map.terrainGrid.TerrainAt(loc) == named2 ||
                map.terrainGrid.TerrainAt(loc) == named3 || map.terrainGrid.TerrainAt(loc) == named4)
            {
                result = new AcceptanceReport("sd_bridges_placeworker_FundamentBaseNotInDeepWater_desc".Translate());
            }
            else
            {
                result = AcceptanceReport.WasAccepted;
            }

            return result;
        }
    }
}