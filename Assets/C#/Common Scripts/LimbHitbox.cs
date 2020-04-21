using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbHitbox : Hitbox
{

	[HideInInspector]
	public Rigidbody rb;



	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}



	public void SetRigid(bool isRigid)
	{
		if (rb != null)
		{
			rb.isKinematic = !isRigid;
			rb.useGravity = isRigid;
		}
	}
}
