using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

[StaticConstructorOnStartup]
public abstract class Building_sd_bridges_drawbridge : Building
{
    public static readonly ThingDef sd_bridges_drawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_up");

    public static readonly ThingDef sd_bridges_drawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_down");

    private static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");

    public virtual void DoDustPuff()
    {
        FleckMaker.ThrowDustPuff(Position, Map, 1f);
        sound.PlayOneShot(new TargetInfo(Position, Map));
    }

    public abstract void SpawnDrawbridge();
}