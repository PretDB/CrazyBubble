using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mySole : MonoBehaviour
{
    public enum GameMethod
    {
        host,
        client
    }

    public string myName;


    public GameMethod gameMethod = GameMethod.host;

    void Start()
    {
        
    }

    void Update()
    {

    }
}
