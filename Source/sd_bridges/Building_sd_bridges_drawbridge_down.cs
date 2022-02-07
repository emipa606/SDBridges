using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_drawbridge_down : Building_sd_bridges_drawbridge
{
    public IntVec3 BridgeCell = new IntVec3(0, 0, 0);

    public string TerrainTypeAtBaseCellDefAsString;

    public string TerrainTypeAtBridgeCellDefAsString;

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        var command_Action = new Command_Action
        {
            defaultDesc = "sd_bridges.drawbridge_up_Desc".Translate(),
            defaultLabel = "sd_bridges.drawbridge_up_Lable".Translate(),
            activateSound = SoundDef.Named("Click"),
            action = SpawnDrawbridge,
            disabled = false,
            icon = Textures.drawbridge_up
        };
        yield return command_Action;
    }

    public override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(map, position) &&
            Util_sd_bridges.IsAquaticTerrain(map, position + new IntVec3(0, 0, 1).RotatedBy(rotation)))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_drawbridge_up, Stuff);
            thing.SetFactionDirect(Faction);
            thing.HitPoints = HitPoints;
            this.DestroyedOrNull();
            DoDustPuff();
            GenSpawn.Spawn(thing, Position, map, Rotation);
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
        BridgeCell = Position + new IntVec3(0, 0, 1).RotatedBy(Rotation);
        var terrainDef = map.terrainGrid.TerrainAt(Position);
        if (terrainDef == TerrainDef.Named("Mud"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("Marsh"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("WaterShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_DigUpWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_MarshWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_ShallowWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_DeepWater"))
        {
            TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
            map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
        }

        var terrainDef2 = map.terrainGrid.TerrainAt(BridgeCell);
        if (terrainDef2 == TerrainDef.Named("Mud"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef2 == TerrainDef.Named("Marsh"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterShallow"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterOceanShallow"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterMovingShallow"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterDeep"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterOceanDeep"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
        }

        if (terrainDef2 == TerrainDef.Named("WaterMovingChestDeep"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
        }

        if (terrainDef2 == TerrainDef.Named("sd_bridges_DigUpWater"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef2 == TerrainDef.Named("sd_bridges_MarshWater"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef2 == TerrainDef.Named("sd_bridges_ShallowWater"))
        {
            TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
            map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef2 != TerrainDef.Named("sd_bridges_DeepWater"))
        {
            return;
        }

        TerrainTypeAtBridgeCellDefAsString = terrainDef2.ToString();
        map.terrainGrid.SetTerrain(BridgeCell, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Map.terrainGrid.SetTerrain(Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
        Map.terrainGrid.SetTerrain(BridgeCell, TerrainDef.Named(TerrainTypeAtBridgeCellDefAsString));
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString");
        Scribe_Values.Look(ref TerrainTypeAtBridgeCellDefAsString, "TerrainTypeAtBridgeCellDefAsString");
    }
}