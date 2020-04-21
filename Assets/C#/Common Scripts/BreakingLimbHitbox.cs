using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingLimbHitbox : Hitbox
{

	[HideInInspector]
	public Rigidbody rb;
	[SerializeField]
	GameObject breakFx;
	[SerializeField]
	Vector3 breakFxDirection;
	[SerializeField]
	float hitPoints = 100;
	BreakingLimbHitbox[] childHitboxes;
	Joint joint;
	Transform parent;



	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		joint = GetComponent<Joint>();
		childHitboxes = GetComponentsInChildren<BreakingLimbHitbox>();
		parent = transform.parent;
	}



	public void SetRigid(bool isRigid)
	{
		if (rb != null)
		{
			rb.isKinematic = !isRigid;
			rb.useGravity = isRigid;
		}
	}



	public override void Hit(float damage)
	{
		hitPoints = Mathf.Clamp(hitPoints - damage * weakness, 0, Mathf.Infinity);
		
		if(baseHealth != null)
		{
			// damage base
			baseHealth.Damage(damage * weakness);
		}
		else if(hitPoints == 0)
		{
			BreakJoint(false);
		}
	}



	public void BreakJoint(bool dying)
	{
		if (hitPoints == 0)
		{
			SetRigid(true);
			foreach (var hitbox in childHitboxes)
			{
				hitbox.SetRigid(true);
			}

			if(dying && breakFx != null)
			{
				// fx
				Instantiate(breakFx, 
					transform.position, 
					Quaternion.LookRotation(parent.TransformDirection(breakFxDirection)), 
					parent);
			}

			Destroy(joint);
			transform.parent = null;
			Destroy(this);
		}
	}
}
