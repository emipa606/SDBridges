using Verse;

namespace sd_bridges;

public class PlaceWorker_OnFundamentBasis : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var named = DefDatabase<TerrainDef>.GetNamed("sd_bridges_FundamentBase");
        var result = map.terrainGrid.BaseTerrainAt(loc) == named
            ? AcceptanceReport.WasAccepted
            : new AcceptanceReport("sd_bridges_placeworker_OnFundamentBasis_desc".Translate());

        return result;
    }
}