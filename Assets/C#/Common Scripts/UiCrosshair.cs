using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCrosshair : MonoBehaviour
{

	[SerializeField]
	UiCrosshairPart[] parts;
	Barrel barrel;
	float spread = -1;



	void Start()
	{
		barrel = transform.root.GetComponentInChildren<Barrel>();

		foreach (var t in parts)
		{
			t.startPosition = t.uiElement.localPosition;
		}
	}



    void FixedUpdate()
    {
		if(spread != barrel.GetSpread())
		{
        	spread = barrel.GetSpread();

			foreach(var t in parts)
			{
				t.uiElement.localPosition = t.startPosition + spread * t.movementAxis * t.movementMultiplier;
			}
		}
    }



	[System.Serializable]
	class UiCrosshairPart
	{
		public RectTransform uiElement;
		public Vector3 movementAxis;
		[HideInInspector]
		public Vector3 startPosition;
		public float movementMultiplier;
	}
}
