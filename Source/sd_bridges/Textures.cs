using UnityEngine;
using Verse;

namespace sd_bridges;

[StaticConstructorOnStartup]
public static class Textures
{
    public static readonly Texture2D drawbridge_down =
        ContentFinder<Texture2D>.Get("sd_bridges/UI/sd_bridges_UI_drawbridge_down");

    public static readonly Texture2D drawbridge_up =
        ContentFinder<Texture2D>.Get("sd_bridges/UI/sd_bridges_UI_drawbridge_up");
}