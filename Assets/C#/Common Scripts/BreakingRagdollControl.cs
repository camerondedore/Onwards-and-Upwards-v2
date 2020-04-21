using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRagdollControl : MonoBehaviour
{
   
	[SerializeField]
	bool startLimp = false;
	BreakingLimbHitbox[] hitboxes;



    void Start()
    {
		hitboxes = transform.root.GetComponentsInChildren<BreakingLimbHitbox>();
		SetRagdoll(startLimp);
    }

    

    public void SetRagdoll(bool isLimp)
    {
		foreach (var hitbox in hitboxes)
		{
			hitbox.SetRigid(isLimp);
		}
    }



	public void BreakDeadLimbs()
	{
		foreach (var hitbox in hitboxes)
		{
			hitbox.BreakJoint(true);
		}
	}
}
