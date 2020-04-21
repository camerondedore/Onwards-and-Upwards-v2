using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerTrail : MonoBehaviour
{
    
	TrailRenderer trail;



    void Start()
    {
		// fixes trail bug
        trail = GetComponent<TrailRenderer>();
		trail.AddPosition(transform.position);
		trail.AddPosition(transform.position + transform.forward);
    }
}
