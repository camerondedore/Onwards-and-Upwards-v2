using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobState : State
{

	protected MobBlackboard blackboard;



	protected virtual void Awake()
	{
		blackboard = GetComponent<MobBlackboard>();
	}



   	// public override void RunState()
	// {

	// }



	// public override void StartState()
	// {

	// }



	// public override void EndState()
	// {

	// }



	// public override State Transition()
	// {
	// 	return this;
	// }
}
