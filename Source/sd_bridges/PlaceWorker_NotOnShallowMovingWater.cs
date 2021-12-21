using Verse;

namespace sd_bridges;

public class PlaceWorker_NotOnShallowMovingWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var named3 = DefDatabase<TerrainDef>.GetNamed("WaterMovingShallow");
        var named2 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_ShallowMovingWater");
        AcceptanceReport result;
        if (map.terrainGrid.TerrainAt(loc) == named2 || map.terrainGrid.TerrainAt(loc) == named3)
        {
            result = new AcceptanceReport("sd_bridges_placeworker_NotOnShallowWater_desc".Translate());
        }
        else
        {
            result = AcceptanceReport.WasAccepted;
        }

        return result;
    }
}