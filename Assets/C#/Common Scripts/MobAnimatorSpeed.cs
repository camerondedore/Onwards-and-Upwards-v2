using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAnimatorSpeed : MonoBehaviour
{
    
	[SerializeField]
	float speedNormal = 2;
	VelocityTracker tracker;
	Animator anim;


	void Start()
	{
		tracker = GetComponent<VelocityTracker>();
		anim = GetComponent<Animator>();
	}



	void FixedUpdate()
	{
		anim.SetFloat("speed", tracker.speed / speedNormal);
	}
}
