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
        this.prop = property.directinal;
        this.skillName = "flash";
        this.mainArg[0] = 5f;               // distance;

        // time
        this.startUpTime = 0f;
        this.startUpLeft = this.startUpTime;
        this.effectiveLeft = 0f;
        this.effectiveTime = this.effectiveTime;
        this.postEffectivingLeft = 0f;
        this.postEffectivingTime = this.postEffectivingTime;
        this.coolDownTime = 0.5f;
        this.coolDownLeft = this.coolDownTime;

    }

    protected override void Upgrade()
    {
        base.Upgrade();
        this.mainArg[0] = this.level * 2;
    }

    protected override void Effectiving()
    {
        Vector3 dir = this.physicModel.currentSpeedVector;
        this.gameObject.transform.position = this.gameObject.transform.position + dir * this.mainArg[0];
        this.currentState = state.startingUp;
        base.Effectiving();
    }
}
