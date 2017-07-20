using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateEnemy : MonoBehaviour
{
	public GameObject enemy;
	public float horRange;
	public float vecRange;
	public float maxValue;

	public float frequencyOfGeneration = 1;

	private float updateCountDown = 0f;

	// Use this for initialization
	void Start()
	{
		this.updateCountDown = this.frequencyOfGeneration;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void FixedUpdate()
	{
		float scale = Random.value * this.maxValue;

		if (this.updateCountDown - 0 < 0.001)
		{
			GameObject enemyCopy = Instantiate<GameObject>(enemy);
			enemyCopy.tag = "enemy";
			SpriteRenderer enemyCopyRenderer = enemyCopy.GetComponent<SpriteRenderer>();
			enemyCopyRenderer.color = Random.ColorHSV();
			enemyCopy.transform.position = new Vector3(Random.Range(-horRange / 2, horRange / 2), Random.Range(-vecRange / 2, vecRange / 2), 0);
			enemyCopy.transform.localScale = new Vector3(scale, scale, 1);
			this.updateCountDown = 1f / (this.frequencyOfGeneration * Time.deltaTime);
		}
		else
		{
			this.updateCountDown -= 1;
		}
	}
}
