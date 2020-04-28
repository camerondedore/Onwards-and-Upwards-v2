using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateDie : MobState
{

	[SerializeField]
	GameObject[] destroyables;



	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.agent.isStopped = true;
		blackboard.agent.radius = 0.01f;
		blackboard.animator.SetTrigger("die");
		
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
