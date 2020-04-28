using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateSeek : MobState
{

	[SerializeField]
	float gapTime = 3;
	float startTime = -Mathf.Infinity;



	public override void RunState()
	{
		// look
		transform.root.forward = Vector3.ProjectOnPlane(blackboard.target.transform.position - transform.root.position, Vector3.up);
	}



	public override void StartState()
	{
		blackboard.agent.destination = blackboard.target.transform.position;
		blackboard.animator.SetTrigger("attack");
		startTime = Time.time;
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if (Time.time > startTime + gapTime && NpcTools.CheckLOS(blackboard.eyes.position, blackboard.target.gameObject, blackboard.eyeMask))
		{
			// idle
			return blackboard.shootState;
		}


		return this;
	}
}
