using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class speedUp : skill
{
    protected override void Awake()
    {
        base.Awake();
        this.mainArg = new float[1];
    }

    protected override void Start()
    {
        base.Start();

        // main arguments
        this.mainArg[0] = 2;                // speed factor

        // time assignment
        this.startUpTime = 0f;
        this.startUpLeft = this.startUpTime;
        this.effectiveTime = 5f;
        this.effectiveLeft = this.effectiveTime;
        this.postEffectivingTime = 0f;
        this.postEffectivingLeft = 0f;
        this.coolDownTime = 0.5f;
        this.coolDownLeft = this.coolDownTime;
    }

    protected override void StartingUp()
    {
        base.StartingUp();
        this.physicModel.CmdUpdateSpeed(this.physicModel.speed * this.mainArg[0]);
    }

    protected override void PostEffectving()
    {
        base.PostEffectving();
        this.physicModel.CmdUpdateSpeed(this.physicModel.speed / this.mainArg[0]);
    }
}
