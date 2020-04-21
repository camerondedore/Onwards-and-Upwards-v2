using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAimAhead : MonoBehaviour
{
    
	[SerializeField] 
	Transform baseTransform;
	[SerializeField] 
	float mass,
		springConstant,
		dragConstant, 
		maxOffset = 10;
	Vector3 oldForward = Vector3.zero,
		fixedDeltaTimeChange = Vector3.zero,
		change = Vector3.zero,
		targetChange = Vector3.zero,
		springvelocity;



	void Start()
	{
		oldForward = baseTransform.forward;
	}



	void LateUpdate()
	{
		if (Time.timeScale == 0 || Time.fixedDeltaTime == 0)
		{
			return;
		}
		
		fixedDeltaTimeChange = baseTransform.forward - oldForward;

		change = baseTransform.InverseTransformDirection(fixedDeltaTimeChange) / Time.fixedDeltaTime;
		oldForward = baseTransform.forward;

		targetChange = SpringInterpolator.Sperp(targetChange, Vector3.ClampMagnitude(change, maxOffset), ref springvelocity, mass, springConstant, dragConstant, Time.fixedDeltaTime);

		//Debug.DrawRay(baseTransform.position + baseTransform.forward, targetChange);

		transform.localRotation = Quaternion.LookRotation(Vector3.forward + targetChange, Vector3.up);

	}
}
