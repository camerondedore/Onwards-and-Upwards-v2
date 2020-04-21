using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsRecoil : MonoBehaviour
{
    
	[SerializeField]
	Vector3 minRecoil,
		maxRecoil;
	[SerializeField]
	float maxRecoilMagnitude = 2,
		recoverSpeed = 5,
		mass,
		springConstant,
		dragConstant,
		randomVariationRange = 0.5f;
	Vector3 targetAngles,
		angles,
		springVelocity;



    void Start()
    {
        
    }

    

    void FixedUpdate()
    {
		angles = SpringInterpolator.Sperp(angles, targetAngles, ref springVelocity, mass, springConstant, dragConstant, Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(angles);

		// recover
		targetAngles = Vector3.Slerp(targetAngles, Vector3.zero, Time.fixedDeltaTime * recoverSpeed);
    }



	public void Recoil(float multiplier)
	{
		var randomX = -Random.Range(minRecoil.x, maxRecoil.x);
		var randomY = Random.Range(minRecoil.y, maxRecoil.y);
		var randomZ = Random.Range(minRecoil.z, maxRecoil.z);
		var randomRecoil = new Vector3(randomX, randomY, randomZ) * multiplier;
		targetAngles = Vector3.ClampMagnitude(targetAngles + randomRecoil, maxRecoilMagnitude);
	}
}
