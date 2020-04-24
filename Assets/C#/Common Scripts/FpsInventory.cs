using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FpsInventory : MonoBehaviour
{

	[System.Serializable]
	public class WeaponSlot
	{
		public GameObject weapon;
		public IWeapon weaponInterface;
		public int slot;
		public bool obtained;
		public AudioClip equipSound;
	}

	public WeaponSlot[] weaponSlots;
	[SerializeField]
	int currentSlot;
	AudioSourceController aud;



	void Awake()
	{
		foreach(var slot in weaponSlots)
		{
			slot.weaponInterface = slot.weapon.GetComponent<IWeapon>();
		}
	}



	void Start()
	{
		aud = GetComponent<AudioSourceController>();
		SwitchTo(currentSlot);
	}



	void Update()
	{
		if(Time.timeScale == 0 || (PlayerInput.weapon1 + PlayerInput.weapon2 + PlayerInput.weapon3 > 1))
		{
			return;
		}

		if(PlayerInput.weapon1 > 0 && currentSlot != 1)
		{
			SwitchTo(1);
		}
		else if (PlayerInput.weapon2 > 0 && currentSlot != 2)
		{
			SwitchTo(2);
		}
		else if (PlayerInput.weapon3 > 0 && currentSlot != 3)
		{
			SwitchTo(3);
		}
	}



	void SwitchTo(int slotNumber)
	{
		var slotToSwitchTo = GetSlot(slotNumber);
		
		if(!slotToSwitchTo.obtained)
		{
			// weapon is not yet obtained, don't switch
			return;
		}

		currentSlot = slotNumber;

		// enable weapon
		slotToSwitchTo.weaponInterface.Equip(true);
		aud.PlayOneShot(slotToSwitchTo.equipSound);

		// disable other weapons
		foreach(var weaponSlot in weaponSlots)
		{
			if(weaponSlot.slot != slotNumber)
			{
				weaponSlot.weaponInterface.Equip(false);
			}
		}
	}



	public void Obtained(int slotNumber)
	{
		// obtain new weapon
		var slotToSwitchTo = GetSlot(slotNumber);
		slotToSwitchTo.obtained = true;
		// auto switch to new weapon
		SwitchTo(slotNumber);
	}



	public WeaponSlot GetSlot(int slotNumber)
	{
		return weaponSlots.Where(s => s.slot == slotNumber).First();
	}
}
