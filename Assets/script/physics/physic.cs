using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

using UnityEngine.Networking;

public class physic : NetworkBehaviour
{
    [SyncVar]
    public float weight;
    [SyncVar]
    public float speed = 5;
    public float initMaxWeight = 10;

    public Vector3 currentSpeedVector
    {
        get
        {
            return this._currentSpeedVector;
        }
    }

    public geographicalLimit geoLimit;


    private Vector3 _currentSpeedVector;

    void Start()
    {
        this._currentSpeedVector = Vector3.zero;
        this.geoLimit = GameObject.FindWithTag("map").GetComponent<geographicalLimit>();
        float s = Mathf.Sqrt(this.weight);
        this.transform.localScale = new Vector3(s, s, 1);
        this.CmdUpdateSize(this.weight);
    }

    void Update()
    {
        this.Move();
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (!this.gameObject.GetComponent<player>().isFreemode)
        {
            if (colli.gameObject.GetComponent<player>().teamNumber == this.gameObject.GetComponent<player>().teamNumber)
            {
                return;
            }
        }
        if (this.weight * 0.9f > colli.GetComponent<physic>().weight)
        {
            if (colli.gameObject.tag == "computer")
            {
                this.UpdateWeightFrom(colli);
                virtualEnemyConfig backstab = GameObject.FindWithTag("computerGenerator").GetComponent<virtualEnemyConfig>();
                backstab.KillGameObject(colli.gameObject);
            }
            if (colli.gameObject.tag == "player")
            {
                // destroy player or respawn
            }
        }
    }


    void UpdateWeightFrom(Collider2D food)
    {
        if (this.weight < this.initMaxWeight)
        {
            // weight = r * r
            this.weight += food.GetComponent<physic>().weight * UnityEngine.Random.Range(0.1f, 0.8f);
            if (isLocalPlayer)
            {
                this.CmdUpdateSize(this.weight);
            }
            if (isServer)
            {
                this.RpcUpdateSize(this.weight);
            }
        }
    }


    [Command]
    public void CmdUpdateSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    [Command]
    public void CmdUpdateSize(float weight)
    {
        this.weight = weight;
        float r = Mathf.Sqrt(weight);
        gameObject.transform.localScale = new Vector3(r, r, 1);
        this.CmdUpdateSpeed(1 / this.weight + 3);
        this.RpcUpdateSize(weight);
    }

    public void UpdateCurrentSpeedVector(Vector3 direction)
    {
        this._currentSpeedVector = this.speed * direction.normalized;
    }

    public void Move()
    {
        Vector3 newD = this._currentSpeedVector * Time.deltaTime;
        Vector3 newLoc = new Vector3(Mathf.Clamp(gameObject.transform.position.x + newD.x, this.geoLimit.activeArea.xMin, this.geoLimit.activeArea.xMax), Mathf.Clamp(gameObject.transform.position.y + newD.y, this.geoLimit.activeArea.yMin, this.geoLimit.activeArea.yMax), newD.z);
        gameObject.transform.position = newLoc;
    }

    [ClientRpc]
    void RpcUpdateSize(float weight)
    {
        this.weight = weight;

        float r = Mathf.Sqrt(this.weight);
        this.gameObject.transform.localScale = new Vector3(r, r, 1);
    }

}
