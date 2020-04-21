using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsHands : MonoBehaviour
{
    
	Weapon[] weapons;
	FpsRecoil recoilCtrl;



    void Start()
    {
		weapons = GetComponentsInChildren<Weapon>(true);
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
			if(weapon.gameObject.activeInHierarchy)
			{
				weapon.PullTrigger(PlayerInput.fire);
			}
		}
		// pull trigger
		// var willRecoil = weapon.PullTrigger(PlayerInput.fire);

		// reload
		// if (PlayerInput.reload > 0 && weapon.CanReload())
		// {
		// 	weapon.StartReload();
		// 	weapon.Reload();
		// }

		// recoil
		// if(willRecoil)
		// {
		// 	recoilCtrl.Recoil(weapon.recoilMagnitude);
		// }
	}
}
