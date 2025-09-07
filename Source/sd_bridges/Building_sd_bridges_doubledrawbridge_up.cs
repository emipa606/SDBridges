using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_doubledrawbridge_up : Building_sd_bridges_basedrawbridge
{
    protected internal override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(Map, Position) &&
            Util_sd_bridges.IsAquaticTerrain(Map, SecondPosition) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell2))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_doubledrawbridge_down, Stuff);
            thing.SetFactionDirect(Faction);
            thing.HitPoints = HitPoints;
            this.DestroyedOrNull();
            DoDustPuff();
            GenSpawn.Spawn(thing, position, map, rotation);
            Find.Selector.Select(thing, false);
        }
        else
        {
            Messages.Message("sd_bridges_doubledrawbridge_not_both_water".Translate(), MessageTypeDefOf.CautionInput);
            SoundDefOf.Designate_Failed.PlayOneShotOnCamera();
        }
    }

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);

        SetTerrain(Position, ref TerrainTypeAtPositionDefAsString);
        SetTerrain(SecondPosition, ref TerrainTypeAtSecondPositionDefAsString);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Util_sd_bridges.TrySetTerrain(Position, Map, TerrainTypeAtPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(SecondPosition, Map, TerrainTypeAtSecondPositionDefAsString);
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtPositionDefAsString, "TerrainTypeAtPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtSecondPositionDefAsString, "TerrainTypeAtSecondPositionDefAsString");
    }
}