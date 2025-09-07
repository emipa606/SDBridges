using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_quaddrawbridge_down : Building_sd_bridges_basedrawbridge
{
    protected internal override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(Map, Position) &&
            Util_sd_bridges.IsAquaticTerrain(Map, SecondPosition) &&
            Util_sd_bridges.IsAquaticTerrain(Map, ThirdPosition) &&
            Util_sd_bridges.IsAquaticTerrain(Map, FourthPosition) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell2) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell3) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell4))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_quaddrawbridge_up, Stuff);
            thing.SetFactionDirect(Faction);
            thing.HitPoints = HitPoints;
            this.DestroyedOrNull();
            DoDustPuff();
            GenSpawn.Spawn(thing, position, map, rotation);
            Find.Selector.Select(thing, false);
        }
        else
        {
            Messages.Message("sd_bridges_quaddrawbridge_not_both_water".Translate(), MessageTypeDefOf.CautionInput);
            SoundDefOf.Designate_Failed.PlayOneShotOnCamera();
        }
    }

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        SetTerrain(Position, ref TerrainTypeAtPositionDefAsString);
        SetTerrain(SecondPosition, ref TerrainTypeAtSecondPositionDefAsString);
        SetTerrain(ThirdPosition, ref TerrainTypeAtThirdPositionDefAsString);
        SetTerrain(BridgeCell, ref TerrainTypeAtBridgeCellDefAsString);
        SetTerrain(BridgeCell2, ref TerrainTypeAtSecondBridgeCellDefAsString);
        SetTerrain(BridgeCell3, ref TerrainTypeAtThirdBridgeCellDefAsString);
        SetTerrain(BridgeCell4, ref TerrainTypeAtFourthBridgeCellDefAsString);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Util_sd_bridges.TrySetTerrain(Position, Map, TerrainTypeAtPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(SecondPosition, Map, TerrainTypeAtSecondPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(ThirdPosition, Map, TerrainTypeAtThirdPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(FourthPosition, Map, TerrainTypeAtFourthPositionDefAsString);
        Util_sd_bridges.TrySetTerrain(BridgeCell, Map, TerrainTypeAtBridgeCellDefAsString);
        Util_sd_bridges.TrySetTerrain(BridgeCell2, Map, TerrainTypeAtSecondBridgeCellDefAsString);
        Util_sd_bridges.TrySetTerrain(BridgeCell3, Map, TerrainTypeAtThirdBridgeCellDefAsString);
        Util_sd_bridges.TrySetTerrain(BridgeCell4, Map, TerrainTypeAtFourthBridgeCellDefAsString);
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtPositionDefAsString, "TerrainTypeAtPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtSecondPositionDefAsString, "TerrainTypeAtSecondPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtThirdPositionDefAsString, "TerrainTypeAtThirdPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtSecondBridgeCellDefAsString, "TerrainTypeAtSecondBridgeCellDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtThirdBridgeCellDefAsString, "TerrainTypeAtThirdBridgeCellDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtFourthBridgeCellDefAsString, "TerrainTypeAtFourthBridgeCellDefAsString");
    }
}