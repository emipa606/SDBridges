using System;
using UnityEngine;
using Verse;

namespace sd_bridges
{
	// Token: 0x0200000A RID: 10
	[StaticConstructorOnStartup]
	public static class Textures
	{
		// Token: 0x04000002 RID: 2
		public static readonly Texture2D drawbridge_down = ContentFinder<Texture2D>.Get("sd_bridges/UI/sd_bridges_UI_drawbridge_down", true);

		// Token: 0x04000003 RID: 3
		public static readonly Texture2D drawbridge_up = ContentFinder<Texture2D>.Get("sd_bridges/UI/sd_bridges_UI_drawbridge_up", true);
	}
}
