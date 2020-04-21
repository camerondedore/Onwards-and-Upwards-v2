using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollRigidbodyKillerControl : MonoBehaviour
{

	RagdollRigidbodyKiller[] limbs;
	Rigidbody rb;
	float killCheckTime = 5,
		startTime = 0;
	bool kill = false;



	void Start()
	{
		limbs = GetComponentsInChildren<RagdollRigidbodyKiller>();
		rb = GetComponent<Rigidbody>();
	}



	void FixedUpdate()
	{
		if (!kill || rb.isKinematic || !rb.useGravity)
		{
			return;
		}

		if (Time.time > startTime + killCheckTime)
		{
			// are any limbs moving?
			foreach (var limb in limbs)
			{
				if(limb.IsMoving())
				{
					startTime = Time.time;
					return;
				}
			}

			// all limbs are still
			Kill();
		}		
	}



	void Kill()
	{
		foreach (var limb in limbs)
		{
			limb.Kill();
		}

		Destroy(this);
	}



	public void EnableKiller()
	{
		startTime = Time.time;
		kill = true;
	}
}
