using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using AssemblyCSharp;

public class player : NetworkBehaviour
{
    public Int32 teamNumber = 0;
    public bool isFreemode = true;
    [SyncVar]
    public Color mySkin;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="player"/> is computer.
    /// </summary>
    /// <value><c>true</c> if is computer; otherwise, <c>false</c>.</value>
    public bool isComputer
    {
        get
        {
            return this._isComputer;
        }
        set
        {
            this._isComputer = value;
            this.ResetController();
        }
    }

    /// <summary>
    /// The skill slot.
    /// </summary>
    public skill[] skillSlot;


    private controlling controller;
    private physic physicModel;
    private bool _isComputer = false;
    private Rect scope;

    private void ResetController()
    {
        if (!this._isComputer)
        {
            if (this.gameObject.GetComponent<computerControlling>() != null)
            {
                Destroy(this.gameObject.GetComponent<computerControlling>());
            }
            this.gameObject.AddComponent<playerControlling>();
            this.controller = this.gameObject.GetComponent<playerControlling>();
        }
        else
        {
            if (this.gameObject.GetComponent<player>() != null)
            {
                Destroy(this.gameObject.GetComponent<playerControlling>());
            }
            this.gameObject.AddComponent<computerControlling>();
            this.controller = this.gameObject.GetComponent<computerControlling>();
        } 
    }

    void Awake()
    {
        this.physicModel = this.gameObject.GetComponent<physic>();
        this.ResetController();
        this.physicModel.weight = 1f;
        this.SetAppearence();
        this.mySkin = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.skillSlot = new skill[2];
        this.name = "role";
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<view>().target = this.gameObject;
        }
        this.scope = GameObject.FindWithTag("map").GetComponent<geographicalLimit>().activeArea;
        Vector3 newLoc = new Vector3(UnityEngine.Random.Range(this.scope.xMin, this.scope.xMax), UnityEngine.Random.Range(this.scope.yMin, this.scope.yMax), 0);
        this.gameObject.transform.position = newLoc;
        this.gameObject.GetComponent<SpriteRenderer>().color = this.mySkin;

        this.skillSlot[0] = this.gameObject.AddComponent<flash>();

    }
	
    // Update is called once per frame
    void Update()
    {
        this.controller.UpdateControllingData();
    }

    public void SetAppearence()
    {
        this.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
    }

    /// <summary>
    /// Sets the skill to skill slot. 
    /// </summary>
    /// <param name="slot">Slot, 0 for first slot</param>
    /// <param name="s">S, skill to add</param>
    public void SetSkill(int slot, skill s)
    {
    }
}
