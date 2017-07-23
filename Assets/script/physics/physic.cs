using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

//using UnityEditor.SceneManagement;
//using UnityEngine.Experimental.UIElements.StyleEnums;
//using NUnit.Framework.Constraints;

public class physic : MonoBehaviour
{

    public float weight
    {
        get
        {
            return this.area;
        }
        set
        {
            this.area = value;
            this.r = Mathf.Sqrt(value);
        }
    }

    public float speed = 5;
    public float initMaxWeight = 10;
    public Vector3 currentSpeedVector;
    public geographicalLimit geoLimit;

    private float area;
    private float r;

    // Use this for initialization
    void Start()
    {
        if (this.area - 0 < 0.1)
        {
            this.area = UnityEngine.Random.value * this.initMaxWeight;
        }
        this.currentSpeedVector = Vector3.zero;
        this.geoLimit = GameObject.FindWithTag("map").GetComponent<geographicalLimit>();
        this.weight = Mathf.Pow(gameObject.transform.localScale.x, 2);
    }
	
    // Update is called once per frame
    void Update()
    {
        this.UpdateSpeed();
        this.Move();
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (this.weight - colli.GetComponent<physic>().weight > 0.1f)
        {
            if (colli.tag == "role")
            {
                Application.Quit();
                return;
            }
            if (colli.tag == "enemy")
            {
                this.UpdateWeightFrom(colli);
                virtualEnemyConfig god = GameObject.FindWithTag("god").GetComponent<virtualEnemyConfig>();
                god.KillGameObject(colli.gameObject);
            }
        }
    }

    void UpdateWeightFrom(Collider2D food)
    {
        // weight = r * r
        this.weight += food.GetComponent<physic>().weight * UnityEngine.Random.value;
        this.UpdateSize(this.r);
    }


    void UpdateSize(float radius)
    {
        gameObject.transform.localScale = new Vector3(radius, radius, 1f);
    }

    void UpdateSpeed()
    {
        // speed = 1 / weight 
        this.speed = 1 / this.weight + 1;
    }

    public void UpdateCurrentSpeedVector(Vector3 direction)
    {
        this.currentSpeedVector = this.speed * direction.normalized;
    }

    public void Move()
    {
        Vector3 newD = this.currentSpeedVector * Time.deltaTime;
        Vector3 newLoc = new Vector3(Mathf.Clamp(gameObject.transform.position.x + newD.x, this.geoLimit.activeArea.xMin, this.geoLimit.activeArea.xMax), Mathf.Clamp(gameObject.transform.position.y + newD.y, this.geoLimit.activeArea.yMin, this.geoLimit.activeArea.yMax), newD.z);
        gameObject.transform.position = newLoc;
    }
}
