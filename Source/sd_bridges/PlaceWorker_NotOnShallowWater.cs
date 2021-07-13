using Verse;

namespace sd_bridges
{
    // Token: 0x02000005 RID: 5
    public class PlaceWorker_NotOnShallowWater : PlaceWorker
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002210 File Offset: 0x00001210
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
                result = new AcceptanceReport("sd_bridges_placeworker_NotOnShallowWater_desc".Translate());
            }
            else
            {
                result = AcceptanceReport.WasAccepted;
            }

            return result;
        }
    }
}