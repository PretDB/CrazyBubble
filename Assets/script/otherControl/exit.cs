using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
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
        Application.Quit();
    }
}
