using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCollision : MonoBehaviour
{
    
	[SerializeField]
	AudioClip collisionSound;
	[SerializeField]
	GameObject collisionFx;
	[SerializeField]
	float minHitSpeed,
		normalizedHitSpeed;
	Rigidbody rb;
	AudioSourceController source;
	float minTime = 0.5f,
		lastCollisiontime = -Mathf.Infinity;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSourceController>();
    }



	void OnCollisionEnter(Collision co)
	{
		if(Time.time < lastCollisiontime + minTime)
		{
			return;
		}

		lastCollisiontime = Time.time;
		var relativeSpeed = co.relativeVelocity.magnitude;
		
		if(relativeSpeed > minHitSpeed)
		{	
			if(source != null && collisionSound != null)
			{
				// sound
				source.source.volume = relativeSpeed / normalizedHitSpeed;
				source.PlayOneShot(collisionSound);
			}

			if(collisionFx != null)
			{
				// fx
				var contact = co.contacts[0];
				Instantiate(collisionFx, contact.point, Quaternion.LookRotation(contact.normal, transform.up));
			}
		}
	}
}
