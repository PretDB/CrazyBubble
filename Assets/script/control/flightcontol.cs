using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

public class flightcontol : NetworkBehaviour
{

    public float rotateSpeed = 3f;




    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            GameObject.Find("Camera").GetComponent<netCameraFollow>().target = this.gameObject;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        this.LocalMove(); 
    }

    void LocalMove()
    {
        if (isLocalPlayer)
        {
            Vector3 v = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                v = new Vector3(0, v.y + this.rotateSpeed * Time.deltaTime * 5, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                v = new Vector3(0, v.y - this.rotateSpeed * Time.deltaTime * 5, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                v = new Vector3(0, v.y, -this.rotateSpeed * Time.deltaTime * 20);
            }
            if (Input.GetKey(KeyCode.D))
            {
                v = new Vector3(0, v.y, +this.rotateSpeed * Time.deltaTime * 20);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                v = new Vector3(+this.rotateSpeed * Time.deltaTime * 20, v.y, v.z);
            }
            if (Input.GetKey(KeyCode.E))
            {
                v = new Vector3(-this.rotateSpeed * Time.deltaTime * 20, v.y, v.z);
            }
            this.CmdRemoteMove(v);
        }  
    }

    [Command]
    void CmdRemoteMove(Vector3 v)
    {
        this.transform.Translate(new Vector3(0, 0, v.y));
        this.transform.Rotate(new Vector3(0, v.z, v.x));
    }
}
