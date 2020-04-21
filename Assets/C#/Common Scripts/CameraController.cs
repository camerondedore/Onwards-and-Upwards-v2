using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField]
	Transform cameraPoint;
	[SerializeField]
	LayerMask mask;
	[SerializeField]
	float speed = 10;
	VelocityTracker velocityTracker;
	Camera mainCamera;
	RaycastHit cameraHit;
	Vector3 positionDirection,
		lookDirection,
		targetPostion;
	float range;



	void Start()
	{
		mainCamera = Camera.main;
		targetPostion = cameraPoint.position;
		positionDirection = transform.InverseTransformDirection(cameraPoint.position - transform.position);
		lookDirection = transform.InverseTransformDirection(cameraPoint.forward);
		range = positionDirection.magnitude;
		velocityTracker = transform.root.GetComponent<VelocityTracker>();
	}



	void LateUpdate()
	{
		Physics.Raycast(transform.position, transform.TransformDirection(positionDirection), out cameraHit, range, mask);

		var collider = cameraHit.collider;

		if (collider != null)
		{
			targetPostion = cameraHit.point - transform.TransformDirection(positionDirection).normalized * 0.1f;
		}
		else
		{
			targetPostion = transform.TransformDirection(positionDirection) + transform.position;
		}

		MoveCamera();
	}



	void MoveCamera()
	{
	
		// apply new position
		mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPostion, Time.deltaTime * speed);

		// apply new rotation
		mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.LookRotation(transform.TransformDirection(lookDirection)), Time.fixedDeltaTime * speed);
		//mainCamera.transform.rotation = Quaternion.LookRotation(transform.TransformDirection(lookDirection));
	}
}
