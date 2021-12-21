using Verse;

namespace sd_bridges;

public class PlaceWorker_drawbridge : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        AcceptanceReport result;
        if (Util_sd_bridges.IsAquaticTerrain(map, loc) &&
            Util_sd_bridges.IsAquaticTerrain(map, loc + new IntVec3(0, 0, 1).RotatedBy(rot)))
        {
            result = AcceptanceReport.WasAccepted;
        }
        else
        {
            result = new AcceptanceReport("sd_bridges_placeworker_drawbridge_desc".Translate());
        }

        return result;
    }
}