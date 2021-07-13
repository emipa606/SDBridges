using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges
{
    // Token: 0x0200000B RID: 11
    [StaticConstructorOnStartup]
    public abstract class Building_sd_bridges_drawbridge : Building
    {
        // Token: 0x04000004 RID: 4
        public static readonly ThingDef sd_bridges_drawbridge_up =
            DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_up");

        // Token: 0x04000005 RID: 5
        public static readonly ThingDef sd_bridges_drawbridge_down =
            DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_down");

        // Token: 0x04000006 RID: 6
        private static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");

        // Token: 0x06000017 RID: 23 RVA: 0x00002830 File Offset: 0x00001830
        public virtual void DoDustPuff()
        {
            FleckMaker.ThrowDustPuff(Position, Map, 1f);
            sound.PlayOneShot(new TargetInfo(Position, Map));
        }

        // Token: 0x06000018 RID: 24
        public abstract void SpawnDrawbridge();
    }
}