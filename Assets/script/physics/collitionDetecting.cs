using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collitionDetecting : MonoBehaviour
{
	public Rigidbody2D ri;
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		float r = other.transform.localScale.x;
		this.transform.localScale = new Vector3(this.transform.localScale.x + r, this.transform.localScale.y + r, 1);
		Destroy(other.gameObject, 0.1f);
	}

	void OnTriggerStay2D(Collider2D other)
	{
	}
}
