using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.Networking;

public class playerControlling : controller
{

    // Use this for initialization
    void Start()
    {
        this.Init();
    }
	
    // Update is called once per frame
    void Update()
    {
        this.UpdateCurrentSpeedVector();
    }

    protected override void UpdateCurrentSpeedVector()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 newv = new Vector3(hor, ver, 0);
        this.physicModel.UpdateCurrentSpeedVector(newv);
    }

    protected override void Init()
    {
        this.physicModel = this.GetComponent<physic>();
    }
}
