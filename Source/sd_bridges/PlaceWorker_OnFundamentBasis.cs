using Verse;

namespace sd_bridges
{
    // Token: 0x02000003 RID: 3
    public class PlaceWorker_OnFundamentBasis : PlaceWorker
    {
        // Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00001104
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
            Thing thingToIgnore = null, Thing thing = null)
        {
            var named = DefDatabase<TerrainDef>.GetNamed("sd_bridges_FundamentBase");
            var result = map.terrainGrid.TerrainAt(loc) == named
                ? AcceptanceReport.WasAccepted
                : new AcceptanceReport("sd_bridges_placeworker_OnFundamentBasis_desc".Translate());

            return result;
        }
    }
}