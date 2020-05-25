using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretArea : MonoBehaviour
{
    
	[SerializeField] AudioClip secretSound;
	string message = "Secret Area found";



	void OnTriggerEnter()
	{
		// enter log
		UiLog.Log(message);
		AudioSource.PlayClipAtPoint(secretSound, transform.position);
		Destroy(gameObject);
	}
}
