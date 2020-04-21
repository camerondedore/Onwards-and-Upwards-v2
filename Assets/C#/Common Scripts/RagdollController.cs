using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{

	[SerializeField]
	bool startLimp = false;
	LimbHitbox[] hitboxes;



	void Start()
	{
		hitboxes = transform.root.GetComponentsInChildren<LimbHitbox>();
		SetRagdoll(startLimp);
	}



	public void SetRagdoll(bool isLimp)
	{
		foreach (var hitbox in hitboxes)
		{
			hitbox.SetRigid(isLimp);
		}
	}
}
