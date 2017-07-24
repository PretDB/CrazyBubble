using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class netCameraFollow : NetworkBehaviour
{

    public GameObject target;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 v = this.target.transform.position + this.offset;
            //this.transform.position = this.target.transform.position + this.offset;
            this.transform.position = Vector3.Lerp(this.transform.position, v, Time.deltaTime * 2);
        }
    }
}
