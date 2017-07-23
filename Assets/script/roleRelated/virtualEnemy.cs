using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virtualEnemy : role
{
    

    // Use this for initialization
    protected override void Start()
    {
        this.ishostile = true;
        this.roleController = this.gameObject.AddComponent<randomControlling>();
        this.roleController.Init(gameObject);
    }
	
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
