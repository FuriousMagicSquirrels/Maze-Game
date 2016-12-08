using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class TauntScript : RAINAction
{
    string[] allScripts = new string[] { "You're so bad", "You're suck", "You're a loser", "You can't beat me" };
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject bubble = ai.WorkingMemory.GetItem<GameObject>("bubble");
        GameObject enemy = ai.Body;
        GameObject bubbleCopy = UnityEngine.Object.Instantiate(bubble);
        bubbleCopy.GetComponent<TextMesh>().text = allScripts[UnityEngine.Random.Range(0, allScripts.Length)];
        bubbleCopy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 2f, enemy.transform.position.z);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}