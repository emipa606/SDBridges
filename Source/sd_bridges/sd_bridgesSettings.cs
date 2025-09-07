using Verse;

namespace sd_bridges;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class sd_bridgesSettings : ModSettings
{
    public bool UseJob;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref UseJob, "UseJob");
    }
}