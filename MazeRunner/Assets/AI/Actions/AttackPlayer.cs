using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AttackPlayer : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject target = ai.WorkingMemory.GetItem<GameObject>("PlayerTarget");
        GameObject enemy = ai.Body;
        float dist = Vector3.Distance(enemy.transform.position, target.transform.position);
        if (dist < 6)
        {
            ai.Motor.FaceAt(target.transform.position);
            return ActionResult.SUCCESS;
        }
        else return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}