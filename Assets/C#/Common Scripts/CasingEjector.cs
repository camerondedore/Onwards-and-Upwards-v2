using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingEjector : MonoBehaviour, IWeaponAction
{

	[SerializeField]
	GameObject casing;
	[SerializeField]
	Vector3 minVelocity,
		maxVelocity,
		minRotation,
		maxRotation;
	VelocityTracker tracker;



	void Start()
	{
		tracker = transform.root.GetComponent<VelocityTracker>();
	}



	public void Fire()
	{
		var c = Instantiate(casing, transform.position, transform.rotation);
		var rb = c.GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 100;

		var randomVelocity = new Vector3();
		randomVelocity.x = Random.Range(minVelocity.x, maxVelocity.x);
		randomVelocity.y = Random.Range(minVelocity.y, maxVelocity.y);
		randomVelocity.z = Random.Range(minVelocity.z, maxVelocity.z);

		var randomRotation = new Vector3();
		randomRotation.x = Random.Range(minRotation.x, maxRotation.x);
		randomRotation.y = Random.Range(minRotation.y, maxRotation.y);
		randomRotation.z = Random.Range(minRotation.z, maxRotation.z);

		rb.velocity = tracker.velocity + transform.TransformDirection(randomVelocity);
		rb.angularVelocity = transform.TransformDirection(randomRotation);
	}
}
