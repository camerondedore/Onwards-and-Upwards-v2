using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateShoot : MobState
{

	[SerializeField]
	float burstTime = 1;
	float startTime = -Mathf.Infinity;



	public override void RunState()
	{
		// shoot
		blackboard.weapon.PullTrigger(1);
		// aim
		blackboard.barrelPointer.forward = blackboard.target.transform.position - blackboard.barrelPointer.position;
		// look
		transform.root.forward = Vector3.ProjectOnPlane(blackboard.target.transform.position - transform.root.position, Vector3.up);
	}



	public override void StartState()
	{
		startTime = Time.time;
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if (Time.time > startTime + burstTime)
		{
			// idle
			return blackboard.seekState;
		}


		return this;
	}
}