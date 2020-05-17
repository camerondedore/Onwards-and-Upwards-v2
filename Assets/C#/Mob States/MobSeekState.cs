using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSeekState : MobState
{

	float timeToUpdateDestination = 5,
		startTime;



	public override void RunState()
	{
		// look in direction of movement
		var lookDir = blackboard.controller.agent.velocity;
		lookDir.y = 0;
		
		if(lookDir.sqrMagnitude > 0.05f)
		{
			blackboard.controller.LookAt(lookDir);
		}

		// update destination
		if(Time.time > startTime + timeToUpdateDestination)
		{
			// move to see target
			blackboard.controller.MoveTo(blackboard.target.transform.position, blackboard.controller.agent.speed);
			startTime = Time.time;
		}
	}



	public override void StartState()
	{
		blackboard.controller.agent.isStopped = false;
		blackboard.animator.SetTrigger("attack");
		// move to see target
		blackboard.controller.MoveTo(blackboard.target.transform.position, blackboard.controller.agent.speed);
		startTime = Time.time;
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		// see target?
		if(MobTools.CheckLOS(blackboard.eyes.position, blackboard.target.gameObject, blackboard.eyeMask))
		{
			// engage
			return blackboard.engageState;
		}

		// out of range?
		if(!MobTools.CheckDistance(blackboard.eyes.position, blackboard.target.transform.position, blackboard.seekRange))
		{
			// idle
			return blackboard.idleState;
		}

		return this;
	}
}
