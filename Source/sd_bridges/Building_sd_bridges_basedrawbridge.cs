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

    protected static readonly ThingDef sd_bridges_tripledrawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_tripledrawbridge_up");

    protected static readonly ThingDef sd_bridges_tripledrawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_tripledrawbridge_down");

    protected static readonly ThingDef sd_bridges_quaddrawbridge_up =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_quaddrawbridge_up");

    protected static readonly ThingDef sd_bridges_quaddrawbridge_down =
        DefDatabase<ThingDef>.GetNamed("sd_bridges_quaddrawbridge_down");

    private static readonly SoundDef sound = SoundDef.Named("ChunkRock_Drop");

    protected IntVec3 BridgeCell = new(0, 0, 0);
    protected IntVec3 BridgeCell2 = new(0, 0, 0);
    protected IntVec3 BridgeCell3 = new(0, 0, 0);
    protected IntVec3 BridgeCell4 = new(0, 0, 0);
    protected IntVec3 FourthPosition = new(0, 0, 0);
    protected IntVec3 SecondPosition = new(0, 0, 0);

    protected string TerrainTypeAtBridgeCellDefAsString;
    protected string TerrainTypeAtFourthBridgeCellDefAsString;
    protected string TerrainTypeAtFourthPositionDefAsString;
    protected string TerrainTypeAtPositionDefAsString;
    protected string TerrainTypeAtSecondBridgeCellDefAsString;
    protected string TerrainTypeAtSecondPositionDefAsString;
    protected string TerrainTypeAtThirdBridgeCellDefAsString;
    protected string TerrainTypeAtThirdPositionDefAsString;
    protected IntVec3 ThirdPosition = new(0, 0, 0);

    public bool WantsDrawing;

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

        var activateSound = SoundDef.Named("Click");
        var label = "sd_bridges.drawbridge_up_Lable".Translate();
        var description = "sd_bridges.drawbridge_up_Desc".Translate();
        var icon = Textures.drawbridge_up;
        var action = SpawnDrawbridge;

        if (!def.defName.EndsWith("_down"))
        {
            label = "sd_bridges.drawbridge_down_Lable".Translate();
            description = "sd_bridges.drawbridge_down_Desc".Translate();
            icon = Textures.drawbridge_down;
        }

        if (sd_bridgesMod.instance.Settings.UseJob)
        {
            yield return new Command_Toggle
            {
                defaultDesc = description,
                defaultLabel = label,
                activateSound = activateSound,
                isActive = () => WantsDrawing,
                Disabled = false,
                icon = icon,
                toggleAction = () => WantsDrawing = !WantsDrawing
            };

            yield break;
        }

        yield return new Command_Action
        {
            defaultDesc = description,
            defaultLabel = label,
            activateSound = activateSound,
            action = action,
            Disabled = false,
            icon = icon
        };
    }

    protected internal abstract void SpawnDrawbridge();

    protected void SetTerrain(IntVec3 position, ref string defAsStringField)
    {
        var terrainDef = Map.terrainGrid.BaseTerrainAt(position);

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
        ThirdPosition = Position + new IntVec3(-1, 0, 0).RotatedBy(Rotation);
        FourthPosition = Position + new IntVec3(2, 0, 0).RotatedBy(Rotation);
        BridgeCell = Position + new IntVec3(0, 0, 1).RotatedBy(Rotation);
        BridgeCell2 = Position + new IntVec3(1, 0, 1).RotatedBy(Rotation);
        BridgeCell3 = Position + new IntVec3(-1, 0, 1).RotatedBy(Rotation);
        BridgeCell4 = Position + new IntVec3(2, 0, 1).RotatedBy(Rotation);
    }
}