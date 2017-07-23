using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class role : MonoBehaviour
{
    public bool ishostile = false;
    protected controller roleController;

    // Use this for initialization
    protected virtual void Start()
    {
        this.roleController = new controller();
        this.roleController.Init(gameObject);
    }
	
    // Update is called once per frame
    protected virtual void Update()
    {
        this.roleController.UpdateControllingData();
    }
}
