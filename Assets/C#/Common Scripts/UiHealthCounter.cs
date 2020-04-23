using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthCounter : MonoBehaviour
{

	HealthPlayer health;
	Text uiText;



	void Start()
	{
		health = transform.root.GetComponentInChildren<HealthPlayer>();
		uiText = GetComponent<Text>();
	}



	void FixedUpdate()
	{
		uiText.text = health.HealthDisplay();
	}
}
