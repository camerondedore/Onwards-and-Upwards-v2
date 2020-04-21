using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRagdollHealth : Health
{
    
	BreakingRagdollControl ragdollCtrl;
	RagdollRigidbodyKillerControl ragdollKiller;
	Faction[] factionLimbs;



	void Start()
	{
		ragdollCtrl = GetComponent<BreakingRagdollControl>();
		ragdollKiller = GetComponentInChildren<RagdollRigidbodyKillerControl>();
		factionLimbs = GetComponentsInChildren<Faction>();
	}



	public override void Die()
	{
		// delay here for animation later
		foreach(var fac in factionLimbs)
		{
			Destroy(fac);
		}
		

		ragdollCtrl.BreakDeadLimbs();
		ragdollCtrl.SetRagdoll(true);
		ragdollKiller.EnableKiller();
		Destroy(ragdollCtrl);
		Destroy(this);
	}
}
