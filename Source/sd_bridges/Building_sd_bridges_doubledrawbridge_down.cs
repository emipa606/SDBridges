using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_doubledrawbridge_down : Building_sd_bridges_basedrawbridge
{
    protected override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(Map, Position) &&
            Util_sd_bridges.IsAquaticTerrain(Map, SecondPosition) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell) &&
            Util_sd_bridges.IsAquaticTerrain(Map, BridgeCell2))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_doubledrawbridge_up, Stuff);
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
        SetTerrain(BridgeCell, ref TerrainTypeAtBridgeCellDefAsString);
        SetTerrain(BridgeCell2, ref TerrainTypeAtSecondBridgeCellDefAsString);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Map.terrainGrid.SetTerrain(Position, TerrainDef.Named(TerrainTypeAtPositionDefAsString));
        Map.terrainGrid.SetTerrain(SecondPosition, TerrainDef.Named(TerrainTypeAtSecondPositionDefAsString));
        Map.terrainGrid.SetTerrain(BridgeCell, TerrainDef.Named(TerrainTypeAtBridgeCellDefAsString));
        Map.terrainGrid.SetTerrain(BridgeCell2, TerrainDef.Named(TerrainTypeAtSecondBridgeCellDefAsString));
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtPositionDefAsString, "TerrainTypeAtPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtSecondPositionDefAsString, "TerrainTypeAtSecondPositionDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtSecondBridgeCellDefAsString, "TerrainTypeAtSecondBridgeCellDefAsString");
    }
}