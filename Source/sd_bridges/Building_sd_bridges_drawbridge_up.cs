using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

public class Building_sd_bridges_drawbridge_up : Building_sd_bridges_drawbridge
{
    public string TerrainTypeAtBaseCellDefAsString;

    [CompilerGenerated]
    private IEnumerable<Gizmo> FabricatedMethod9()
    {
        return base.GetGizmos();
    }

    public override IEnumerable<Gizmo> GetGizmos()
    {
        var command_Action = new Command_Action
        {
            defaultDesc = "sd_bridges.drawbridge_down_Desc".Translate(),
            defaultLabel = "sd_bridges.drawbridge_down_Lable".Translate(),
            activateSound = SoundDef.Named("Click"),
            action = SpawnDrawbridge,
            disabled = false,
            icon = Textures.drawbridge_down
        };
        yield return command_Action;
        if (FabricatedMethod9() == null)
        {
            yield break;
        }

        foreach (var gizmo in FabricatedMethod9())
        {
            var command = (Command)gizmo;
            yield return command;
        }
    }

    public override void SpawnDrawbridge()
    {
        var map = Map;
        var position = Position;
        var rotation = Rotation;
        if (Util_sd_bridges.IsAquaticTerrain(map, position) &&
            Util_sd_bridges.IsAquaticTerrain(map, position + new IntVec3(0, 0, 1).RotatedBy(rotation)))
        {
            var thing = ThingMaker.MakeThing(sd_bridges_drawbridge_down, Stuff);
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

        if (terrainDef != TerrainDef.Named("sd_bridges_DeepWater"))
        {
            return;
        }

        TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
        map.terrainGrid.SetTerrain(Position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        Map.terrainGrid.SetTerrain(Position, TerrainDef.Named(TerrainTypeAtBaseCellDefAsString));
        base.Destroy(mode);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString");
    }
}