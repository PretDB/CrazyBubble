using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
	public float speed;
	public Camera seeMe;
	public float initCameraDistance = 10;

	private float rate;
	// this.radius / (distance between camera and role)
	// Use this for initialization
	void Start()
	{
		this.rate = Mathf.Atan(this.transform.localScale.x / this.initCameraDistance);
	}
	
	// Update is called once per frame
	void Update()
	{
		this.UpdateLoc();

		this.UpdateCamera();
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
		this.seeMe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -this.transform.localScale.x / this.rate);
	}
}
