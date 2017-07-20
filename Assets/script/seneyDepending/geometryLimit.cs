using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class geometryLimit : MonoBehaviour
{
	public float boundLeft;
	public float boundRight;
	public float boundTop;
	public float boundBottom;

	private float leftB;
	private float rightB;
	private float topB;
	private float bottomB;


	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		this.UpdateBoundary();
	}

	void UpdateBoundary()
	{
		this.leftB = this.transform.position.x - this.transform.localScale.x;
		this.rightB = leftB + 2 * this.transform.localScale.x;
		this.topB = this.transform.position.y + this.transform.localScale.y;
		this.bottomB = topB + 2 * this.transform.localScale.y;
	}

	bool IsInsideOfBoundray()
	{
		return ((this.rightB < this.boundRight && this.leftB > this.boundLeft) && (this.topB < this.boundTop && this.bottomB > this.boundBottom));
	}

	public Vector3 CutSpeedVector(Vector3 input)
	{
		Vector3 res = new Vector3(input.x, input.y, input.z);
		if (!IsInsideOfBoundray())
		{
			if (this.leftB < this.boundLeft || this.rightB > this.boundRight)
			{
				res.x = 0;
			}
			if (this.topB > this.boundTop || this.bottomB < this.boundBottom)
			{
				res.y = 0;
			}
		}
		return res;
	}
}
