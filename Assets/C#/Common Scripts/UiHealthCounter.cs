using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthCounter : MonoBehaviour
{

	PlayerHealth health;
	Text uiText;



	void Start()
	{
		health = transform.root.GetComponentInChildren<PlayerHealth>();
		uiText = GetComponent<Text>();
	}



	void FixedUpdate()
	{
		uiText.text = health.HealthDisplay();
	}
}
