using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using AssemblyCSharp;
using System.Reflection;
using System.Threading;
using UnityEngine.UI;

public class player : NetworkBehaviour, IControllingEvnets
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
        this.name = this.GetInstanceID().ToString();
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


        if (this.isComputer == false && isLocalPlayer)
        {
            // add skill slot;
            switch (PlayerPrefs.GetString("skillA"))
            {
                case "flash":
                    this.skillSlot[0] = this.gameObject.AddComponent<flash>();
                    break;
                case "speed up":
                    this.skillSlot[0] = this.gameObject.AddComponent<speedUp>();
                    break;
                case "hugelize":
                    this.skillSlot[0] = this.gameObject.AddComponent<hugelize>();
                    break;
            }
            switch (PlayerPrefs.GetString("skillB"))
            {
                case "flash":
                    this.skillSlot[1] = this.gameObject.AddComponent<flash>();
                    break;
                case "speed up":
                    this.skillSlot[1] = this.gameObject.AddComponent<speedUp>();
                    break;
                case "hugelize":
                    this.skillSlot[1] = this.gameObject.AddComponent<hugelize>();
                    break;
            }

            this.skillSlot[0].physicModel = this.physicModel;
            this.skillSlot[0].master = this.gameObject;
            this.skillSlot[1].physicModel = this.physicModel;
            this.skillSlot[1].master = this.gameObject;

            GameObject.Find("button0").GetComponent<skillPad>().myPrecious = this.skillSlot[0];
            GameObject.Find("button0").GetComponent<skillPad>().me = this.gameObject;
            GameObject.Find("skillSlot0").GetComponent<Text>().text = PlayerPrefs.GetString("skillA");
            GameObject.Find("button1").GetComponent<skillPad>().myPrecious = this.skillSlot[1];
            GameObject.Find("button1").GetComponent<skillPad>().me = this.gameObject;
            GameObject.Find("skillSlot1").GetComponent<Text>().text = PlayerPrefs.GetString("skillB");

            this.name = PlayerPrefs.GetString("name");
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        this.controller.UpdateControllingData();
    }

    public void OnSkillRelease(int slot)
    {
        if (isLocalPlayer)
        {
            if (slot < this.skillSlot.Length)
            {
                Type tp = this.skillSlot[slot].GetType();
                MethodInfo mi = tp.GetMethod("ReleaseSkill");
                mi.Invoke(this.skillSlot[slot], null);
            }
        }
    }

    public void SetAppearence()
    {
        this.GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
    }


}
