using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickupWeapon : MonoBehaviour, IPickup
{

	[SerializeField]
	AudioClip pickupSound;
	[SerializeField]
	string pickupLog;
	[SerializeField]
	int ammo = 30,
		slot;



    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
    }



	public void Pickup(Transform player)
	{
		var inventory = player.GetComponentInChildren<FpsInventory>();
		var weaponSlot = inventory.GetSlot(slot);

		if(weaponSlot.weaponInterface.CanReload() || !weaponSlot.obtained)
		{
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			// obtain new weapon
			inventory.Obtained(slot);
			// give ammo
			weaponSlot.weaponInterface.Reload(ammo);
			// enter log
			UiLog.Log(pickupLog);
			Destroy(gameObject);
		}
	}
}
