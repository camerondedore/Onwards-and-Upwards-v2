using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObject : MonoBehaviour, IDamageable
{
    
	[SerializeField]
	float hitPoints = 100;



	public void Hit(float damage)
	{
		if(hitPoints <= 0)
		{
			return;
		}

		hitPoints = Mathf.Clamp(hitPoints - damage, 0, Mathf.Infinity);

		if(hitPoints <= 0)
		{
			Break();
		}
	}



	protected virtual void Break()
	{
		//////////////////////////////////////////////////////////////
		// for child classes, like armor, override the Break method.
		//////////////////////////////////////////////////////////////
		Destroy(gameObject);
	}
}
