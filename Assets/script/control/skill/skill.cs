using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net.Security;
using UnityEngine.Timeline;

public class skill : NetworkBehaviour
{
    /// <summary>
    /// skill property, including scoped, directional and selfGain.
    /// </summary>
    public enum property
    {
        notused,
        scoped,
        directinal,
        selfGain
    }

    public enum state
    {
        avaliable,
        startingUp,
        onEffectiving,
        postEffectiving,
        coolingDown
    }

    /// <summary>
    /// The main argument. First for mainly affect scope, like distance or range.
    /// Second for affect time. Third for charging, like life charging.
    /// </summary>
    public float[] mainArg;
    [SyncVar]
    public float startUpTime = 0f;
    [SyncVar]
    public float startUpLeft = 0f;
    [SyncVar]
    public float effectiveTime = 0f;
    [SyncVar]
    public float effectiveLeft = 0f;
    [SyncVar]
    public float postEffectivingTime = 0f;
    [SyncVar]
    public float postEffectivingLeft = 0f;
    [SyncVar]
    public float coolDownTime = 1f;
    [SyncVar]
    public float coolDownLeft = 1f;
    [SyncVar]
    public state currentState = state.avaliable;
    [SyncVar]
    public bool isAvaliable = true;
    public bool isPreEffectiving = false;
    public bool isEffectiving = false;
    public bool isPostEffectiving = false;
    public bool isCoolingDown = false;
    public bool allowToCoolDown = true;

    /// <summary>
    /// Gets the property.
    /// </summary>
    /// <value>The property.</value>
    public property prop
    {
        get;
        protected set;
    }

    public string skillName
    {
        get;
        protected set;
    }

    public Int32 level
    {
        get;
        protected set;
    }

    public physic physicModel;
    public GameObject master;


    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        this.coolDownLeft = 0f;
        this.prop = property.notused;
        this.skillName = "unnamed skill";
    }

    protected virtual void Update()
    {
       
    }

    /// <summary>
    /// Fixeds the update.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        switch (this.currentState)
        {
            case state.startingUp:
                this.StartingUp();
                break;
            case state.onEffectiving:
                this.Effectiving();
                break;
            case state.postEffectiving:
                this.PostEffectving();
                break;
            case state.coolingDown:
                this.CoolingDown();
                break;
        }
    }

    protected virtual void Upgrade()
    {
        this.level += 1;
    }

    /// <summary>
    /// Starting up. Contains counting down and state switching.
    /// </summary>
    protected virtual void StartingUp()
    {
        this.CountDown(ref this.startUpLeft, this.startUpTime, state.onEffectiving, ref this.effectiveLeft, this.effectiveTime);

        // starting up
    }

    /// <summary>
    /// Effectiving skill, contains counting down and state switching.
    /// </summary>
    protected virtual void Effectiving()
    {
        this.CountDown(ref this.effectiveLeft, this.effectiveTime, state.postEffectiving, ref this.postEffectivingLeft, this.postEffectivingTime);
        // do skill
    }

    /// <summary>
    /// Post effectving. contains counting down and state switching.
    /// </summary>
    protected virtual void PostEffectving()
    {
        this.CountDown(ref this.postEffectivingLeft, this.postEffectivingTime, state.coolingDown, ref this.coolDownLeft, this.coolDownTime);

        // post effect
    }

    /// <summary>
    /// Cooling down. contains counting down and state switching.
    /// </summary>
    protected virtual void CoolingDown()
    {
        if (this.allowToCoolDown)
        {
            this.CountDown(ref this.coolDownLeft, this.coolDownTime, state.avaliable, ref this.startUpLeft, this.startUpTime);
        }
    }

    /// <summary>
    /// Counts down.
    /// </summary>
    /// <param name="timeLeft">Time left.</param>
    /// <param name="TimeTotal">Time total.</param>
    /// <param name="nextState">Next state.</param>
    /// <param name="nextLeft"> Next left.</param>
    /// <param name="nextTime"> Next Time.</param>
    protected virtual void CountDown(ref float timeLeft, float TimeTotal, state nextState, ref float nextLeft, float nextTime)
    {
        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft <= 0f)
        {
            this.currentState = nextState;
            nextLeft = nextTime;
        }
    }

    /// <summary>
    /// This DOES NOT include cool down, you should call cool down as needed.
    /// </summary>
    public virtual void ReleaseSkill()
    {
        if (this.currentState == state.avaliable)
        {
            this.currentState = state.startingUp;
        }
    }

}
