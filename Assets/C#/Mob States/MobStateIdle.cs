using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateIdle : MobState
{





	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.agent.destination = transform.position;
		blackboard.animator.SetTrigger("idle");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		// check for target
		blackboard.target = NpcTools.GetClosestEnemy(blackboard.myFaction, blackboard.eyes.position, blackboard.eyeMask);

		if(blackboard.target != null)
		{
			// attack
			return blackboard.attackSuperState;
		}


		return this;
	}
}
