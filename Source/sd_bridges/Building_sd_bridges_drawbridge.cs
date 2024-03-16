using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

[StaticConstructorOnStartup]
public abstract class Building_sd_bridges_drawbridge : Building
{
    protected static readonly ThingDef sd_bridges_drawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_up");

    protected static readonly ThingDef sd_bridges_drawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_down");

    private static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");

    protected virtual void DoDustPuff()
    {
        FleckMaker.ThrowDustPuff(Position, Map, 1f);
        sound.PlayOneShot(new TargetInfo(Position, Map));
    }
}