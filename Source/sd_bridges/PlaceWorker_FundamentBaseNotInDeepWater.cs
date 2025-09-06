using Verse;

namespace sd_bridges;

public class PlaceWorker_FundamentBaseNotInDeepWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var named = DefDatabase<TerrainDef>.GetNamed("WaterDeep");
        var named2 = DefDatabase<TerrainDef>.GetNamed("WaterOceanDeep");
        var named3 = DefDatabase<TerrainDef>.GetNamed("WaterMovingChestDeep");
        var named4 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_DeepWater");
        AcceptanceReport result;
        if (map.terrainGrid.BaseTerrainAt(loc) == named || map.terrainGrid.BaseTerrainAt(loc) == named2 ||
            map.terrainGrid.BaseTerrainAt(loc) == named3 || map.terrainGrid.BaseTerrainAt(loc) == named4)
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