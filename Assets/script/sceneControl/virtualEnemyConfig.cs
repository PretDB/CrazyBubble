using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEditorInternal;
//using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

//using NUnit.Framework;
using System;

/// <summary>
/// Virtual ememy config. This will keep virtual enemy at a constant number.
/// </summary>
public class virtualEnemyConfig : NetworkBehaviour
{

    public bool allowVirtualEnemy = true;
    public int maxVirtualEnemy = 10;
    public Rect scope;
    public GameObject computerPrefab;

    private List<GameObject> computerList;

    void Awake()
    {
        this.computerList = new List<GameObject>();
    }

    void Start()
    {
        this.scope = GameObject.FindWithTag("map").GetComponent<geographicalLimit>().activeArea;
    }

    void Update()
    {

    }

    public override void OnStartServer()
    {
        if (this.allowVirtualEnemy)
        { 
            for (int a = 0; a < 10; a++)
            {
                this.GenerateVirtualEnemy();
            }
        }

    }


    void GenerateVirtualEnemy()
    {
        if (isServer)
        {
            if (this.computerList.Count < this.maxVirtualEnemy)
            {
                Vector3 newLoc = new Vector3(UnityEngine.Random.Range(this.scope.xMin, this.scope.xMax), UnityEngine.Random.Range(this.scope.yMin, this.scope.yMax), 0);

                GameObject newEnemy = Instantiate(this.computerPrefab);
                this.computerList.Add(newEnemy);

                newEnemy.transform.position = newLoc;
                newEnemy.GetComponent<player>().isComputer = true;
                newEnemy.GetComponent<player>().teamNumber = 1;
                newEnemy.GetComponent<player>().isFreemode = true;
                newEnemy.GetComponent<physic>().weight = UnityEngine.Random.value * 0.9f;

                newEnemy.tag = "computer";
                newEnemy.name = newEnemy.GetInstanceID().ToString();
                SpriteRenderer newEnemyRenderer = newEnemy.GetComponent<SpriteRenderer>();
                newEnemyRenderer.color = UnityEngine.Random.ColorHSV();

                NetworkServer.Spawn(newEnemy);
            } 
        }
    }

    public void KillGameObject(GameObject target)
    {
        this.computerList.Remove(target);
        Destroy(target);
    }
}
