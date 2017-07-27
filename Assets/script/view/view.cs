using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


using UnityEngine.Networking;

/// <summary>
/// manage the view.
/// </summary>
public class view : NetworkBehaviour
{

    public float distanceRate = 0.3f;
    public GameObject target;
    public  Camera cam;


    // Use this for initialization
    void Start()
    {
        this.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (this.distanceRate - 0 < 0.1f)
        {
            this.distanceRate = 0.03f;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            this.cam.orthographicSize = Mathf.Lerp(this.cam.orthographicSize, this.target.transform.localScale.x / this.distanceRate, Time.deltaTime * 5);
            this.cam.transform.position = Vector3.Lerp(this.cam.transform.position, new Vector3(this.target.transform.position.x, this.target.transform.position.y, this.cam.transform.position.z), Time.deltaTime * 15);
        }
    }
}
