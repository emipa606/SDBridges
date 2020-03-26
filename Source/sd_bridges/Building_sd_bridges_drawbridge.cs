using System;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges
{
	// Token: 0x0200000B RID: 11
	[StaticConstructorOnStartup]
	public abstract class Building_sd_bridges_drawbridge : Building
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002830 File Offset: 0x00001830
		public virtual void DoDustPuff()
		{
			MoteMaker.ThrowDustPuff(base.Position, base.Map, 1f);
			Building_sd_bridges_drawbridge.sound.PlayOneShot(new TargetInfo(base.Position, base.Map, false));
		}

		// Token: 0x06000018 RID: 24
		public abstract void SpawnDrawbridge();

		// Token: 0x04000004 RID: 4
		public static readonly ThingDef sd_bridges_drawbridge_up = DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_up", true);

		// Token: 0x04000005 RID: 5
		public static readonly ThingDef sd_bridges_drawbridge_down = DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_down", true);

		// Token: 0x04000006 RID: 6
		private static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");
	}
}
