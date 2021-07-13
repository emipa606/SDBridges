using Verse;

namespace sd_bridges
{
    // Token: 0x02000008 RID: 8
    public class PlaceWorker_notonfoundation : PlaceWorker
    {
        // Token: 0x06000012 RID: 18 RVA: 0x00002754 File Offset: 0x00001754
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
}