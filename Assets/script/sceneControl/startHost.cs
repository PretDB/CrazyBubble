using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class startHost : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(this.OnClick);
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    void OnClick()
    {
        GameObject.Find("GodIsLookingAtYou").GetComponent<NetworkManager>().StartHost();
        this.gameObject.SetActive(false);
    }
}
