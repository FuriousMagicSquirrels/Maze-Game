using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ThrowBomb : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject target = ai.WorkingMemory.GetItem<GameObject>("PlayerTarget");
        GameObject bomb = ai.WorkingMemory.GetItem<GameObject>("bomb");
        GameObject enemy = ai.Body;
        if (ai.Motor.IsFacing(target.transform.position)){
            GameObject bombCopy = UnityEngine.Object.Instantiate(bomb);
            bombCopy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 5f, enemy.transform.position.z);
            Vector3 velocity = target.GetComponent<Rigidbody>().velocity;
            Vector3 direction = target.transform.position - enemy.transform.position + velocity;
            bombCopy.GetComponent<Rigidbody>().velocity = new Vector3(direction.x, direction.y , direction.z);
            var currentBomb = ai.WorkingMemory.GetItem<int>("numBomb");
            ai.WorkingMemory.SetItem<int>("numBomb", currentBomb - 1);
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