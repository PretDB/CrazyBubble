using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// manage the view.
/// </summary>
public class view : MonoBehaviour
{

    public Camera cam;
    public float distanceRate;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        if (this.distanceRate - 0 < 0.1f)
        {
            this.distanceRate = this.target.transform.localScale.x / this.cam.orthographicSize;
        }
        this.target = GameObject.FindWithTag("role");
    }
	
    // Update is called once per frame
    void Update()
    {
        this.UpdateCamera();
    }

    void UpdateCamera()
    {
        this.cam.orthographicSize = this.target.transform.localScale.x / this.distanceRate;
        this.cam.transform.position = new Vector3(this.target.transform.position.x, this.target.transform.position.y, this.cam.transform.position.z);
    }

}
