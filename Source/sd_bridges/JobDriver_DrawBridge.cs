using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace sd_bridges;

public class JobDriver_DrawBridge : JobDriver
{
    public override bool TryMakePreToilReservations(bool errorOnFailed)
    {
        return pawn.Reserve(job.targetA, job, 1, -1, null, errorOnFailed);
    }

    protected override IEnumerable<Toil> MakeNewToils()
    {
        this.FailOnDespawnedOrNull(TargetIndex.A);
        this.FailOn(() => TargetThingA is not Building_sd_bridges_basedrawbridge { WantsDrawing: true });
        yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
        yield return Toils_General.Wait(15).FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch);
        var finalize = ToilMaker.MakeToil();
        finalize.initAction = delegate
        {
            var actor = finalize.actor;
            var basedrawbridge = (Building_sd_bridges_basedrawbridge)actor.CurJob.targetA.Thing;
            basedrawbridge.SpawnDrawbridge();
            actor.records.Increment(RecordDefOf.SwitchesFlicked);
        };
        finalize.defaultCompleteMode = ToilCompleteMode.Instant;
        yield return finalize;
    }
}