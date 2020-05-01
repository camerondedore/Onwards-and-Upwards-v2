using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavMeshInput : MonoBehaviour
{
    
	NavMeshCharacterController controller;



	void Start()
	{
		controller = transform.root.GetComponent<NavMeshCharacterController>();
	}



    void Update()
    {
		var moveDir = new Vector3(PlayerInput.move.x, 0, PlayerInput.move.y);
        controller.Move(moveDir, true);
        controller.Look(PlayerInput.look);
    }
}
