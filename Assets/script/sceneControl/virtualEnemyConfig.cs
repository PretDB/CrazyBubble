using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEditorInternal;
//using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

/// <summary>
/// Virtual ememy config. This will keep virtual enemy at a constant number.
/// </summary>
public class virtualEnemyConfig : NetworkBehaviour
{

    public bool allowVirtualEnemy = true;
    public int maxVirtualEnemy = 10;
    public Rect scope;
    public GameObject enemy;

    private List<GameObject> virtualEnemyList;

    // Use this for initialization
    void Start()
    {
        this.scope = GameObject.FindWithTag("map").GetComponent<geographicalLimit>().activeArea;
        this.virtualEnemyList = new List<GameObject>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (this.allowVirtualEnemy)
        {
            this.GenerateVirtualEnemy();
        }
    }

    void GenerateVirtualEnemy()
    {
        if (this.virtualEnemyList.Count < this.maxVirtualEnemy)
        {
            Vector3 newLoc = new Vector3(UnityEngine.Random.Range(this.scope.xMin, this.scope.xMax), UnityEngine.Random.Range(this.scope.yMin, this.scope.yMax), 0);
            GameObject newEnemy = Instantiate(this.enemy);
            this.virtualEnemyList.Add(newEnemy);
            newEnemy.AddComponent<virtualEnemy>();
            newEnemy.GetComponent<user>().enabled = false;
            newEnemy.GetComponent<NetworkIdentity>().serverOnly = true;
            float scale = UnityEngine.Random.value;
            newEnemy.transform.localScale = new Vector3(scale, scale, 1);
            newEnemy.transform.position = newLoc;
            SpriteRenderer newEnemyRenderer = newEnemy.GetComponent<SpriteRenderer>();
            newEnemyRenderer.color = UnityEngine.Random.ColorHSV();
        } 
    }

    public void KillGameObject(GameObject target)
    {
        this.virtualEnemyList.Remove(target);
        Destroy(target);
    }
}
