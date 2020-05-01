using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttackSuperState : MobSuperState
{
    




	public override State Transition()
	{
		// have target?
		if(blackboard.target == null)
		{
			// idle
			return blackboard.idleState;
		}

		return this;
	}
}
