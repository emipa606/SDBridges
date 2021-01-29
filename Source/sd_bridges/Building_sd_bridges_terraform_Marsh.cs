using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000011 RID: 17
	public class Building_sd_bridges_terraform_Marsh : Building
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00003B28 File Offset: 0x00002B28
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			IntVec3 position = base.Position;
			base.SpawnSetup(map, respawningAfterLoad);
			base.Map.terrainGrid.SetTerrain(position, TerrainDef.Named("Marsh"));
			Destroy(DestroyMode.Vanish);
		}
	}
}
