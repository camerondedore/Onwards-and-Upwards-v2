using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDoorKey : MonoBehaviour, IPickup
{

	[SerializeField]
	DoorLocked door;
	[SerializeField]
	AudioClip pickupSound;
	[SerializeField]
	string pickupLog;



	void FixedUpdate()
	{
		transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
	}



	public void Pickup(Transform player)
	{		
		door.Unlock();
		// enter log
		UiLog.Log(pickupLog);
		AudioSource.PlayClipAtPoint(pickupSound, transform.position);
		Destroy(gameObject);
	}
}
