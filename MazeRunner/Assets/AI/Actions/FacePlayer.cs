using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FacePlayer : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject target = ai.WorkingMemory.GetItem<GameObject>("PlayerTarget");
        if (target == null) return ActionResult.FAILURE;
        if (ai.Motor.IsFacing(target.transform.position))
        {
            return ActionResult.SUCCESS;
        }
        else
        {
            ai.Motor.FaceAt(target.transform.position);
            return ActionResult.RUNNING;
        }
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}