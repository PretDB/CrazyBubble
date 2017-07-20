using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{

	public Camera camera;
	public float distanceRate;

	// Use this for initialization
	void Start()
	{
		if (this.distanceRate - 0 < 0.1f)
		{
			this.distanceRate = this.transform.localScale.x / this.camera.orthographicSize;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		this.UpdateCamera();
	}

	void UpdateCamera()
	{
		this.camera.orthographicSize = this.transform.localScale.x / this.distanceRate;
		this.camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.camera.transform.position.z);
	}

}
