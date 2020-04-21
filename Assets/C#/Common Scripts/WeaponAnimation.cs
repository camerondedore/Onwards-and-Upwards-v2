using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour, IWeaponAction
{
	
	Animator anim;



	void OnEnable()
	{
		if(anim == null)
		{
			anim = GetComponent<Animator>();
		}

		anim.SetTrigger("equip");
	}



	public void Fire()
	{
		anim.SetTrigger("fire");
	}
}
