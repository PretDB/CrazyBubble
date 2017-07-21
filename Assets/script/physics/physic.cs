using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

//using UnityEditor.SceneManagement;

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
    public geometryLimit geoLimit;

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
        this.geoLimit = this.GetComponent<geometryLimit>();
    }
	
    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        this.OnCrash(colli);
    }

    void OnCrash(Collision2D colli)
    {
        if (this.weight - colli.collider.GetComponent<physic>().weight > 0.1f)
        {
            this.UpdateWeightFrom(colli.collider);
            Destroy(colli.collider);
            Debug.Log(colli.collider.name + " should be destried");
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
        this.transform.localScale = new Vector3(radius, radius, 1f);
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
        //this.currentSpeedVector = this.geoLimit.CutSpeedVector(this.currentSpeedVector);
        this.transform.position += this.currentSpeedVector * Time.deltaTime;
    }
}
