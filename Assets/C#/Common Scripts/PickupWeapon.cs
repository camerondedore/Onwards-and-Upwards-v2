using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickupWeapon : MonoBehaviour, IPickup
{

	[SerializeField]
	AudioClip pickupSound;
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
		var weaponSlot = inventory.weaponSlots.Where(s => s.slot == slot).First();

		if(weaponSlot.weapon.CanReload() || !weaponSlot.obtained)
		{
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			weaponSlot.obtained = true;
			weaponSlot.weapon.Reload(ammo);
			Destroy(gameObject);
		}
	}
}
