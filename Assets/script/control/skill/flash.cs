using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class flash : skill
{

    protected override void Awake()
    {
        base.Awake();
        this.mainArg = new float[1];
    }

    protected override void Start()
    {
        base.Start();
        this._prop = property.directinal;
        this.mainArg[0] = 5f;
        //this.physicModel = this.gameObject.GetComponent<physic>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void CoolingDown()
    {
        base.CoolingDown();
    }

    protected override void Upgrade()
    {
        base.Upgrade();
        this.mainArg[0] = this.level * 2;
    }

    public override void ReleaseSkill()
    {
        if (this.avaliable)
        {
            Vector3 dir = this.physicModel.currentSpeedVector;
            this.gameObject.transform.position = this.gameObject.transform.position + dir * this.mainArg[0];
        }
    }
}
