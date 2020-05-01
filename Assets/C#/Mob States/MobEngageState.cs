using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobEngageState : MobState
{

	[SerializeField]
	float burstTime = 1,
		gapTime = 1;
	Vector3 moveDir;
	float startTime;
	bool isShooting = false;



	public override void RunState()
	{
		// look in direction of mevement
		var lookDir = blackboard.target.transform.position - transform.root.position;
		lookDir.y = 0;
		blackboard.controller.LookAt(lookDir);

		// burst over?
		if(isShooting && Time.time > startTime + burstTime)
		{
			// stop shooting
			isShooting = false;
			startTime = Time.time;
		}

		// gap over?
		if (!isShooting && Time.time > startTime + gapTime)
		{
			// start shooting
			isShooting = true;
			startTime = Time.time;
		}

		// aim
		blackboard.eyes.forward = blackboard.target.transform.position - blackboard.eyes.position;

		// is shooting?
		if(isShooting && blackboard.weapon.PullTrigger(1))
		{
			// animate shooting
			blackboard.animator.SetTrigger("fire");
		}
	}



	public override void StartState()
	{
		blackboard.controller.agent.isStopped = true;
		startTime = -Mathf.Infinity;
		// get move direction
		moveDir = Random.onUnitSphere;
		moveDir.y = 0;
		blackboard.controller.Move(moveDir, false);
	}



	public override void EndState()
	{
		blackboard.animator.SetTrigger("attack");
		// stop movement
		blackboard.controller.Move(Vector3.zero, false);
	}



	public override State Transition()
	{
		// see target?
		if (!MobTools.CheckLOS(blackboard.eyes.position, blackboard.target.gameObject, blackboard.eyeMask))
		{
			// seek
			return blackboard.seekState;
		}

		return this;
	}
}
