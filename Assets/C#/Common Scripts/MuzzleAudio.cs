using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleAudio : MonoBehaviour, IWeaponAction
{
    
	[SerializeField]
	AudioClip fireClip;
	[SerializeField]
	float randomPitchRange = 0.1f;
	AudioSourceController source;



    void Start()
    {
        source = GetComponent<AudioSourceController>();
    }



	public void Fire()
	{
		source.RandomizePitch(randomPitchRange);
		source.PlayOneShot(fireClip);
	}
}
