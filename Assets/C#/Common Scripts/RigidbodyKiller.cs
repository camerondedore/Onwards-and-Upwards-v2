using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyKiller : MonoBehaviour
{
    
	Rigidbody rb;
	Collider co;
	float killThreshold = 0.1f,
		killTime = 5,
		startTime = 0;



	void Start()
	{
		rb = GetComponent<Rigidbody>();
		co = GetComponent<Collider>();
	}



	void FixedUpdate()
	{
		if(rb.isKinematic || !rb.useGravity)
		{
			return;
		}

		if(rb.velocity.sqrMagnitude < killThreshold)
		{
			if(startTime == 0)
			{
				startTime = Time.time;
			}

			if(Time.time > startTime + killTime)
			{
				Kill();
			}
		}
		else if(startTime != 0)
		{
			startTime = 0;
		}
	}



	void Kill()
	{
		Destroy(rb);
		Destroy(co);
		Destroy(this);
	}
}
