using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Motion;
using RAIN.Navigation;
using RAIN.Navigation.Graph;
using RAIN.Navigation.Waypoints;

[RAINAction]
public class ObstructPlayer : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject target = ai.WorkingMemory.GetItem<GameObject>("PlayerTarget");
        GameObject crystal = ai.WorkingMemory.GetItem<GameObject>("crystal");
        if (!crystal) return ActionResult.FAILURE;
        GameObject enemy = ai.Body;
        Vector3 mid = new Vector3((crystal.transform.position.x + target.transform.position.x) / 2,
                                    0,
                                    (crystal.transform.position.z + target.transform.position.z) / 2);
        float dist = Vector3.Distance(enemy.transform.position, mid);
        if (dist < 3)
        {
            return ActionResult.SUCCESS;
        } else
        {
            ai.Motor.MoveTo(mid);
            ai.Motor.FaceAt(mid);
            return ActionResult.RUNNING;
        }
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}