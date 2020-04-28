using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : MonoBehaviour, IWeapon
{
	
	public int ammo;
	[SerializeField]
	float cycleTime = 0.1f;
	[SerializeField]
	int magazineCapacity = 30;
	IWeaponAction[] actions;
	TimedDisconnector autoSear = new TimedDisconnector();



	void Start()
	{
		// set up auto sear
		autoSear.releaseTime = cycleTime;
		// get child actions
		actions = GetComponentsInChildren<IWeaponAction>();
	}



	public bool PullTrigger(float trigger)
	{
		if (ammo == 0)
		{
			return false;
		}

		// sear checks
		var isCycleDone = autoSear.CanTrip();

		// cycle rate check
		if (isCycleDone && trigger > 0)
		{
			// auto
			TriggerActions();
			autoSear.Trip();
			ammo = Mathf.Clamp(ammo - 1, 0, magazineCapacity);
			return true;
		}

		// cannot fire
		return false;
	}



	public bool CanReload()
	{
		return ammo < magazineCapacity;
	}



	public bool IsEmpty()
	{
		return ammo == 0;
	}



	public void Reload(int amt)
	{
		ammo = Mathf.Clamp(ammo + amt, 0, magazineCapacity);
	}



	void TriggerActions()
	{
		foreach (var a in actions)
		{
			a.Fire();
		}
	}



	public string AmmoDisplay()
	{
		return ammo.ToString();
	}



	public bool IsEquipped()
	{
		return gameObject.activeInHierarchy;
	}



	public void Equip(bool isEquipped)
	{
		gameObject.SetActive(isEquipped);
	}
}
