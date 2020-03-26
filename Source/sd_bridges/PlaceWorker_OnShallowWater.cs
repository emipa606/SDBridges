using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000004 RID: 4
	public class PlaceWorker_OnShallowWater : PlaceWorker
	{
		// Token: 0x06000005 RID: 5 RVA: 0x0000215C File Offset: 0x0000115C
		public virtual AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
		{
			TerrainDef named = DefDatabase<TerrainDef>.GetNamed("WaterShallow", true);
			TerrainDef named2 = DefDatabase<TerrainDef>.GetNamed("WaterOceanShallow", true);
			TerrainDef named3 = DefDatabase<TerrainDef>.GetNamed("WaterMovingShallow", true);
			TerrainDef named4 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_ShallowWater", true);
			AcceptanceReport result;
			if (map.terrainGrid.TerrainAt(loc) == named || map.terrainGrid.TerrainAt(loc) == named2 || map.terrainGrid.TerrainAt(loc) == named3 || map.terrainGrid.TerrainAt(loc) == named4)
			{
				result = AcceptanceReport.WasAccepted;
			}
			else
			{
				result = new AcceptanceReport(Translator.Translate("sd_bridges_placeworker_OnShallowWater_desc"));
			}
			return result;
		}
	}
}
