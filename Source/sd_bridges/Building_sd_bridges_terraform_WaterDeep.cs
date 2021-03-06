﻿using System;
using Verse;

namespace sd_bridges
{
	// Token: 0x02000010 RID: 16
	public class Building_sd_bridges_terraform_WaterDeep : Building
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00003ADC File Offset: 0x00002ADC
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			IntVec3 position = base.Position;
			base.SpawnSetup(map, respawningAfterLoad);
			base.Map.terrainGrid.SetTerrain(position, TerrainDef.Named("WaterDeep"));
			Destroy(DestroyMode.Vanish);
		}
	}
}
