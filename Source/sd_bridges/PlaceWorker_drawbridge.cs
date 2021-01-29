using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000009 RID: 9
	public class PlaceWorker_drawbridge : PlaceWorker
	{
		// Token: 0x06000014 RID: 20 RVA: 0x000027AC File Offset: 0x000017AC
		public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
		{
			AcceptanceReport result;
			if (Util_sd_bridges.IsAquaticTerrain(map, loc) && Util_sd_bridges.IsAquaticTerrain(map, loc + new IntVec3(0, 0, 1).RotatedBy(rot)))
			{
				result = AcceptanceReport.WasAccepted;
			}
			else
			{
				result = new AcceptanceReport(Translator.Translate("sd_bridges_placeworker_drawbridge_desc"));
			}
			return result;
		}
	}
}
