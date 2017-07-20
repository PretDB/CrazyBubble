using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor.SceneManagement;

public class physic : MonoBehaviour
{

	public float weight
	{
		get
		{
			return this.radius * this.radius;
		}
		set
		{
			this.radius = Mathf.Sqrt(value);
		}
	}

	public float speed = 5;
	public float initMaxRadius = 10;
	public Vector3 currentSpeedVector;
	public geometryLimit geoLimit;

	private float radius;

	// Use this for initialization
	void Start()
	{
		if (this.radius - 0 < 0.1)
		{
			this.radius = UnityEngine.Random.value * this.initMaxRadius;
		}
		this.currentSpeedVector = Vector3.zero;
		this.geoLimit = this.GetComponent<geometryLimit>();
	}
	
	// Update is called once per frame
	void Update()
	{
		this.Move();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		this.OnCrash(other);
	}

	void OnCrash(Collider2D other)
	{
		if (this.weight > other.GetComponent<physic>().weight)
		{
			this.UpdateWeight(other);
			Destroy(other);
		}
	}

	void UpdateWeight(Collider2D food)
	{
		// weight = r * r
		this.weight += food.GetComponent<physic>().weight * UnityEngine.Random.value;
		this.UpdateSize(this.radius);

	}

	void UpdateSize(float radius)
	{
		this.transform.localScale = new Vector3(this.transform.localScale.x + radius, this.transform.localScale.y + radius, 1f);
	}

	void UpdateSpeed()
	{
		// speed = 1 / weight 
		this.speed = 1 / this.weight + 1;
	}

	public void UpdateCurrentSpeedVector(Vector3 direction)
	{
		this.currentSpeedVector = this.speed * direction.normalized;
	}

	public void Move()
	{
		//this.currentSpeedVector = this.geoLimit.CutSpeedVector(this.currentSpeedVector);
		this.transform.position += this.currentSpeedVector * Time.deltaTime;
	}
}
