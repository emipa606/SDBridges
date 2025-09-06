using Verse;

namespace sd_bridges;

public class PlaceWorker_NotOnShallowMovingWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var result = map.terrainGrid.BaseTerrainAt(loc).defName.ToLower().Contains("shallow") &&
                     map.terrainGrid.BaseTerrainAt(loc).defName.ToLower().Contains("moving")
            ? new AcceptanceReport("sd_bridges_placeworker_NotOnShallowWater_desc".Translate())
            : AcceptanceReport.WasAccepted;

        return result;
    }
}