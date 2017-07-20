using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class randomControlling : controller
{

	public float speedUpdateFrequency;

	private float speedUpdateCountDown;
	// Use this for initialization
	void Start()
	{
		this.isComputer = true;
		if (this.speedUpdateFrequency - 0 < 0.1)
		{
			this.speedUpdateFrequency = 1f;
		}
		this.Init();
	}
	
	// Update is called once per frame
	void Update()
	{
		this.UpdateSpeed();
	}

	void UpdateSpeed()
	{
		if (this.speedUpdateCountDown - 0 < 0.1)
		{
			this.UpdateCurrentSpeedVector();
			this.ResetSpeedUpdateCountDown();
		}
		else
		{
			this.speedUpdateCountDown -= 1f;
		}
	}

	void ResetSpeedUpdateCountDown()
	{
		this.speedUpdateCountDown = 1 / this.speedUpdateFrequency / Time.deltaTime;
	}

	protected override void UpdateCurrentSpeedVector()
	{
		Vector3 randomSpeedVector = UnityEngine.Random.insideUnitSphere;
		randomSpeedVector.z = 0;
		this.physicModel.UpdateCurrentSpeedVector(randomSpeedVector);
	}

	protected override void Init()
	{
		this.physicModel = this.GetComponent<physic>();
	}
}
