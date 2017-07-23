using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user : role
{

    // Use this for initialization
    protected override void Start()
    {
        this.ishostile = false;
        this.roleController = this.gameObject.AddComponent<playerControlling>();
        this.roleController.Init(gameObject);
    }
	
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
