using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
	[SerializeField]
	AudioClip openSound,
		closeSound;
	Animator[] anims;
	AudioSourceController aud;
	List<Collider> colliders = new List<Collider>();
	bool open = false;



    void Start()
    {
        anims = GetComponentsInChildren<Animator>();
		aud = GetComponent<AudioSourceController>();
    }

    

	void OnTriggerEnter(Collider co)
	{
		colliders.Add(co);

		if(!open)
		{
			open = true;
			aud.PlayOneShot(openSound);
			
			foreach(var anim in anims)
			{
				anim.SetTrigger("open");
			}
		}
	}



	void OnTriggerExit(Collider co)
	{
		colliders.Remove(co);

		if (colliders.Count == 0 && open)
		{
			open = false;
			aud.PlayOneShot(closeSound);

			foreach (var anim in anims)
			{
				anim.SetTrigger("close");
			}
		}
	}
}
