using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBlackboard : MonoBehaviour
{

	public State idleState;
	public State seekState;
	public State engageState;
	public State dieState;
	public NavMeshCharacterController controller;
	public Animator animator;
	public Faction myFaction;
	public IWeapon weapon;
	public Transform barrelPointer;
	public Transform eyes;
	public LayerMask eyeMask;
	public Faction target;
	public MobDrop dropper;
	public float seekRange;



	void Awake()
	{
		weapon = transform.root.GetComponentInChildren<IWeapon>();
	}
}
