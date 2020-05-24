using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshCharacterController : MonoBehaviour, IInitializeIntoBlackboard
{

	public static float lookSensitivity = 200;
	[HideInInspector]
	public NavMeshAgent agent;
	[SerializeField] 
	Transform head = null;
	[SerializeField] 
	bool normalize = false;
	[SerializeField]
	float lookLimit = 30,
		inertiaInverseMultiplier = 15;
	Vector3 moveVector,
		targetMoveVector;
	Vector2 lookAngles,
		lookVector;



	public string GetBlackboardKey()
	{
		return "Controller";
	}



	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		lookAngles = new Vector2(0, transform.localEulerAngles.y);
	}



	void FixedUpdate()
	{
		// apply look
		if(lookVector.sqrMagnitude > 0)
		{
			var change = lookVector * lookSensitivity * Time.fixedDeltaTime;
			lookAngles += change;
			lookAngles.x = Mathf.Clamp(lookAngles.x, -lookLimit, lookLimit);

			var headLocalEuler = head.localEulerAngles;
			headLocalEuler.x = lookAngles.x;

			var bodyLocalEuler = transform.localEulerAngles;
			bodyLocalEuler.y = lookAngles.y;

			head.localRotation = Quaternion.Euler(headLocalEuler);
			transform.localRotation = Quaternion.Euler(bodyLocalEuler);
		}


		// apply move
		if (normalize)
		{
			targetMoveVector.Normalize();
		}
		
		moveVector = Vector3.Lerp(moveVector, targetMoveVector, Time.fixedDeltaTime * inertiaInverseMultiplier);
		var direction = moveVector;
		
		agent.Move(direction * agent.speed * Time.fixedDeltaTime);
		Physics.SyncTransforms();
	}



	/// <summary>
	/// move agent on navmesh using agent speed
	/// </summary>
	public void Move(Vector3 direction, bool localSpace)
	{
		if(localSpace)
		{
			targetMoveVector = transform.TransformDirection(direction);
		}
		else
		{
			targetMoveVector = direction;
		}
	}



	/// <summary>
	/// move agent to point on navmesh
	/// </summary>
	public void MoveTo(Vector3 point, float speed)
	{
		agent.speed = speed;
		agent.SetDestination(point);
		Resume();
	}



	/// <summary>
	/// stop agent
	/// </summary>
	public void Stop()
	{
		agent.isStopped = true;
	}



	/// <summary>
	/// resume agent
	/// </summary>
	public void Resume()
	{
		agent.isStopped = false;
	}



	/// <summary>
	/// change look angles; x in head, y is body
	/// </summary>
	public void Look(Vector2 change)
	{
		lookVector = change;
	}



	/// <summary>
	/// look in direction
	/// </summary>
	public void LookAt(Vector3 direction)
	{
		var headDirection = Vector3.ProjectOnPlane(direction, head.right);
		var bodyDirection = Vector3.ProjectOnPlane(direction, transform.up);

		head.forward = headDirection;
		transform.forward = bodyDirection;
	}
}
