using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCameraController : MonoBehaviour
{
    
	[SerializeField] 
	float scale = 1000;
	[SerializeField]
	bool useFog = false;
	Transform mainCamera;
	Vector3 startPosition;
	float fogStart,
		fogEnd;



    void Awake()
    {
        mainCamera = Camera.main.transform;
		startPosition = transform.position;
		fogStart = RenderSettings.fogStartDistance;
		fogEnd = RenderSettings.fogEndDistance;
    }



    void LateUpdate()
    {
		// position
        transform.position = startPosition + mainCamera.position / scale;

		// rotation
		transform.rotation = mainCamera.rotation;
    }



	void OnPreRender()
	{
		if(useFog)
		{
			RenderSettings.fogStartDistance = fogStart / scale;
			RenderSettings.fogEndDistance = fogEnd / scale;
		}
	}



	void OnPostRender()
	{
		if (useFog)
		{
			RenderSettings.fogStartDistance = fogStart;
			RenderSettings.fogEndDistance = fogEnd;
		}
	}
}
