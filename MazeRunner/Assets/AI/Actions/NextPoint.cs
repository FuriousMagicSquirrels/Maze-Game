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
using RAIN.Navigation.Targets;

[RAINAction]
public class NextPoint : RAINAction
{
    public Expression MoveTargetVariable = new Expression(); //the variable you want to use for the output move target
    private MoveLookTarget moveTarget = new MoveLookTarget();
    private int lastWaypoint = -1;
    private HashSet<int> visited;
    private Stack<int> stack;
    public override void Start(RAIN.Core.AI ai)
    {
        visited = ai.WorkingMemory.GetItem<HashSet<int>>("visited");
        if (visited == null)
        {
            ai.WorkingMemory.SetItem<HashSet<int>>("visited", new HashSet<int>());
            visited = ai.WorkingMemory.GetItem<HashSet<int>>("visited");
        }
        stack = ai.WorkingMemory.GetItem<Stack<int>>("stack");
        if (stack == null)
        {
            ai.WorkingMemory.SetItem<Stack<int>>("stack", new Stack<int>());
            stack = ai.WorkingMemory.GetItem<Stack<int>>("stack");
            stack.Push(0);
        }
        base.Start(ai);
    }
    public override ActionResult Execute(AI ai)
    {
        NavigationTarget finish = NavigationManager.Instance.GetNavigationTarget("Finish");
        moveTarget.VectorTarget = finish.Position;
        moveTarget.CloseEnoughDistance = Mathf.Max(finish.Range, ai.Motor.CloseEnoughDistance);
        if (ai.Motor.IsAt(moveTarget))
        {
            return ActionResult.FAILURE;
        }

        if (!MoveTargetVariable.IsValid || !MoveTargetVariable.IsVariable)
            return ActionResult.FAILURE;

        WaypointSet waypointSet = NavigationManager.Instance.GetWaypointSet("Network");
        if (waypointSet == null)
            return ActionResult.FAILURE;


        lastWaypoint = waypointSet.GetClosestWaypointIndex(ai.Kinematic.Position);
        if (lastWaypoint< 0)
            return ActionResult.FAILURE;


        visited.Add(lastWaypoint);
        moveTarget.VectorTarget = waypointSet.Waypoints[lastWaypoint].Position;
        moveTarget.CloseEnoughDistance = Mathf.Max(waypointSet.Waypoints[lastWaypoint].Range, ai.Motor.CloseEnoughDistance);
        if (!ai.Motor.IsAt(moveTarget))
        {
            ai.WorkingMemory.SetItem<MoveLookTarget>(MoveTargetVariable.VariableName, moveTarget);
            return ActionResult.SUCCESS;
        }

        //If currently at a waypoint
        NavigationGraphNode tNode = waypointSet.Graph.GetNode(lastWaypoint);
        if (tNode.OutEdgeCount > 0)
        {
            var numbers =  new List<int>();
            for (int i = 0; i < tNode.OutEdgeCount; i++)numbers.Add(i);
            for (int i = 0; i < tNode.OutEdgeCount; i++)
            {
                int j = UnityEngine.Random.Range(0, tNode.OutEdgeCount - 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
            for (int i = 0; i < tNode.OutEdgeCount; i++)
            {
                lastWaypoint = ((VectorPathNode)tNode.EdgeOut(numbers[i]).ToNode).NodeIndex;
                if (visited.Contains(lastWaypoint))continue;
                visited.Add(lastWaypoint);
                stack.Push(lastWaypoint);
                moveTarget.VectorTarget = waypointSet.Waypoints[lastWaypoint].Position;
                moveTarget.CloseEnoughDistance = Mathf.Max(waypointSet.Waypoints[lastWaypoint].Range, ai.Motor.CloseEnoughDistance);
                ai.WorkingMemory.SetItem<MoveLookTarget>(MoveTargetVariable.VariableName, moveTarget);
                return ActionResult.SUCCESS;
            }
        }
        if (stack.Count == 0) return ActionResult.FAILURE;
        stack.Pop();
        Debug.Log(stack.Count);
        if (stack.Count > 0)
        {
            moveTarget.VectorTarget = waypointSet.Waypoints[stack.Peek()].Position;
            moveTarget.CloseEnoughDistance = Mathf.Max(waypointSet.Waypoints[lastWaypoint].Range, ai.Motor.CloseEnoughDistance);
            ai.WorkingMemory.SetItem<MoveLookTarget>(MoveTargetVariable.VariableName, moveTarget);
            return ActionResult.SUCCESS;
        } else return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}