using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UiAmmoCounter : MonoBehaviour
{

	FpsInventory inventory;
	Text uiText;
	int ammo = -1;


	void Start()
	{
		inventory = transform.root.GetComponentInChildren<FpsInventory>();
		uiText = GetComponent<Text>();
	}



	void FixedUpdate()
	{
		var currentWeaponSlot = inventory.weaponSlots.Where(s => s.weapon.gameObject.activeInHierarchy).FirstOrDefault();
		
		if(currentWeaponSlot != null)
		{
			if(currentWeaponSlot.weapon.ammo != ammo)
			{
				ammo = currentWeaponSlot.weapon.ammo;
				uiText.text = ammo.ToString();
			}
		}
		else
		{
			uiText.text = "--";
		}
	}
}
