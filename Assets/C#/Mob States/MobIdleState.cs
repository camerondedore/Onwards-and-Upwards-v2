using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobIdleState : MobState
{





	public override void RunState()
	{
		blackboard.target = MobTools.GetClosestEnemy(blackboard.myFaction, blackboard.eyes.position, blackboard.eyeMask);
	}



	public override void StartState()
	{
		blackboard.controller.agent.isStopped = true;
		blackboard.animator.SetTrigger("idle");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(blackboard.target != null)
		{
			return blackboard.attackSuperState;
		}

		return this;
	}
}
