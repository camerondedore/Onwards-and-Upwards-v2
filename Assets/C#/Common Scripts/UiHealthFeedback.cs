using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealthFeedback : MonoBehaviour
{

	Animator anim;
	HealthPlayer health;
	float lastHealth = -1;



	void Start()
	{
		health = transform.root.GetComponentInChildren<HealthPlayer>();
		anim = GetComponent<Animator>();
		lastHealth = health.hitPoints;
	}



	void Update()
	{
		if(Time.timeScale == 0)
		{
			return;
		}

		if(lastHealth > health.hitPoints)
		{
			lastHealth = health.hitPoints;
			anim.SetTrigger("hurt");	
		}
		
		if (lastHealth < health.hitPoints)
		{
			lastHealth = health.hitPoints;
			anim.SetTrigger("heal");
		}
	}
}
