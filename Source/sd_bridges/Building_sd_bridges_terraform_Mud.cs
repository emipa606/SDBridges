using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x0200000E RID: 14
	public class Building_sd_bridges_terraform_Mud : Building
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00003A44 File Offset: 0x00002A44
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			IntVec3 position = base.Position;
			base.SpawnSetup(map, respawningAfterLoad);
			base.Map.terrainGrid.SetTerrain(position, TerrainDef.Named("Mud"));
			Destroy(DestroyMode.Vanish);
		}
	}
}
