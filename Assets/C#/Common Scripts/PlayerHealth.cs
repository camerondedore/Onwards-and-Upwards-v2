using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{




	
	public string HealthDisplay()
	{
		return hitPoints.ToString();
	}



	public override void Die()
	{
		// death here
		Debug.Log("Player is dead");
	}
}
