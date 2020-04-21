using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsFeet : MonoBehaviour
{
    
	[SerializeField]
	AudioClip stepSound;
	[SerializeField]
	float stepDistance,
		randomPitchRange;
	AudioSourceController source;
	Vector3 oldPosition;
	float distance = 0;



	void Start()
	{
		source = GetComponent<AudioSourceController>();
		oldPosition = transform.position;
	}



	void FixedUpdate()
	{
		distance += (transform.position - oldPosition).magnitude;
		oldPosition = transform.position;

		if(distance > stepDistance)
		{
			distance = 0;
			source.RandomizePitch(randomPitchRange);
			source.PlayOneShot(stepSound);
		}
	}
}
