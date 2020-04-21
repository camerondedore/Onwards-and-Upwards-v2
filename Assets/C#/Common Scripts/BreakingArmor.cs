using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingArmor : BreakingObject
{
    
	[SerializeField]
	GameObject breakFx;
	[SerializeField]
	AudioClip breakSound;
	[SerializeField]
	Vector3 minBreakVelocity,
		maxBreakVelocity,
		minBreakRotation,
		maxBreakRotation;
	[SerializeField]
	float randomPitchRadius = 0.1f;
	Rigidbody rb;
	AudioSourceController source;
	int brokenLayer = 8;



	void Start()
	{
		rb = GetComponent<Rigidbody>();
		source = transform.GetComponent<AudioSourceController>();
	}



	protected override void Break()
	{
		transform.parent = null;
		rb.isKinematic = false;
		rb.useGravity = true;
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
		gameObject.layer = brokenLayer;
		StartCoroutine(ApplyBreakMovement());

		if(source != null)
		{
			source.RandomizePitch(randomPitchRadius);
			source.PlayOneShot(breakSound);
		}

		Destroy(this);
	}



	IEnumerator ApplyBreakMovement()
	{
		yield return new WaitForFixedUpdate();

		var randomVelocity = new Vector3();
		randomVelocity.x = Random.Range(minBreakVelocity.x, maxBreakVelocity.x);
		randomVelocity.y = Random.Range(minBreakVelocity.y, maxBreakVelocity.y);
		randomVelocity.z = Random.Range(minBreakVelocity.z, maxBreakVelocity.z);

		var randomRotation = new Vector3();
		randomRotation.x = Random.Range(minBreakRotation.x, maxBreakRotation.x);
		randomRotation.y = Random.Range(minBreakRotation.y, maxBreakRotation.y);
		randomRotation.z = Random.Range(minBreakRotation.z, maxBreakRotation.z);

		randomVelocity = transform.TransformDirection(randomVelocity);
		randomRotation = transform.TransformDirection(randomRotation);

		rb.velocity = rb.velocity * 0.1f + randomVelocity;
		rb.angularVelocity += randomRotation;

		if (breakFx != null)
		{
			Instantiate(breakFx, transform.position, Quaternion.LookRotation(randomVelocity, transform.up));
		}
	}
}
