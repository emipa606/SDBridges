using Verse;

namespace sd_bridges;

public class PlaceWorker_OnMovingShallowWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var named1 = DefDatabase<TerrainDef>.GetNamed("WaterMovingShallow");
        var named2 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_ShallowMovingWater");
        AcceptanceReport result;
        if (map.terrainGrid.TerrainAt(loc) == named1 || map.terrainGrid.TerrainAt(loc) == named2)
        {
            result = AcceptanceReport.WasAccepted;
        }
        else
        {
            result = new AcceptanceReport("sd_bridges_placeworker_OnShallowWater_desc".Translate());
        }

        return result;
    }
}