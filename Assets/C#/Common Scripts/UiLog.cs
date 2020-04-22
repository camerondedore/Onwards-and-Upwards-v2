using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLog : MonoBehaviour
{
    
	public static Text text;
	static string log = "";
	[SerializeField]
	float clearTime = 10;
	static float lastLoggedTime = -Mathf.Infinity;



	void Start()
	{
		text = GetComponent<Text>();
		text.text = log;
	}



	void Update()
	{
		// clear log
		if(Time.time > lastLoggedTime + clearTime)
		{
			log = "";
			text.text = log;
		}
	}



	public static void Log(string entry)
	{
		// update log
		log = entry + "\n" + log;
		log = log.Substring(0, Mathf.Clamp(296, 0, log.Length - 1));		
		text.text = log;
		lastLoggedTime = Time.time;
	}
}
