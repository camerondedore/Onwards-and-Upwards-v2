using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsHands : MonoBehaviour
{
    
	IWeapon[] weapons;
	FpsRecoil recoilCtrl;



    void Start()
    {
		weapons = GetComponentsInChildren<IWeapon>(true);
		recoilCtrl = transform.root.GetComponentInChildren<FpsRecoil>();
    }



	void Update()
	{
		if(Time.timeScale == 0 || Time.deltaTime == 0)
		{
			return;
		}

		foreach(var weapon in weapons)
		{
			if(weapon.IsEquipped())
			{
				weapon.PullTrigger(PlayerInput.fire);
			}
		}
	}
}
