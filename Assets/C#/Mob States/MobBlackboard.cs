using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBlackboard : MonoBehaviour
{

	public State idleState;
	public State attackSuperState;
	public State seekState;
	public State shootState;
	public State dieState;
	public NavMeshAgent agent;
	public Animator animator;
	public Faction myFaction;
	public IWeapon weapon;
	public Transform barrelPointer;
	public Transform eyes;
	public LayerMask eyeMask;
	public Faction target;



	void Awake()
	{
		weapon = transform.root.GetComponentInChildren<IWeapon>();
	}
}
