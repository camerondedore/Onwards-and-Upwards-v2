using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsHeadBob : MonoBehaviour
{

	[SerializeField]
	AnimationCurve xCurve,
		yCurve;
	[SerializeField]
	float cycleDistance;
	Vector3 oldPosition;
	float distance = 0;



	void Start()
	{
		oldPosition = transform.position;
	}



	void FixedUpdate()
	{
		distance += (transform.position - oldPosition).magnitude;

		if (distance >= cycleDistance)
		{
			distance -= cycleDistance;
		}
		
		var targetPosition = new Vector3(xCurve.Evaluate(distance), yCurve.Evaluate(distance), 0);
		transform.localPosition = targetPosition;		
		oldPosition = transform.position;
	}
}
