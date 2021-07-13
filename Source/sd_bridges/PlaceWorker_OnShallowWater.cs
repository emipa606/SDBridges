using Verse;

namespace sd_bridges
{
    // Token: 0x02000004 RID: 4
    public class PlaceWorker_OnShallowWater : PlaceWorker
    {
        // Token: 0x06000005 RID: 5 RVA: 0x0000215C File Offset: 0x0000115C
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
            Thing thingToIgnore = null, Thing thing = null)
        {
            var named = DefDatabase<TerrainDef>.GetNamed("WaterShallow");
            var named2 = DefDatabase<TerrainDef>.GetNamed("WaterOceanShallow");
            var named4 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_ShallowWater");
            AcceptanceReport result;
            if (map.terrainGrid.TerrainAt(loc) == named || map.terrainGrid.TerrainAt(loc) == named2 ||
                map.terrainGrid.TerrainAt(loc) == named4)
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
}