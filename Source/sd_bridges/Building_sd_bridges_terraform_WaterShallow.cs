using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x0200000F RID: 15
	public class Building_sd_bridges_terraform_WaterShallow : Building
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003A90 File Offset: 0x00002A90
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			IntVec3 position = base.Position;
			base.SpawnSetup(map, respawningAfterLoad);
			base.Map.terrainGrid.SetTerrain(position, TerrainDef.Named("WaterShallow"));
			this.Destroy(DestroyMode.Vanish);
		}
	}
}
