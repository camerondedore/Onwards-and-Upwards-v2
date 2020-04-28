using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : Health
{

	[SerializeField]
	StateMachine machine;
	[SerializeField]
	MobBlackboard blackboard;



	public override void Die()
	{
		machine.SetState(blackboard.dieState);
	}
}
