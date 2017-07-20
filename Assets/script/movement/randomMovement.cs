using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour
{
	// Speed
	public float basicSpeed;
	public float maxSpeed;
	public float rangeOfSpeedChange = 5f;
	public float updateFrequencyOfSpeed = 50f;
	public bool onMovement = false;
	// Location
	public float horizontalRange = 10f;
	public float VerticalRange = 10f;

	private float currentSpeed;
	private float updateSpeedCountDown;
	private Vector2 direction;

	// Use this for initialization
	void Start()
	{
		// Speed Initializing
		if (this.basicSpeed - 0 < 0.001 || this.basicSpeed + this.rangeOfSpeedChange / 2 > this.maxSpeed)
		{
			this.basicSpeed = Random.value * this.maxSpeed;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (this.onMovement)
		{
			this.UpdateSpeed();
			this.Move();
		}

	}

	void UpdateSpeed()
	{
		if (this.updateSpeedCountDown - 0 < 0.1)
		{
			this.currentSpeed = this.basicSpeed + this.rangeOfSpeedChange * Random.Range(-1f, 1f);
			this.direction = Random.insideUnitCircle;
			this.updateSpeedCountDown = 1f / this.updateFrequencyOfSpeed / Time.deltaTime;
		}
		else
		{
			this.updateSpeedCountDown -= 1;
		}
	}

	void Move()
	{
		if (Mathf.Abs(this.transform.position.x) >= this.horizontalRange / 2)
		{
			this.direction = new Vector2(this.direction.x * -1, this.direction.y);

		}
		if (Mathf.Abs(this.transform.position.y) >= this.VerticalRange / 2)
		{
			this.direction = new Vector2(this.direction.x, this.direction.y * -1);
		}

		Vector3 v = new Vector3(this.direction.x, this.direction.y, 0);
		this.transform.position = this.transform.position + v * this.basicSpeed * Time.deltaTime;
	}
}
