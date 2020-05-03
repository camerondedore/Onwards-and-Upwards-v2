using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDieState : MobState
{

	[SerializeField]
	GameObject[] destroyables;



	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.controller.agent.isStopped = true;
		blackboard.controller.agent.radius = 0.01f;
		blackboard.controller.enabled = false;
		blackboard.animator.SetTrigger("die");
		blackboard.animator.ResetTrigger("attack");
		blackboard.animator.ResetTrigger("idle");
		blackboard.dropper.Drop();
		
		foreach(var g in destroyables)
		{
			Destroy(g);
		}
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		return this;
	}
}
