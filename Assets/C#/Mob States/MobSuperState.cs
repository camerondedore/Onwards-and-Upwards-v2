using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSuperState : SuperState
{

	protected MobBlackboard blackboard;



	protected virtual void Awake()
	{
		blackboard = GetComponent<MobBlackboard>();
	}
}