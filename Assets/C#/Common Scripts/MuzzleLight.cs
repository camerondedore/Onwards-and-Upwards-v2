using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleLight : MonoBehaviour, IWeaponAction
{

	[SerializeField]
	float flashTime = 0.1f,
		randomIntensityRange = 0.1f;
	Light muzzleLight;
	float flashStartTime = -Mathf.Infinity,
		intensity;



	void Start()
	{
		muzzleLight = GetComponent<Light>();
		intensity = muzzleLight.intensity;
	}



	void FixedUpdate()
	{
		if(Time.time > flashStartTime + flashTime && muzzleLight.enabled)
		{
			// flash over
			muzzleLight.enabled = false;
		}
	}



	public void Fire()
	{
		muzzleLight.enabled = true;
		muzzleLight.intensity = intensity * (1 + Random.Range(-randomIntensityRange, randomIntensityRange));
		flashStartTime = Time.time;
	}
}
