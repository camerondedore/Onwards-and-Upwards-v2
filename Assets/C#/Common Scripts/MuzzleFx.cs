using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFx : MonoBehaviour, IWeaponAction
{
    
	ParticleSystem emitter;



    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
    }



	public void Fire()
	{
		emitter.Play();
	}
}
