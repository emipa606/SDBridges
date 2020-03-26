using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000003 RID: 3
	public class PlaceWorker_OnFundamentBasis : PlaceWorker
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00001104
		public virtual AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
		{
			TerrainDef named = DefDatabase<TerrainDef>.GetNamed("sd_bridges_FundamentBase", true);
			AcceptanceReport result;
			if (map.terrainGrid.TerrainAt(loc) == named)
			{
				result = AcceptanceReport.WasAccepted;
			}
			else
			{
				result = new AcceptanceReport(Translator.Translate("sd_bridges_placeworker_OnFundamentBasis_desc"));
			}
			return result;
		}
	}
}
