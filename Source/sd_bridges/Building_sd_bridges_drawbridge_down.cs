using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_drawbridge_down : Building_sd_bridges_basedrawbridge
{
    protected internal override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(Map, Position) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_drawbridge_up, Stuff);
            thing.SetFactionDirect(Faction);
            thing.HitPoints = HitPoints;
            this.DestroyedOrNull();
            DoDustPuff();
            GenSpawn.Spawn(thing, position, map, rotation);
            Find.Selector.Select(thing, false);
        }
        else
        {
            Messages.Message("sd_bridges_drawbridge_not_both_water".Translate(), MessageTypeDefOf.CautionInput);
            SoundDefOf.Designate_Failed.PlayOneShotOnCamera();
        }
    }

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);

        SetTerrain(Position, ref TerrainTypeAtPositionDefAsString);
        SetTerrain(BridgeCell, ref TerrainTypeAtBridgeCellDefAsString);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Util_sd_bridges.TrySetTerrain(Position, Map, TerrainTypeAtPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(BridgeCell, Map, TerrainTypeAtBridgeCellDefAsString);
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtPositionDefAsString, "TerrainTypeAtPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString");
    }
}