using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.Sound;

namespace sd_bridges;

[StaticConstructorOnStartup]
public abstract class Building_sd_bridges_basedrawbridge : Building
{
    protected static readonly ThingDef sd_bridges_drawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_up");

    protected static readonly ThingDef sd_bridges_drawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_drawbridge_down");

    protected static readonly ThingDef sd_bridges_doubledrawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_doubledrawbridge_up");

    protected static readonly ThingDef sd_bridges_doubledrawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_doubledrawbridge_down");

    public static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");

    protected IntVec3 BridgeCell = new IntVec3(0, 0, 0);
    protected IntVec3 BridgeCell2 = new IntVec3(0, 0, 0);
    protected IntVec3 SecondPosition = new IntVec3(0, 0, 0);
    protected string TerrainTypeAtBridgeCellDefAsString;

    protected string TerrainTypeAtPositionDefAsString;
    protected string TerrainTypeAtSecondBridgeCellDefAsString;
    protected string TerrainTypeAtSecondPositionDefAsString;

    protected virtual void DoDustPuff()
    {
        FleckMaker.ThrowDustPuff(Position, Map, 1f);
        sound.PlayOneShot(new TargetInfo(Position, Map));
    }

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        if (def.defName.EndsWith("_down"))

        {
            yield return new Command_Action
            {
                defaultDesc = "sd_bridges.drawbridge_up_Desc".Translate(),
                defaultLabel = "sd_bridges.drawbridge_up_Lable".Translate(),
                activateSound = SoundDef.Named("Click"),
                action = SpawnDrawbridge,
                Disabled = false,
                icon = Textures.drawbridge_up
            };
        }
        else
        {
            yield return new Command_Action
            {
                defaultDesc = "sd_bridges.drawbridge_down_Desc".Translate(),
                defaultLabel = "sd_bridges.drawbridge_down_Lable".Translate(),
                activateSound = SoundDef.Named("Click"),
                action = SpawnDrawbridge,
                Disabled = false,
                icon = Textures.drawbridge_down
            };
        }
    }

    protected abstract void SpawnDrawbridge();

    protected void SetTerrain(IntVec3 position, ref string defAsStringField)
    {
        var terrainDef = Map.terrainGrid.TerrainAt(position);
        if (terrainDef == TerrainDef.Named("Mud"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("Marsh"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("WaterShallow"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterOceanShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterMovingShallowDef);
        }

        if (terrainDef == TerrainDef.Named("WaterDeep"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
        }

        if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterOceanDeepDef);
        }

        if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterMovingChestDeepDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_DigUpWater"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeMudDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_MarshWater"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeMarshDef);
        }

        if (terrainDef == TerrainDef.Named("sd_bridges_ShallowWater"))
        {
            defAsStringField = terrainDef.ToString();
            Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeWaterShallowDef);
        }

        if (terrainDef != TerrainDef.Named("sd_bridges_DeepWater"))
        {
            return;
        }

        defAsStringField = terrainDef.ToString();
        Map.terrainGrid.SetTerrain(position, Util_sd_bridges.Sd_bridges_fakeDeepWaterDef);
    }

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);

        SecondPosition = Position + new IntVec3(1, 0, 0).RotatedBy(Rotation);
        BridgeCell = Position + new IntVec3(0, 0, 1).RotatedBy(Rotation);
        BridgeCell2 = Position + new IntVec3(1, 0, 1).RotatedBy(Rotation);
    }
}