using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class hugelize : skill
{

    protected override void Awake()
    {
        base.Awake();
        this.mainArg = new float[2];
    }

    protected override void Start()
    {
        base.Start();
        this.prop = property.selfGain;
        this.mainArg[0] = 2f;                       //  weight improving factor
        this.mainArg[1] = 0.1f;                     // percent weight to charge
        this.coolDownTime = 0.5f;
        this.coolDownLeft = this.coolDownTime;
        this.effectiveTime = 5f;
        this.effectiveLeft = this.effectiveTime;
    }

    protected override void Upgrade()
    {
        base.Upgrade();
        this.mainArg[0] -= 0.2f;                    // improvement decrease
        this.mainArg[1] *= 0.8f;                    // charge decrease
        this.coolDownTime += 0.2f;                  // cool down time decrease
    }

    protected override void StartingUp()
    {
        base.StartingUp();
        float newWeight = this.physicModel.weight + this.mainArg[0];
        this.physicModel.CmdUpdateSize(newWeight);
    }

    protected override void Effectiving()
    {
        base.Effectiving();
    }

    protected override void PostEffectving()
    {
        base.PostEffectving();
        float newWeight = physicModel.weight - this.mainArg[0];
        newWeight = newWeight * (1 - this.mainArg[1]);
        this.physicModel.CmdUpdateSize(newWeight);
    }
}
