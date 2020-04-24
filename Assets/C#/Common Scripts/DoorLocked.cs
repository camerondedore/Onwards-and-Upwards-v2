using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorLocked : MonoBehaviour
{

	[SerializeField]
	AudioClip openSound,
		closeSound,
		lockedSound;
	[SerializeField]
	string pickupLog;
	Animator[] anims;
	AudioSourceController aud;
	NavMeshObstacle obstacle;
	List<Collider> colliders = new List<Collider>();
	bool open = false,
		locked = true;



	void Start()
	{
		anims = GetComponentsInChildren<Animator>();
		aud = GetComponent<AudioSourceController>();
		obstacle = GetComponentInChildren<NavMeshObstacle>();
	}



	void OnTriggerEnter(Collider co)
	{
		if(locked)
		{
			// enter log
			UiLog.Log(pickupLog);
			aud.PlayOneShot(lockedSound);
			return;
		}

		colliders.Add(co);

		if (!open)
		{
			open = true;
			aud.PlayOneShot(openSound);

			foreach (var anim in anims)
			{
				anim.SetTrigger("open");
			}
		}
	}



	void OnTriggerExit(Collider co)
	{
		if (locked)
		{
			return;
		}

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



	public void Unlock()
	{
		locked = false;
		obstacle.carving = false;
	}
}
