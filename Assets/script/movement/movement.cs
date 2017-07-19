using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movement : MonoBehaviour
{
    public float speed;
    public Camera seeMe;
    public float initCameraDistance = 10;

    private float rate;
    private float weight;
    // this.radius / (distance between camera and role)
    // Use this for initialization
    void Start()
    {
        this.rate = this.transform.localScale.x / this.initCameraDistance;
        this.weight = Mathf.Pow(this.transform.localScale.x, 2);
    }
	
    // Update is called once per frame
    void Update()
    {
        this.UpdateSpeed();
        this.UpdateLoc();

        this.UpdateCamera();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float r = other.transform.localScale.x;
        this.UpdateWeight(r);
        Destroy(other.gameObject, 0.1f);
    }

    void OnGUI()
    {
        GUILayout.TextArea(this.rate.ToString());
        GUILayout.TextArea((this.transform.localScale.x / this.rate).ToString());
    }

    void UpdateWeight(float eatenRadius)
    {
        // weight = r * r
        this.weight += Mathf.Pow(eatenRadius, 2f) * UnityEngine.Random.Range(0.01f, 0.3f);
        float newR = Mathf.Sqrt(this.weight) / 2;
        this.transform.localScale = new Vector3(this.transform.localScale.x + newR, this.transform.localScale.y + newR, 1f);
    }

    void UpdateSpeed()
    {
        // speed = 1 / weight 
        this.speed = 1 / this.weight + 1;
    }

    void UpdateLoc()
    {
        var hor = Input.GetAxis("Horizontal");
        var vec = Input.GetAxis("Vertical");
        float horMove = this.speed * Time.deltaTime * hor;
        float vecMove = this.speed * Time.deltaTime * vec;
        this.transform.position = new Vector3(this.transform.position.x + horMove, this.transform.position.y + vecMove, this.transform.position.z);
        this.seeMe.rect;
    }

    void UpdateCamera()
    {
        this.seeMe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0 - this.transform.localScale.x / this.rate);
    }
}
