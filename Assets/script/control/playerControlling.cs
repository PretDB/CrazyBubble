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



public class playerControlling : controller
{

    private myJoy myStick;

    public override void UpdateControllingData()
    {
        if (isLocalPlayer)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            float horJoy = myStick.horizontalValue;//CrossPlatformInputManager.GetAxis(this.horName);
            float verJoy = myStick.verticalValue;//CrossPlatformInputManager.GetAxis(this.verName);
            Vector3 newv = new Vector3(horJoy, verJoy, 0) + new Vector3(hor, ver, 0);
            this.physicModel.UpdateCurrentSpeedVector(newv);
        }
    }

    public override void Init(GameObject target)
    {
        base.Init(target);
        this.myStick = GameObject.FindWithTag("stick").GetComponent<myJoy>();
    }
}
