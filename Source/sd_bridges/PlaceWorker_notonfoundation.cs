using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000008 RID: 8
	public class PlaceWorker_notonfoundation : PlaceWorker
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002754 File Offset: 0x00001754
		public virtual AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
		{
			TerrainDef named = DefDatabase<TerrainDef>.GetNamed("sd_bridges_FundamentBase", true);
			AcceptanceReport result;
			if (map.terrainGrid.TerrainAt(loc) == named)
			{
				result = new AcceptanceReport(Translator.Translate("sd_bridges_placeworker_notonfoundation_desc"));
			}
			else
			{
				result = AcceptanceReport.WasAccepted;
			}
			return result;
		}
	}
}
