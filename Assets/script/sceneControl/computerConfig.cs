using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class computerConfig : NetworkBehaviour
{
    public bool allowComputer = true;
    public int maxComputerNumber = 50;
    public GameObject computerModel;

    private List<GameObject> computerList;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
