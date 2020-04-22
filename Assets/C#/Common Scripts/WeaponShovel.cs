using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShovel : MonoBehaviour, IWeapon
{
	[SerializeField]
	float cycleTime = 0.1f;
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
		// sear checks
		var isCycleDone = autoSear.CanTrip();

		// cycle rate check
		if (isCycleDone && trigger > 0)
		{
			// auto
			TriggerActions();
			autoSear.Trip();
			return true;
		}

		// cannot fire
		return false;
	}



	public bool CanReload()
	{
		return false;
	}



	public void Reload(int amt)
	{
		return;
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
		return "--";
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
