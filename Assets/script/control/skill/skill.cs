using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;

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

    /// <summary>
    /// The main argument. First for mainly affect scope, like distance or range.
    /// Second for affect time. Third for charging, like life charging.
    /// </summary>
    public float[] mainArg;
    /// <summary>
    /// The cool down time. In seconds
    /// </summary>
    public float coolDownTime = 1f;
    public bool avaliable = true;
    public bool allowToCoolDown = true;

    /// <summary>
    /// Gets the property.
    /// </summary>
    /// <value>The property.</value>
    public property prop
    {
        get
        {
            return this._prop;
        }
    }


    public string skillName
    {
        get
        {
            return this._skillName;
        }
    }

    public Int32 level
    {
        get
        {
            return this._level;
        }
    }

    protected float coolDownLeft = 0f;
    protected Int32 _level = 0;
    protected string _skillName = "unnamed skill";
    protected physic physicModel;
    protected property _prop;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        this.coolDownLeft = 0f;
        this._prop = property.notused;
    }

    protected virtual void Update()
    {
		
    }

    protected virtual void FixedUpdate()
    {
        this.CoolingDown();
    }

    protected virtual void CoolingDown()
    {
        if (this.allowToCoolDown)
        {
            if (!this.avaliable)
            {
                this.coolDownLeft -= Time.fixedDeltaTime;
            }
            if (this.coolDownLeft < 0f)
            {
                this.coolDownLeft = 0f;
                this.avaliable = true;
            }
        }
    }

    protected virtual void Upgrade()
    {
        this._level += 1;
    }

    /// <summary>
    /// This DOES NOT include cool down, you should call cool down as needed.
    /// </summary>
    public virtual void ReleaseSkill()
    {
        if (this.avaliable)
        {
            // Do somthing
        }
    }
}
