using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class hugelize : skill
{
    [SyncVar]
    private float addWeight = 2f;
    private float newWeight;

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
        this.effectiveTime = 2f;
        this.effectiveLeft = 2f;
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
        this.newWeight = this.physicModel.weight + this.addWeight;
    }

    protected override void Effectiving()
    {
        base.Effectiving();
        this.physicModel.CmdUpdateSize(this.newWeight);
    }

    protected override void PostEffectving()
    {
        base.PostEffectving();
        this.newWeight = this.physicModel.weight - this.addWeight;
        this.newWeight = this.newWeight * (1 - this.mainArg[1]);
        this.physicModel.CmdUpdateSize(this.newWeight);
    }
}
