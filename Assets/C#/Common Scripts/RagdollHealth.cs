using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHealth : Health
{

	RagdollController ragdollCtrl;
	RagdollRigidbodyKillerControl ragdollKiller;
	Faction[] factionLimbs;



	void Start()
	{
		ragdollCtrl = GetComponent<RagdollController>();
		ragdollKiller = GetComponentInChildren<RagdollRigidbodyKillerControl>();
		factionLimbs = GetComponentsInChildren<Faction>();
	}



	public override void Die()
	{
		// delay here for animation later
		foreach (var fac in factionLimbs)
		{
			Destroy(fac);
		}

		ragdollCtrl.SetRagdoll(true);
		ragdollKiller.EnableKiller();
		Destroy(ragdollCtrl);
		Destroy(this);
	}
}
