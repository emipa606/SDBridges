using Verse;

namespace sd_bridges;

public class Building_sd_bridges_terraform_Mud : Building
{
    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        var position = Position;
        base.SpawnSetup(map, respawningAfterLoad);
        Map.terrainGrid.SetTerrain(position, TerrainDef.Named("Mud"));
        Destroy();
    }
}