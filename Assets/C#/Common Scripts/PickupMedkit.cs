using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMedkit : MonoBehaviour, IPickup
{

	[SerializeField]
	AudioClip pickupSound;
	[SerializeField]
	string pickupLog;
	[SerializeField]
	int hitPoints = 25;



	void FixedUpdate()
	{
		transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
	}



	public void Pickup(Transform player)
	{
		var health = player.GetComponentInChildren<Health>();

		if (health.CanHeal())
		{
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			// give hit points
			health.Heal(hitPoints);
			// enter log
			UiLog.Log(pickupLog);
			Destroy(gameObject);
		}
	}
}
