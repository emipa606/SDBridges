using Verse;

namespace sd_bridges;

public class PlaceWorker_notonfoundation : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var named = DefDatabase<TerrainDef>.GetNamed("sd_bridges_FundamentBase");
        var result = map.terrainGrid.TerrainAt(loc) == named
            ? new AcceptanceReport("sd_bridges_placeworker_notonfoundation_desc".Translate())
            : AcceptanceReport.WasAccepted;

        return result;
    }
}