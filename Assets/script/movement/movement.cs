using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movement : MonoBehaviour
{
	public float speed;
	public Camera seeMe;
	public float initCameraSize;

	private float tanOfScaleAndCameraDistance;
	private float weight;
	private float maxDigestRate;
	// this.radius / (distance between camera and role)
	// Use this for initialization
	void Start()
	{
		this.initCameraSize = this.seeMe.orthographicSize;
		this.tanOfScaleAndCameraDistance = this.initCameraSize / this.transform.localScale.x;
		this.weight = Mathf.Pow(this.transform.localScale.x, 2);
		this.maxDigestRate = 1 / this.weight;
	}
	
	// Update is called once per frame
	void Update()
	{
		this.UpdateSpeed();
		this.UpdateLoc();

		this.UpdateCamera();
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		float r = other.transform.localScale.x;
		this.UpdateWeight(r);
		Destroy(other.gameObject, 0.1f);
	}

	void OnGUI()
	{
		GUILayout.TextArea(this.tanOfScaleAndCameraDistance.ToString());
		GUILayout.TextArea((this.transform.localScale.x / this.tanOfScaleAndCameraDistance).ToString());
		GUILayout.TextArea(this.seeMe.orthographicSize.ToString());
	}

	void UpdateWeight(float eatenRadius)
	{
		// weight = r * r
		this.weight += eatenRadius * UnityEngine.Random.Range(0.01f, 0.3f) * this.maxDigestRate;
		float newR = Mathf.Sqrt(this.weight) / 2;
		this.transform.localScale = new Vector3(this.transform.localScale.x + newR, this.transform.localScale.y + newR, 1f);
		this.maxDigestRate = 1 / this.weight;
	}

	void UpdateSpeed()
	{
		// speed = 1 / weight 
		this.speed = 1 / this.weight + 1;
	}

	void UpdateLoc()
	{
		var hor = Input.GetAxis("Horizontal");
		var vec = Input.GetAxis("Vertical");
		float horMove = this.speed * Time.deltaTime * hor;
		float vecMove = this.speed * Time.deltaTime * vec;
		this.transform.position = new Vector3(this.transform.position.x + horMove, this.transform.position.y + vecMove, this.transform.position.z);

	}

	void UpdateCamera()
	{
		this.seeMe.orthographicSize = this.transform.localScale.x * this.tanOfScaleAndCameraDistance;
		this.seeMe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.seeMe.transform.position.z);
	}
}
