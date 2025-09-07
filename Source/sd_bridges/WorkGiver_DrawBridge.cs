using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using Verse.AI;

namespace sd_bridges;

public class WorkGiver_DrawBridge : WorkGiver_Scanner
{
    public override PathEndMode PathEndMode => PathEndMode.Touch;

    public override Danger MaxPathDanger(Pawn pawn)
    {
        return Danger.Deadly;
    }

    public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
    {
        foreach (var drawBridge in pawn.Map.listerThings.GetThingsOfType<Building_sd_bridges_basedrawbridge>())
        {
            if (drawBridge.WantsDrawing)
            {
                yield return drawBridge;
            }
        }
    }

    public override bool ShouldSkip(Pawn pawn, bool forced = false)
    {
        if (!sd_bridgesMod.instance.Settings.UseJob)
        {
            return false;
        }

        return !pawn.Map.listerThings.GetThingsOfType<Building_sd_bridges_basedrawbridge>()
            .Any(basedrawbridge => basedrawbridge.WantsDrawing);
    }

    public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
    {
        return t is Building_sd_bridges_basedrawbridge { WantsDrawing: true } &&
               pawn.CanReserve(t, 1, -1, null, forced);
    }

    public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
    {
        return JobMaker.MakeJob(Util_sd_bridges.Sd_bridges_drawbridge, t);
    }
}