using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDrop : MonoBehaviour
{
    
	public GameObject drop;



	public void Drop()
	{
		Instantiate(drop, transform.position, transform.rotation);
	}
}
