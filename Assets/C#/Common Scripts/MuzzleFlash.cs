using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour, IWeaponAction
{

	[SerializeField]
	int frameCount = 4,
		rowCount = 1;
	[SerializeField]
	float timePerFrame = 0.02f,
		randomSizeRange = 0.1f;
	[SerializeField]
	bool rotate = false;
	Renderer rend;
	Vector3 scale;
	float frameProportion,
		rowProportion,
		lastFrameTime = -Mathf.Infinity;
	int currentFrame,
		currentRow = 0;



	void Start()
	{
		rend = GetComponent<Renderer>();
		frameProportion = 1f / frameCount;
		rowProportion = 1f / rowCount;
		currentFrame = frameCount;
		rend.enabled = false;
		scale = transform.localScale;
	}



	void FixedUpdate()
	{
		if(Time.time > lastFrameTime + timePerFrame)
		{
			if(currentFrame < frameCount)
			{
				UpdateUV(); 
				currentFrame++;
				lastFrameTime = Time.time;
			}
			else if(rend.enabled)
			{
				rend.enabled = false;
			}
		}
	}



	public void Fire()
	{
		// restart animation
		currentFrame = 0;
		currentRow = Random.Range(0, rowCount);
		lastFrameTime = -Mathf.Infinity;
		if (!rend.enabled)
		{
			UpdateUV();
			rend.enabled = true;
		}
		RandomizeTransform();
	}



	void UpdateUV()
	{
		var offset = new Vector2(currentFrame * frameProportion, currentRow * rowProportion);
		rend.material.SetTextureOffset("_MainTex", offset);
	}



	void RandomizeTransform()
	{
		if(rotate)
		{
			var randomRotation = new Vector3(0, 0, Random.Range(0f, 359f));
			transform.localRotation = Quaternion.Euler(randomRotation);
		}
		
		var randomXYScale = 1 - Random.Range(-randomSizeRange, randomSizeRange);
		var randomZScale = 1 - Random.Range(-randomSizeRange, randomSizeRange);
		var randomScale = new Vector3(scale.x * randomXYScale, scale.y * randomXYScale, scale.z * randomZScale);
		transform.localScale = randomScale;
	}
}
