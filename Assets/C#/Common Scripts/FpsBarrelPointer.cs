using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsBarrelPointer : MonoBehaviour
{
    
	[SerializeField]
	LayerMask mask;
	[SerializeField]
	float range = 10;	
	Barrel[] barrels;
	RaycastHit hit;


    void Start()
    {
        barrels = transform.root.GetComponentsInChildren<Barrel>(true);
    }

    

    void FixedUpdate()
    {
		if(Physics.Raycast(transform.position, transform.forward, out hit, range, mask))
		{
			foreach(var barrel in barrels)
			{
				if(barrel.gameObject.activeInHierarchy)
				{
					var target = hit.point - barrel.transform.position;
					barrel.SetForward(target);
				}
			}
		}
		else
		{
			foreach (var barrel in barrels)
			{
				if (barrel.gameObject.activeInHierarchy)
				{
					barrel.SetForward(transform.forward);
				}
			}
		}
    }
}
