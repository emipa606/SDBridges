using Verse;

namespace sd_bridges;

public class PlaceWorker_OnShallowWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        AcceptanceReport result;
        if (map.terrainGrid.BaseTerrainAt(loc).defName.ToLower().Contains("shallow") &&
            !map.terrainGrid.BaseTerrainAt(loc).defName.ToLower().Contains("moving"))
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