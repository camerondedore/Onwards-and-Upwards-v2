using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSuperStateAttack : MobSuperState
{





	public override State Transition()
	{
		if (blackboard.target == null)
		{
			// attack
			return blackboard.idleState;
		}


		return this;
	}
}
