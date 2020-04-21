using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollRigidbodyKiller : MonoBehaviour
{

	Rigidbody rb;
	Collider co;
	Joint jo;
	float killThreshold = 0.1f,
		killTime = 5,
		startTime = 0;



	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		co = GetComponent<Collider>();
		jo = GetComponent<Joint>();
	}



	public bool IsMoving()
	{
		return rb.velocity.sqrMagnitude > killThreshold;
	}



	public void Kill()
	{
		Destroy(jo);
		Destroy(rb);
		Destroy(co);
		Destroy(this);
	}
}
