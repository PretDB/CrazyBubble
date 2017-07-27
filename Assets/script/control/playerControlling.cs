using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;

using System;
using UnityEngine.Networking.Types;
using System.IO;



public class playerControlling : controlling
{

    private myJoy stick;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        this.stick = GameObject.FindGameObjectWithTag("stick").GetComponent<myJoy>();
    }

    public override void UpdateControllingData()
    {
        if (isLocalPlayer)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            float horJoy = stick.horizontalValue;
            float verJoy = stick.verticalValue;
            Vector3 newv = new Vector3(horJoy, verJoy, 0) + new Vector3(hor, ver, 0);
            this.physicModel.UpdateCurrentSpeedVector(newv);
        }
    }

}
