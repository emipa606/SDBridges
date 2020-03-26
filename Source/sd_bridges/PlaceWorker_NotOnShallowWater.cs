using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000005 RID: 5
	public class PlaceWorker_NotOnShallowWater : PlaceWorker
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002210 File Offset: 0x00001210
		public virtual AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
		{
			TerrainDef named = DefDatabase<TerrainDef>.GetNamed("WaterShallow", true);
			TerrainDef named2 = DefDatabase<TerrainDef>.GetNamed("WaterOceanShallow", true);
			TerrainDef named3 = DefDatabase<TerrainDef>.GetNamed("WaterMovingShallow", true);
			TerrainDef named4 = DefDatabase<TerrainDef>.GetNamed("sd_bridges_ShallowWater", true);
			AcceptanceReport result;
			if (map.terrainGrid.TerrainAt(loc) == named || map.terrainGrid.TerrainAt(loc) == named2 || map.terrainGrid.TerrainAt(loc) == named3 || map.terrainGrid.TerrainAt(loc) == named4)
			{
				result = new AcceptanceReport(Translator.Translate("sd_bridges_placeworker_NotOnShallowWater_desc"));
			}
			else
			{
				result = AcceptanceReport.WasAccepted;
			}
			return result;
		}
	}
}
