using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UiAmmoCounter : MonoBehaviour
{

	FpsInventory inventory;
	Text uiText;



	void Start()
	{
		inventory = transform.root.GetComponentInChildren<FpsInventory>();
		uiText = GetComponent<Text>();
	}



	void FixedUpdate()
	{
		var currentWeaponSlot = inventory.weaponSlots.Where(s => s.weaponInterface.IsEquipped()).FirstOrDefault();
		
		if(currentWeaponSlot != null)
		{
			uiText.text = currentWeaponSlot.weaponInterface.AmmoDisplay();
		}
		else
		{
			uiText.text = "--";
		}
	}
}
