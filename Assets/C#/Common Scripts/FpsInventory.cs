using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FpsInventory : MonoBehaviour
{

	[System.Serializable]
	public class WeaponSlot
	{
		public Weapon weapon;
		public int slot;
		public bool obtained;
		public AudioClip equipSound;
	}

	public WeaponSlot[] weaponSlots;
	AudioSourceController aud;
	int currentSlot;



	void Start()
	{
		aud = GetComponent<AudioSourceController>();
	}



	void Update()
	{
		if(PlayerInput.weapon1 > 0 && currentSlot != 1)
		{
			SwitchTo(1);
		}
		else if (PlayerInput.weapon2 > 0 && currentSlot != 2)
		{
			SwitchTo(2);
		}
	}



	void SwitchTo(int slotNumber)
	{
		currentSlot = slotNumber;
		var slotToSwitchTo = weaponSlots.Where(s => s.slot == slotNumber).First();
		
		if(!slotToSwitchTo.obtained)
		{
			// weapon is not yet obtained, don't switch
			return;
		}

		// enable weapon
		slotToSwitchTo.weapon.gameObject.SetActive(true);
		aud.PlayOneShot(slotToSwitchTo.equipSound);

		// disable other weapons
		foreach(var weaponSlot in weaponSlots)
		{
			if(weaponSlot.slot != slotNumber)
			{
				weaponSlot.weapon.gameObject.SetActive(false);
			}
		}
	}
}
