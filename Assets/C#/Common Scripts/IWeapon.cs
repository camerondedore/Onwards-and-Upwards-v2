using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
	bool IsEquipped();
	void Equip(bool isEquipped);
	bool PullTrigger(float trigger);
	bool CanReload();
	void Reload(int amt);
	string AmmoDisplay();
}

/// <summary>
/// Weapon actions such as muzzle flash and casing eject should implement this.
/// </summary>
public interface IWeaponAction
{
	void Fire();
}